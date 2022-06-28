using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP_Projet.Models;
using System.IO;

namespace ASP_Projet.Controllers
{
    public class ProprietaireController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Proprietaire
        public ActionResult Index(string searching)
        {
            int id = (int) Session["id_Proprietaire"];
            var annonces = db.Annonces.Where(x =>  x.id_proprietaire == id);
            if (searching != null)
            {
                var annonces_by_search = annonces.Where(x => x.titre.Contains(searching)).ToList();
                return View(annonces_by_search.ToList());
            }
            return View(annonces.ToList());
        }

        // GET: Proprietaire/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annonce annonce = db.Annonces.Find(id);
            if (annonce == null)
            {
                return HttpNotFound();
            }
            return View(annonce);
        }

        // GET: Proprietaire/Create
        public ActionResult Create()
        {
            ViewBag.id_categorie = new SelectList(db.Categories, "Id_categorie", "nom");
            ViewBag.id_proprietaire = new SelectList(db.Proprietaires, "Id_proprietaire", "nom");
            return View();
        }

        // POST: Proprietaire/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_categorie,titre,prix,courteDescription,description,isSpecial")] Annonce annonce,HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                string path = "";
                if(imgFile.FileName.Length > 0)
                {
                    path = "~/Images/Annonces/" + Path.GetFileName(imgFile.FileName);
                    imgFile.SaveAs(Server.MapPath(path));
                }
                annonce.image = path;
                annonce.id_proprietaire =(int) Session["id_proprietaire"];
                annonce.date = DateTime.Now;
                db.Annonces.Add(annonce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.id_categorie = new SelectList(db.Categories, "Id_categorie", "nom", annonce.id_categorie);
            //ViewBag.id_proprietaire = new SelectList(db.Proprietaires, "Id_proprietaire", "nom", annonce.id_proprietaire);
            return View(annonce);
        }

        // GET: Proprietaire/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annonce annonce = db.Annonces.Find(id);
            if (annonce == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categorie = new SelectList(db.Categories, "Id_categorie", "nom", annonce.id_categorie);
            ViewBag.id_proprietaire = new SelectList(db.Proprietaires, "Id_proprietaire", "nom", annonce.id_proprietaire);
            return View(annonce);
        }

        // POST: Proprietaire/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_annonce,id_categorie,titre,prix,courteDescription,description,isSpecial")] Annonce annonce, HttpPostedFileBase imgFile)
        {
            if (ModelState.IsValid)
            {
                string path = "";
                if (imgFile.FileName.Length > 0)
                {
                    path = "~/Images/Annonces/" + Path.GetFileName(imgFile.FileName);
                    imgFile.SaveAs(Server.MapPath(path));
                }
                annonce.image = path;
                annonce.id_proprietaire = (int)Session["id_proprietaire"];
                annonce.date = DateTime.Now;
                db.Entry(annonce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categorie = new SelectList(db.Categories, "Id_categorie", "nom", annonce.id_categorie);
            ViewBag.id_proprietaire = new SelectList(db.Proprietaires, "Id_proprietaire", "nom", annonce.id_proprietaire);
            return View(annonce);
        }

        // GET: Proprietaire/Delete/5
       /* public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Annonce annonce = db.Annonces.Find(id);
            if (annonce == null)
            {
                return HttpNotFound();
            }
            return View(annonce);
        }*/

        // POST: Proprietaire/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Annonce annonce = db.Annonces.Find(id);
            db.Annonces.Remove(annonce);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.id_proprietaire = new SelectList(db.Proprietaires, "Id_proprietaire", "nom");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,id_proprietaire,msg")] Message message)
        {
            if (ModelState.IsValid)
            {
                message.id_proprietaire = (int) Session["id_proprietaire"];
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_proprietaire = new SelectList(db.Proprietaires, "Id_proprietaire", "nom", message.id_proprietaire);
            return View(message);
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
