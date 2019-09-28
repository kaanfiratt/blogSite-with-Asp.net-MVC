using Myblogg.AppClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myblogg.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		// GET: Admin
		Model1 context = new Model1();
		//[Authorize(Roles ="Admin")]
		public ActionResult Index()
		{
			return View();
		}
		//[Authorize(Roles ="Admin")]
		public ActionResult YazarOnay()
		{
			var data = context.Kullanici.Where(x => x.Yazar == true && x.Onaylandimi == false).ToList();

			return View(data);

		}
		//public ActionResult MakaleSil(int id)
		//{
		//	var silinecek_makale = context.Makale.Where(w => w.id == id).FirstOrDefault();
		//	context.Makale.Remove(silinecek_makale);
		//	context.SaveChanges();

		//	return RedirectToAction("Index", "Home");
		//}
		//public ActionResult MakaleGuncelle(int id)
		//{
		//	var guncellenicek_makale = context.Makale.Where(w => w.id == id).FirstOrDefault();
		//	guncellenicek_makale.Baslik = "Başlık";
		//	guncellenicek_makale.Icerik = "İçerik";
		//	context.SaveChanges();

		//	return RedirectToAction("Index", "Home");
		//}
	}



}
