using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tvitter.Core.Service;
using Tvitter.Model.Entities;

namespace Tvitter.Web.Models
{
    public class TrendsViewComponent : ViewComponent
    {

        private readonly ITagService<Tag> _tagContext;

        public TrendsViewComponent(ITagService<Tag> tagContext)
        {
            _tagContext = tagContext;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<Tuple<string, int>> trends = _tagContext.GetTrends().ToList();
            return View(trends);
        }
    }
}
