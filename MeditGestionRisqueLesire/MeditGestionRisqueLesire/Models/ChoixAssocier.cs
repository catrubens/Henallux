using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeditGestionRisqueLesire.Models
{
    public class ChoixAssocier
    {
        public decimal Id { get; set; }
        public string Travailleur { get; set; }
        public decimal IdEntreprise { get; set; }
        public string StringEmploi { get; set; }
    }
}