using ASP_Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Projet.Controllers
{
    public class ConnectionController : Controller
    {
        private Model1Container db = new Model1Container();
        // GET: Connection
        public ActionResult Login()
        {
            Session["id_Proprietaire"] = null;
            Session["nom_Proprietaire"] = null;
            Session["id_admin"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Login([Bind(Include ="Email,Password")]Proprietaire proprietaire)
        {
            var rec = db.Proprietaires.Where(x => x.email == proprietaire.email && x.password == proprietaire.password).ToList().FirstOrDefault();
            if(rec != null)
            {
                if(db.Liste_noire.Where(x=>x.id_proprietaire==rec.Id_proprietaire).ToList().FirstOrDefault() != null)
                {
                    ViewBag.error = "Vous êtes bloqué par l'admin";
                    return View();

                }
                else
                {
                    Session["id_Proprietaire"] = rec.Id_proprietaire;
                    Session["nom_Proprietaire"] = rec.nom;
                    return RedirectToAction("Index", "Proprietaire");

                }
                

            }
            else
            {
                var rec_admin = db.Admins.Where(x => x.email == proprietaire.email && x.password == proprietaire.password).ToList().FirstOrDefault();
               
                if (rec_admin != null)
                {
                    Session["id_admin"] = rec_admin.Id;
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    if (proprietaire.email != null && proprietaire.password != null)
                    {
                        ViewBag.error = "Email ou mot de passe est incorrect";
                    }
                }
                
                
                return View(proprietaire);

            }
            
        }
        public ActionResult SignUp()
        {
            Session["id_Proprietaire"] = null;
            Session["nom_Proprietaire"] = null;
            Session["id_admin"] = null;

            return View();
        }
        [HttpPost]
        public ActionResult SignUp([Bind(Include = "Nom,Telephone,Ville,Email,Password")] Proprietaire proprietaire)
        {
            var rec = db.Proprietaires.Where(x => x.email == proprietaire.email).ToList().FirstOrDefault();
            if(rec != null)
            {
                ViewBag.error = "E-mail déjà utilisé";
                return View(proprietaire);
            }
            else
            {
                proprietaire.isSpecial = false;
                Proprietaire p= db.Proprietaires.Add(proprietaire);
                Session["id_Proprietaire"] = p.Id_proprietaire;
                Session["nom_Proprietaire"] = rec.nom;
                db.SaveChanges();
                return RedirectToAction("Index", "Proprietaire", new { area = "" });
            }

            
        }
    }
}