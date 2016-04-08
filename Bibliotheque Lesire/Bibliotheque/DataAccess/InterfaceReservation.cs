using Bibliotheque.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.DataAccess
{
    public interface InterfaceReservation
    {
        Task AddReservation(string email, List<Book> list);
    }
}
