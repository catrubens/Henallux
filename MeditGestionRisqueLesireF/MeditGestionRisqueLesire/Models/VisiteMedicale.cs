//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MeditGestionRisqueLesire.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VisiteMedicale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VisiteMedicale()
        {
            this.ExamenRealises = new HashSet<ExamenRealise>();
        }
    
        public decimal NumeroVisite { get; set; }
        public System.DateTime DateVisite { get; set; }
        public decimal IdEmploi { get; set; }
        public decimal IdLieu { get; set; }
    
        public virtual Emploi Emploi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamenRealise> ExamenRealises { get; set; }
        public virtual Lieu Lieu { get; set; }
    }
}
