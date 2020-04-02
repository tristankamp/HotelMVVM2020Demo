using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using HotelMVVM2020Demo.Common;
using ModelLibrary;
using Newtonsoft.Json;

namespace HotelMVVM2020Demo.Persistency
{

    public class HotelPersistencyFacade
    {
        private const string URI = "http://localhost:50463/api/hotels";

        public async Task<List<Hotel>> GetHotelsAsync()
        {
            List<Hotel> hoteller = new List<Hotel>();
            using (HttpClient client = new HttpClient())
            {
                string jsonString = await client.GetStringAsync(URI);

                hoteller = JsonConvert.DeserializeObject<List<Hotel>>(jsonString);
            }

            return hoteller;
        }

        public async Task<Hotel> GetHotelAsync(int id)
        {
            Hotel hotel = new Hotel();
            using (HttpClient client = new HttpClient())
            {
                string jsonString = await client.GetStringAsync(URI+"/"+id);

                hotel = JsonConvert.DeserializeObject<Hotel>(jsonString);
            }

            return hotel;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage deleteAsync = await client.DeleteAsync(URI + "/" + id);
                if (deleteAsync.IsSuccessStatusCode)
                {
                    string jsonStr = deleteAsync.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonStr);
                }
                else
                {
                    ok = false;
                }

            }

            return ok;
        }

        public async Task<bool> PostAsync(Hotel hotel)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {

                string jsonString = JsonConvert.SerializeObject(hotel);

                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage postAsync = await client.PostAsync(URI, content);


                if (postAsync.IsSuccessStatusCode)
                {
                    string jsonStr = postAsync.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonStr);
                    
                }
                
                else
                {
                    ok = false;
                }

            }

            return ok;
        }

        public async Task<bool> PutAsync(int id, Hotel hotel)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {

                string jsonString = JsonConvert.SerializeObject(hotel);

                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage putAsync = await client.PutAsync(URI + "/" + id, content);


                if (putAsync.IsSuccessStatusCode)
                {
                    string jsonStr = putAsync.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonStr);
                    
                }
                else
                {
                    ok = false;
                }

            }

            return ok;
        }

    }
}
