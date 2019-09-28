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
    public class MakaleController : Controller
    {
		// GET: Makale
		Model1 context = new Model1();
		[AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
		
		public ActionResult Ekle()
		{
			ViewBag.Kategoriler = context.Kategori.ToList();
			return View();
		}
		[HttpPost]
		
		public ActionResult Ekle(Makale  mkl,  HttpPostedFileBase resim)
		{

			Image img = Image.FromStream(resim.InputStream);


			Bitmap kckResim = new Bitmap(img, Settings.ResimKucukBoyut);
			Bitmap ortaResim = new Bitmap(img, Settings.ResimOrtaBoyut);
			Bitmap bykResim = new Bitmap(img, Settings.ResimBuyukBoyut);

			kckResim.Save(Server.MapPath("/Content/MakaleResim/Smallimage" + resim.FileName));
			ortaResim.Save(Server.MapPath("/Content/MakaleResim/Mediumimage") + resim.FileName);
			bykResim.Save(Server.MapPath("/Content/MakaleResim/Largeimage" + resim.FileName));

			Resim rsm = new Resim();

			rsm.KucukResimYol = "/Content/MakaleResim/Smallimage" + resim.FileName;
			rsm.OrtaResimYol = "/Content/MakaleResim/Mediumimage" + resim.FileName;
			rsm.BuyukResimYol = "/Content/MakaleResim/Largeimage" + resim.FileName;

			context.Resim.Add(rsm);
			context.SaveChanges();
			mkl.ResimID = rsm.ID;
			mkl.YayimTarihi = DateTime.Now;

			//int yzrId = context.Kullanici.FirstOrDefault(x => x.KullaniciAdi == User.Identity.Name).Id;

			//mkl.YazarID = yzrId;

			context.Makale.Add(mkl);
			context.SaveChanges();

			//if(mkl != null)
			//{
			//	Kullanici aktif = Session["Kullanici"] as Kullanici;
			//	mkl.YayimTarihi = DateTime.Now;
			//	mkl.YazarID = aktif.Id;
			//}
			return RedirectToAction("Index", "Home");
		}


		public ActionResult AdminYazarMakaleEkle()
		{
			ViewBag.Kategoriler = context.Kategori.ToList();
			return View();
		}
		[HttpPost]

		public ActionResult AdminYazarMakaleEkle(Makale mkl, HttpPostedFileBase resim)
		{

			Image img = Image.FromStream(resim.InputStream);


			Bitmap kckResim = new Bitmap(img, Settings.ResimKucukBoyut);
			Bitmap ortaResim = new Bitmap(img, Settings.ResimOrtaBoyut);
			Bitmap bykResim = new Bitmap(img, Settings.ResimBuyukBoyut);
			Bitmap yzrResim = new Bitmap(img, Settings.YazarResimBoyut);

			kckResim.Save(Server.MapPath("/Content/MakaleResim/Smallimage" + resim.FileName));
			ortaResim.Save(Server.MapPath("/Content/MakaleResim/Mediumimage") + resim.FileName);
			bykResim.Save(Server.MapPath("/Content/MakaleResim/Largeimage" + resim.FileName));
			yzrResim.Save(Server.MapPath("/Content/MakaleResim/Yazarimage" + resim.FileName));

			Resim rsm = new Resim();

			rsm.KucukResimYol = "/Content/MakaleResim/Smallimage" + resim.FileName;
			rsm.OrtaResimYol = "/Content/MakaleResim/Mediumimage" + resim.FileName;
			rsm.BuyukResimYol = "/Content/MakaleResim/Largeimage" + resim.FileName;
			rsm.YazarResimYol = "/Content/MakaleResim/Yazarimage" + resim.FileName;

			context.Resim.Add(rsm);
			context.SaveChanges();
			mkl.ResimID = rsm.ID;
			mkl.YayimTarihi = DateTime.Now;

			//int yzrId = context.Kullanici.FirstOrDefault(x => x.KullaniciAdi == User.Identity.Name).Id;

			//mkl.YazarID = yzrId;

			context.Makale.Add(mkl);
			context.SaveChanges();

			//if(mkl != null)
			//{
			//	Kullanici aktif = Session["Kullanici"] as Kullanici;
			//	mkl.YayimTarihi = DateTime.Now;
			//	mkl.YazarID = aktif.Id;
			//}
			return RedirectToAction("Index", "Home");
		}


	}
}