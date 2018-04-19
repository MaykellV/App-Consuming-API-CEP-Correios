using System;
using System.Net;
using System.Net.Http;
using AppConsultaCep.Model;
using Newtonsoft.Json;

namespace AppConsultaCep.Service
{
    public class ViaCepService
    {
        private static string addressURL = "http://viacep.com.br/ws/{0}/json";

        public static Address SearchAddressToCep(string cep)
        {
            addressURL = String.Format(addressURL, cep);
            HttpClient httpClient = new HttpClient();

            var response = httpClient.GetAsync(addressURL).Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result ;
                string addressResult = content;

                Address address = JsonConvert.DeserializeObject<Address>(addressResult);

                return address;
            }

            return null;
        }
    }
}
