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
    
    public partial class borrower
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public borrower()
        {
            this.reservations = new HashSet<reservation>();
        }
    
        public string NameBorrower { get; set; }
        public string FirstNameBorrower { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public int NumTelephone { get; set; }
        public Nullable<int> GSM { get; set; }
        public string Password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reservation> reservations { get; set; }
    }
}