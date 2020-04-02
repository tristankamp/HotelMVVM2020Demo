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
    public class GuestCatalogSingleton
    {
        private static GuestCatalogSingleton _instance = null;

        public static GuestCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GuestCatalogSingleton();
                return _instance;
            } 
        }

        public ObservableCollection<Guest> Guests { get; set; }

        private GuestCatalogSingleton()
        {
            Guests = new ObservableCollection<Guest>();
           

            LoadGuests();
        }

        public async void LoadGuests()
        {
            GuestPersistencyFacade GFacade = new GuestPersistencyFacade();
            List<Guest> guests = await GFacade.GetGuestsAsync();
            foreach (Guest guest in guests)
            {
                Guests.Add(guest);
            }
        }
    }
}
