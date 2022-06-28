using ASP_Projet.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Projet.Controllers
{
    public class HomeController : Controller
    {
        private Model1Container db = new Model1Container();
        public ActionResult Index(string searching)
        {
            ViewData["Categories"] = db.Categories.ToList();

            ViewData["Annonces"] = db.Annonces.Where(x => x.Proprietaire.isSpecial == true).Where(x => x.isSpecial == true).Where(x => x.titre.Contains(searching) || searching == null);
            return View();
        }
      
        public ActionResult Categorie(int id,string searching)
        {
            ViewData["Categories"] = db.Categories.ToList();
            if (searching != null)
            {
                ViewData["Annonces"] = db.Annonces.Where(x => x.titre.Contains(searching) || searching == null).ToList();

            }
            else
            {
                ViewData["Annonces"] = db.Categories.Find(id).Annonces;
            }
            
            ViewData["nomCategorie"] = db.Categories.Find(id).nom;
            return View();
        }

        
        
        public ActionResult Annonce(int id)
        {
            
            ViewData["Annonce"] = db.Annonces.Find(id);

            return View();
        }


    }
}