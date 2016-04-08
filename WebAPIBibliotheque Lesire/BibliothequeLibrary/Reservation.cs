using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeLibrary
{
    public class Reservation
    {
        private int numReservation;
        public int NumeReservation { get; set; }

        private DateTime dateReservation;
        public DateTime DateReservation { get; set; }

        private string email;
        public string Email { get; set; }

        private Borrower borrower;
        public Borrower Borrower;

        public Reservation()
        {
            borrower = new Borrower();
        }
    }
}
