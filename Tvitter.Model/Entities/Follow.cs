using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tvitter.Core.Entity;

namespace Tvitter.Model.Entities
{
    public class Follow : CoreEntity
    {
        public Guid FollowerId { get; set; }

        public Guid FollowingId { get; set; }
    }
}
