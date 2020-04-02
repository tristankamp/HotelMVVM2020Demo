using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HotelMVVM2020Demo.Common;
using ModelLibrary;
using Newtonsoft.Json;

namespace HotelMVVM2020Demo.Persistency
{
    public class GuestPersistencyFacade
    {
        private const string URI = "http://localhost:50463/api/guest";
        public async Task<List<Guest>> GetGuestsAsync()
        {
            List<Guest> guests = new List<Guest>();
            using (HttpClient client = new HttpClient())
            {
                string jsonString = await client.GetStringAsync(URI);

                guests = JsonConvert.DeserializeObject<List<Guest>>(jsonString);
            }

            return guests;
        }

        public async Task<Guest> GetGuestAsync()
        {
            Guest guest = new Guest();
            using (HttpClient client = new HttpClient())
            {
                string jsonString = await client.GetStringAsync(URI);

                guest = JsonConvert.DeserializeObject<Guest>(jsonString);
            }

            return guest;
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

        public async Task<bool> PostAsync(Guest guest)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {

                string jsonString = JsonConvert.SerializeObject(guest);

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

        public async Task<bool> PutAsync(int id, Guest guest)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {

                string jsonString = JsonConvert.SerializeObject(guest);

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
