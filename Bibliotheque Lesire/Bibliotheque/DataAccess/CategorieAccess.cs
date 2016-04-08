using Bibliotheque.Exceptions;
using Bibliotheque.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.DataAccess
{
    public class CategorieAccess : InterfaceCategorie
    {
        private HttpClient client;
        private String allCategorie = "http://bibliotheque.azurewebsites.net/api/categories";

        public CategorieAccess()
        {
            client = new HttpClient();
        }

        public async Task<ObservableCollection<Categorie>> GetCategories()
        {
            client.BaseAddress = new Uri(allCategorie);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var categoriesResponse = JsonConvert.DeserializeObject<Categorie[]>(json);
                ObservableCollection<Categorie> listCategories = new ObservableCollection<Categorie>();

                foreach (var c in categoriesResponse)
                {
                    Categorie categorie = new Categorie();
                    categorie.CodeCategorie = c.CodeCategorie;
                    categorie.LibelleCategorie = c.LibelleCategorie;
                    listCategories.Add(categorie);
                }
                return listCategories;
            }
            else
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                string str = loader.GetString("noNetwork");
                throw new NoNetworkException(str);
            }
        }
    }
}
