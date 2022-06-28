using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Projet.Models
{
    [MetadataType(typeof(ProprietaireMetaData))]
    public partial class Proprietaire
    {
    }
    public class ProprietaireMetaData
    {
        //proprietaire
        [Display(Name ="Id")]
        [Required(ErrorMessage = "Champ requis")]
        public int Id_proprietaire { get; set; }
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Champ requis")]
        public string nom { get; set; }
        [Display(Name = "Téléphone")]
        [Required(ErrorMessage = "Champ requis")]
        public string telephone { get; set; }
        [Display(Name = "Ville")]
        [Required(ErrorMessage = "Champ requis")]
        public string ville { get; set; }
        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Champ requis")]
        public string email { get; set; }
        [Required(ErrorMessage = "Champ requis")]
        [Display(Name = "Mot de passe")]
        public string password { get; set; }
        [Display(Name = "Spécial")]
        public Nullable<bool> isSpecial { get; set; }

    





    }
}