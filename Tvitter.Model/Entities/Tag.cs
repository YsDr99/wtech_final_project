using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity;

namespace Tvitter.Model.Entities
{
    public class Tag : CoreEntity
    {
        public string Name { get; set; }

        public ICollection<Tweet> Tweets { get; set; }
    }
}
