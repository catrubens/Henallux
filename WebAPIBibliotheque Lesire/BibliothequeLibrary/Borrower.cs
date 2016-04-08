using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeLibrary
{
    public class Borrower
    {
        private string nameBorrower;
        public string NameBorrower { get; set; }

        private string firstNameBorrower;
        public string FirstNameBorrower { get; set; }

        private string email;
        public string Email { get; set; }

        private string adresse;
        public string Adresse { get; set; }

        private int numTelephone;
        public int NumTelephone { get; set; }

        private Nullable<int> gsm;
        public Nullable<int> Gsm { get; set; }

        private string password;
        public string Password { get; set; }

        public Borrower()
        { }
    }
}
