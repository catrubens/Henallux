using Bibliotheque.Exceptions;
using Bibliotheque.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;

namespace Bibliotheque.DataAccess
{
    public class BorrowerAccess : InterfaceBorrower
    {
        private HttpClient client;
        private String borrowerAccount = "http://bibliotheque.azurewebsites.net/api/borrowers/searchBorroxerByEmail/?email=";

        public BorrowerAccess()
        {
            client = new HttpClient();
        }

        public async Task<bool> VerifiyLoginAsync(string email, string password)
        {
            client.BaseAddress = new Uri(borrowerAccount + email);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var borrowerResponse = JsonConvert.DeserializeObject<Borrower>(json);

                var pwd = cryptPassword(password);

                if (pwd.Equals(borrowerResponse.Password))
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                    string str = loader.GetString("Login_PWD_Wrong");
                    throw new WrongEmailPwdException(str);
                }
                else
                {
                    var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                    string str = loader.GetString("noNetwork");
                    throw new NoNetworkException(str);
                }
            }
        }

        private string cryptPassword(string passwordEncryption)
        {
            String strAlgName = HashAlgorithmNames.Sha512;
            HashAlgorithmProvider objAlgProv = HashAlgorithmProvider.OpenAlgorithm(strAlgName);
            CryptographicHash objHash = objAlgProv.CreateHash();
            IBuffer buffMsg1 = CryptographicBuffer.ConvertStringToBinary(passwordEncryption, BinaryStringEncoding.Utf16BE);
            objHash.Append(buffMsg1);
            IBuffer buffHash1 = objHash.GetValueAndReset();

            return CryptographicBuffer.EncodeToBase64String(buffHash1);
        }
    }
}
