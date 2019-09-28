using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myblogg.Controllers
{
    public class EtiketController : Controller
    {
		// GET: Etiket
		Model1 context = new Model1();
        public ActionResult Index(int id)
        {
            return View(id);
        }
		public PartialViewResult EtiketWidget()
		{
			
			return PartialView(context.Etiket.ToList());
		}
		public ActionResult MakaleListele(int id)
		{
			var data = context.Makale.Where(x => x.Etiket.Any(y => y.ID== id)).ToList();
			return View("MakaleListeleWidget", data);
			
		}

	}
}