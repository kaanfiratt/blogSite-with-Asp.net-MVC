using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myblogg.Controllers
{
	[Authorize]

	public class YazarController : Controller
    {
		// GET: Yazar
		
		Model1 context = new Model1();
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult YazarOl()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YazarOl(Kullanici kl)
		{
			//if (!string.IsNullOrEmpty(rdKadin))
			//	kl.cinsiyet = true;
			//if (!string.IsNullOrEmpty(rdErkek))
			//	kl.cinsiyet = true;

			kl.Yazar = true;
			kl.Onaylandimi = false;
			kl.Aktif = true;
			kl.KayitTarihi = DateTime.Now;
			context.Kullanici.Add(kl);
			context.SaveChanges();

			Rol yazar = context.Rol.FirstOrDefault(x => x.RolAdi == "Yazar");

			kullanicirol kr = new kullanicirol();
            kr.RolID = yazar.id;
            kr.KullaniciID = kl.id;

			context.kullanicirol.Add(kr);
			context.SaveChanges();

			return RedirectToAction("Index", "Home");

		}

		public ActionResult AdminYazarEkle()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AdminYazarEkle(Kullanici kl)
		{
			//if (!string.IsNullOrEmpty(rdKadin))
			//	kl.cinsiyet = true;
			//if (!string.IsNullOrEmpty(rdErkek))
			//	kl.cinsiyet = true;

			kl.Yazar = true;
			kl.Onaylandimi = false;
			kl.Aktif = true;
			kl.KayitTarihi = DateTime.Now;
			context.Kullanici.Add(kl);
			context.SaveChanges();

			Rol yazar = context.Rol.FirstOrDefault(x => x.RolAdi == "Yazar");

			kullanicirol kr = new kullanicirol();
			kr.RolID = yazar.id;
			kr.KullaniciID = kl.id;

			context.kullanicirol.Add(kr);
			context.SaveChanges();

			return RedirectToAction("Index", "Home");

		}
		[Authorize(Roles ="Yazar, Admin")]
		public ActionResult MakaleSil(int id)
		{
			var silinecek_makale = context.Makale.Where(w => w.id == id).FirstOrDefault();
			context.Makale.Remove(silinecek_makale);
			context.SaveChanges();

			return RedirectToAction("Index", "Home");
		}
		public ActionResult MakaleGuncelle(int id)
		{
			var guncellenicek_makale = context.Makale.Where(w => w.id == id).FirstOrDefault();
			guncellenicek_makale.Baslik = "Başlık";
			guncellenicek_makale.Icerik = "İçerik";
			context.SaveChanges();

			return RedirectToAction("Index", "Home");
		}

	}
}