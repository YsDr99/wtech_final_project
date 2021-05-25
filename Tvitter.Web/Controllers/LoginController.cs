using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Service;
using Tvitter.Model.Entities;
using Tvitter.Web.Utility;

namespace Tvitter.Web.Controllers
{

    public class LoginController : Controller
    {
        private readonly ICoreService<User> _context;
        private readonly ICoreService<Notification> _notificationContext;


        public LoginController(ICoreService<User> context, ICoreService<Notification> notificationContext)
        {
            _context = context;
            _notificationContext = notificationContext;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = ComputeSha256Hash(user.Password);
                if (_context.Any(x => x.Email == user.Email && x.Password == user.Password))
                {
                    User logged = _context.GetFirstOrDefault(x =>
                        x.Email == user.Email && x.Password == user.Password);


                    var claims = new List<Claim>()
                        {
                        new Claim("ID", logged.ID.ToString()),
                        new Claim(ClaimTypes.Name, logged.Fullname),
                        new Claim("Username", logged.Username),
                        new Claim(ClaimTypes.Email, logged.Email),
                        };

                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);

                    var clientIpAdress = HttpContext.GetRemoteIPAddress().ToString();

                    if (logged.ModifiedIP != clientIpAdress || logged.ModifiedIP == null)
                    {
                        Notification notification = new Notification()
                        {
                            UserId = logged.ID,
                            Content = "There was a login to your account @" + logged.Username + " from a new device. (" + clientIpAdress + ") on " + DateTime.Now.ToShortDateString(),
                            Type = Core.Entity.Enum.NotificationType.Login,
                            Status = Core.Entity.Enum.Status.Active
                        };
                        _notificationContext.Add(notification);
                    }

                    logged.ModifiedIP = clientIpAdress;
                    var result = _context.Update(logged);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    TempData["ErrorMessage"] = "Email or password is incorrect";
                    return View(user);
                }

            }
            else
            {
                TempData["ErrorMessage"] = "Invalid model or something caused error";
            }
            return View(user);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Username.Contains(' '))
                {
                    TempData["ErrorMessage"] = "White spaces are not allowed.";
                    return View(user);
                }
                if (_context.Any(x => x.Username == user.Username))
                {
                    TempData["ErrorMessage"] = "Username Exist.";
                    return View(user);
                }
                if (_context.Any(x => x.Email == user.Email))
                {
                    TempData["ErrorMessage"] = "Email Exist.";
                    return View(user);
                }

                var clientIpAdress = HttpContext.GetRemoteIPAddress().ToString();
                user.Password = ComputeSha256Hash(user.Password);
                user.CreatedIP = clientIpAdress;

                if (_context.Add(user))
                    ;
                else
                    TempData["ErrorMessage"] = "Something caused error";
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid model or something caused error";
            }
            return RedirectToAction("Index");
        }



        string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
