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
    
    public partial class TypeRisque
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeRisque()
        {
            this.examen_en_fonction_du_risque = new HashSet<examen_en_fonction_du_risque>();
            this.TraductionRisques = new HashSet<TraductionRisque>();
            this.TypeExamen_TypeRisque = new HashSet<TypeExamen_TypeRisque>();
        }
    
        public decimal IdRisque { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<examen_en_fonction_du_risque> examen_en_fonction_du_risque { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TraductionRisque> TraductionRisques { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeExamen_TypeRisque> TypeExamen_TypeRisque { get; set; }
    }
}
