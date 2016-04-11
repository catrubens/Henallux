using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.Model
{
    public class Borrower
    {
        public string NameBorrower { get; set; }

        public string FirstNameBorrower { get; set; }

        public string Email { get; set; }

        public string Adresse { get; set; }

        public int NumTelephone { get; set; }

        public Nullable<int> Gsm { get; set; }

        public string Password { get; set; }

        public Borrower()
        { }
    }
}
