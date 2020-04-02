using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMVVM2020Demo.Persistency;
using ModelLibrary;

namespace HotelMVVM2020Demo.Model
{
    public class HotelCatalogSingleton
    {
        private static HotelCatalogSingleton _instance = null;/*new HotelCatalogSingleton();*/

        public static HotelCatalogSingleton Instance
        {
            get {if(_instance == null)
                _instance=new HotelCatalogSingleton();
                return _instance; }
        }

        public ObservableCollection<Hotel> Hotels { get; set; }

        private HotelCatalogSingleton()
        {
            Hotels = new ObservableCollection<Hotel>();
            //Hotel h1 = new Hotel(200,"Hotel 123","Vej 1");
            //Hotel h2 = new Hotel(300, "Hotel 456", "Vej 12");
            //Hotel h3 = new Hotel(400, "Hotel 789", "Vej 13");
            //Hotels.Add(h1);
            //Hotels.Add(h2);
            //Hotels.Add(h3);

            LoadHotels();

        }

        public async void LoadHotels()
        {
            HotelPersistencyFacade facade = new HotelPersistencyFacade();
            List<Hotel> hotels = await facade.GetHotelsAsync();
            foreach (Hotel hotel in hotels)
            {
                Hotels.Add(hotel);
            }
        }
    }
}
