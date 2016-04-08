using Bibliotheque.Exceptions;
using Bibliotheque.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.DataAccess
{
    public class ReservationAccess : InterfaceReservation
    {
        private HttpClient client;
        private String addReservation = "http://bibliotheque.azurewebsites.net/api/reservations/addReservation/?email=";       

        public ReservationAccess()
        {
            client = new HttpClient();
        }

        public async Task AddReservation(string email,List<Book> list)
        {
            List<String> listNumBook = new List<string>();

            foreach(var book in list)
            {
                listNumBook.Add(book.NumBook);
            }

            var listeJSONBook = Newtonsoft.Json.JsonConvert.SerializeObject(listNumBook);
            var linkForPost = Newtonsoft.Json.JsonConvert.SerializeObject("");

            HttpContent content = new StringContent(linkForPost, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = await client.PostAsync(addReservation + email + "&content=" + listeJSONBook, content);

            if (reponse.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                string str = loader.GetString("noNetwork");
                throw new NoNetworkException(str);
            }
            else
            {
                if (reponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                    string str = loader.GetString("errorAddReseration");
                    throw new ErrorData(str);
                }
            }
        }
    }
}
