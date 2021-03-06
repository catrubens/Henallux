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
    using System.ComponentModel.DataAnnotations;

    public partial class Emploi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Emploi()
        {
            this.VisiteMedicales = new HashSet<VisiteMedicale>();
            this.examen_particulier = new HashSet<examen_particulier>();
            this.examen_en_fonction_du_risque = new HashSet<examen_en_fonction_du_risque>();
        }
    
        public decimal IdEmploi { get; set; }
        public string TypeTravail { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime DateEntree { get; set; }
        public decimal Numero { get; set; }
        public decimal IdTravailleur { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateSortie { get; set; }
        public string CodeAlpha { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisiteMedicale> VisiteMedicales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<examen_particulier> examen_particulier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<examen_en_fonction_du_risque> examen_en_fonction_du_risque { get; set; }
        public virtual Travailleur Travailleur { get; set; }
        public virtual Entreprise Entreprise { get; set; }
        public virtual Profession Profession { get; set; }
    }
}
