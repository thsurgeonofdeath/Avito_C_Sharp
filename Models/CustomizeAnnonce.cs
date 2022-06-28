using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Projet.Models
{
    [MetadataType(typeof(AnnonceMetaData))]
    public partial class Annonce
    {
    }
    public class AnnonceMetaData
    {
        public int Id_annonce { get; set; }
        public Nullable<int> id_proprietaire { get; set; }
        public Nullable<int> id_categorie { get; set; }
        [Display(Name ="Titre")]
        public string titre { get; set; }
        [Display(Name = "Image")]
        public string image { get; set; }
        [Display(Name = "Prix")]
        public Nullable<double> prix { get; set; }
        [Display(Name = "Courte description")]
        public string courteDescription { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> date { get; set; }
        [Display(Name = "Spécial")]
        public Nullable<bool> isSpecial { get; set; }

    }
}