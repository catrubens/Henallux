using Bibliotheque.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.DataAccess
{
    public interface InterfaceBook
    {
       Task<ObservableCollection<Book>> GetBookSearch(string word, string categorie);
       Task<ObservableCollection<Book>> GetBook30LastDays();
    }
}
