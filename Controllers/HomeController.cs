using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Myblogg.Controllers
	
{
	
    public class HomeController : Controller
    {
		// GET: Home
		Model1 context = new Model1();
		public ActionResult Index()
        {
            return View();
        }
		
		public ActionResult MakaleListele()
		{
			var data = context.Makale.ToList();
			return View("MakaleListeleWidget", data);
		}
		
		

		

	}
}