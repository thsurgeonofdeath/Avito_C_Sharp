//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP_Projet.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Annonce
    {
        public int Id_annonce { get; set; }
        public Nullable<int> id_proprietaire { get; set; }
        public Nullable<int> id_categorie { get; set; }
        public string titre { get; set; }
        public string image { get; set; }
        public Nullable<double> prix { get; set; }
        public string courteDescription { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<bool> isSpecial { get; set; }
    
        public virtual Categorie Categorie { get; set; }
        public virtual Proprietaire Proprietaire { get; set; }
    }
}