using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_Projet.Models;

namespace ASP_Projet.Controllers
{
    public class AdminController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Admin
        public ActionResult Dashboard(string searching)
        {
            return View(db.Proprietaires.Where(x=>x.nom.Contains(searching) || searching==null).ToList());
        }

        public ActionResult AddToFavoris(int id)
        {
            var rec = db.Liste_Favorie.Where(x => x.id_proprietaire == id).ToList().FirstOrDefault();
            if(rec == null)
            {
                Liste_Favorie liste = new Liste_Favorie();
                liste.id_proprietaire = id;
                db.Liste_Favorie.Add(liste);
                db.SaveChanges();
            }
           
            return RedirectToAction("Dashboard","Admin");
        }

        public ActionResult AddToBlock(int id)
        {
            var rec = db.Liste_noire.Where(x => x.id_proprietaire == id).ToList().FirstOrDefault();
            if (rec == null)
            {
                Liste_noire liste = new Liste_noire();
                liste.id_proprietaire = id;
                db.Liste_noire.Add(liste);
                db.SaveChanges();
            }
            return RedirectToAction("Dashboard", "Admin");
        }

        public ActionResult SetSpecial(int id)
        {
            var prop = db.Proprietaires.Where(x => x.Id_proprietaire == id).ToList().FirstOrDefault();
            
                prop.isSpecial = !prop.isSpecial;
                db.SaveChanges();
            

            return RedirectToAction("Dashboard", "Admin");
        }

        public ActionResult Favoris(string searching)
        {
            return View(db.Liste_Favorie.Where(x=>x.Proprietaire.nom.Contains(searching) || searching==null).ToList());
        }

        public ActionResult DeleteFromFavoris(int id)
        {
            db.Liste_Favorie.Remove(db.Liste_Favorie.Find(id));
            db.SaveChanges();
            return RedirectToAction("Favoris", "Admin");

        }

        public ActionResult ListeNoire(string searching)
        {
            return View(db.Liste_noire.Where(x => x.Proprietaire.nom.Contains(searching) || searching == null).ToList());
        }

        public ActionResult DeleteFromNoire(int id)
        {
            db.Liste_noire.Remove(db.Liste_noire.Find(id));
            db.SaveChanges();
            return RedirectToAction("ListeNoire", "Admin");

        }

        public ActionResult Categories(string searching)
        {
            return View(db.Categories.Where(x=>x.nom.Contains(searching) || searching==null).ToList());
        }

        public ActionResult EditCategorie(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categories.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCategorie([Bind(Include = "Id_categorie,nom")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View(categorie);
        }

        public ActionResult CreateCategorie()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategorie([Bind(Include = "Id_categorie,nom")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categorie);
                db.SaveChanges();
                return RedirectToAction("Categories");
            }

            return View(categorie);
        }

        public ActionResult DeleteCategorie(int id)
        {
            Categorie categorie = db.Categories.Find(id);
            db.Categories.Remove(categorie);
            db.SaveChanges();
            return RedirectToAction("Categories");
        }

        public ActionResult Message(string searching)
        {
            var messages = db.Messages.Where(m => m.Proprietaire.nom.Contains(searching)  || searching==null);
            return View(messages.ToList());
        }

        public ActionResult DeleteMessage(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Message","Admin");
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
