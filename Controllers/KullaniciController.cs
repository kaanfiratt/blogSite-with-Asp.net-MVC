using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Myblogg.Controllers
{
    public class KullaniciController : Controller
    {
		// GET: Kullanici
		Model1 context = new Model1();

		public object FormAuthenticationTicket { get; private set; }

		public ActionResult Index()
        {
            return View();
        }

		public ActionResult GirisYap()
		{
			return View();
		}

		[HttpPost]

		public ActionResult GirisYap(Kullanici kl)
		{
			string kk = ValidateUser(kl.KullaniciAdi, kl.Parola);


			if (!string.IsNullOrEmpty(kk))
			{
				FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, kl.KullaniciAdi, DateTime.Now, DateTime.Now.AddMinutes(15), true, kk, FormsAuthentication.FormsCookiePath);

				HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName);
				if (ticket.IsPersistent)
				{
					ck.Expires = ticket.Expiration;
				}

				Response.Cookies.Add(ck);
				FormsAuthentication.RedirectFromLoginPage(kl.KullaniciAdi, true);
				return RedirectToAction("Index", "Home");

			}
			else
			{
				ModelState.AddModelError("", "Kullanıccı Adı veya Parola Yanlış");
			}
			
			return View(kl);
		
		}

		string ValidateUser(string ka, string pwd)
		{
			Kullanici kl = context.Kullanici.FirstOrDefault(x => x.KullaniciAdi == ka && x.Parola == pwd);

			if (kl != null)
				return kl.KullaniciAdi;
			else
			{

				return "";
				

			}

			

		}
		
		public ActionResult CikisYap()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("GirisYap");
		}

		public ActionResult UyeOl()
		{
			return View();
		}
		[HttpPost]

		public ActionResult UyeOl(Kullanici kl)
		{
			//if (!string.IsNullOrEmpty(rdKadin))
			//	kl.cinsiyet = true;
			//if (!string.IsNullOrEmpty(rdErkek))
			//	kl.cinsiyet = true;
			
			kl.Yazar = false;
			kl.Onaylandimi = true;
			kl.Aktif = true;
			kl.DogumTarihi = kl.DogumTarihi.Value.Date;
			kl.KayitTarihi = DateTime.Now;
			context.Kullanici.Add(kl);
			context.SaveChanges();
			return RedirectToAction("GirisYap");

		}

		public ActionResult AdminKullaniciEkle()
		{
			return View();
		}
		[HttpPost]

		public ActionResult AdminKullaniciEkle(Kullanici kl)
		{
			//if (!string.IsNullOrEmpty(rdKadin))
			//	kl.cinsiyet = true;
			//if (!string.IsNullOrEmpty(rdErkek))
			//	kl.cinsiyet = true;

			kl.Yazar = false;
			kl.Onaylandimi = true;
			kl.Aktif = true;
			kl.DogumTarihi = kl.DogumTarihi.Value.Date;
			kl.KayitTarihi = DateTime.Now;
			context.Kullanici.Add(kl);
			context.SaveChanges();
			return RedirectToAction("GirisYap");

		}

	}
}