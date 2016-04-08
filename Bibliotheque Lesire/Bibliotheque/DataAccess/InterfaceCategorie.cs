using Bibliotheque.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.DataAccess
{
    public interface InterfaceCategorie
    {
        Task<ObservableCollection<Categorie>> GetCategories();
    }
}
