using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_Projet.Models
{
    [MetadataType(typeof(CategorieMetaData))]

    public partial class Categorie
    {
    }

    public class CategorieMetaData
    {
        [Display(Name ="Id")]
        public int Id_categorie { get; set; }
        [Display(Name ="Catégorie")]
        public string nom { get; set; }

    }
}