using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Tvitter.Web.Models
{
    public class Upload
    {
        public Upload(IFormFile file, string folderName, IWebHostEnvironment environment)
        {
            File = file;
            FolderName = folderName;
            _environment = environment;
        }

        public IFormFile File { get; set; }
        public string FolderName { get; set; }
        public IWebHostEnvironment _environment { get; set; }

        public string UploadFile()
        {
            var fileName = string.Empty;
            string PathDB = string.Empty;

            //Getting FileName
            fileName = ContentDispositionHeaderValue.Parse(File.ContentDisposition).FileName.Trim('"');

            //Assigning Unique Filename (Guid)
            var myUniqueFileName = Convert.ToString(Guid.NewGuid());

            //Getting file Extension
            var FileExtension = Path.GetExtension(fileName);

            // concating  FileName + FileExtension
            string newFileName = myUniqueFileName + FileExtension;

            // Combines two strings into a path.
            fileName = Path.Combine(_environment.WebRootPath, FolderName) + $@"\{newFileName}";



            using (FileStream fs = System.IO.File.Create(fileName))
            {
                File.CopyTo(fs);
                fs.Flush();
            }
            string path = "~/" + FolderName + "/" + newFileName;
            return path;
        }
    }
}
