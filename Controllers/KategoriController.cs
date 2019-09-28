using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myblogg.Controllers
{
    public class KategoriController : Controller
    {
		// GET: Kategori
		Model1 context = new Model1();
		public ActionResult Index(int id)
        {
            return View(id);
        }
		public ActionResult MakaleListele(int id)
		{
			var data = context.Makale.Where(x => x.KategoriID == id).ToList();
			return View("MakaleListeleWidget", data);
		}

		public PartialViewResult KategoriWidget()
		{
			return PartialView(context.Kategori.ToList());
		}

		
		
	}
}