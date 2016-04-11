//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPIBibliotheque.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public book()
        {
            this.reservations = new HashSet<reservation>();
            this.authors = new HashSet<author>();
        }
    
        public string NumBook { get; set; }
        public string Title { get; set; }
        public Nullable<int> YearPublication { get; set; }
        public Nullable<System.DateTime> DateEntry { get; set; }
        public string Editor { get; set; }
        public string Rangement { get; set; }
        public string Statut { get; set; }
        public string CodeCategorie { get; set; }
    
        public virtual categorie categorie { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservation> reservations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<author> authors { get; set; }
    }
}