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
    
    public partial class Secteur
    {
        public decimal CodeSecteur { get; set; }
        public string Denomination { get; set; }
        public decimal IdEquipe { get; set; }
    
        public virtual EquipeMedicale EquipeMedicale { get; set; }
    }
}