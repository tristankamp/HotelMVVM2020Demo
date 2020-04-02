using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using HotelMVVM2020Demo.Common;
using HotelMVVM2020Demo.Persistency;
using HotelMVVM2020Demo.ViewModel;
using ModelLibrary;

namespace HotelMVVM2020Demo.Handler
{
    public class HotelHandler
    {
        private HotelViewModel HotelViewModel;

        public HotelHandler(HotelViewModel hotelviewmodel)
        {
            HotelViewModel = hotelviewmodel;
        }

        public async void CreateHotel()
        {
            int hotelNr = HotelViewModel.NewHotel.Id;
            string hotelName = HotelViewModel.NewHotel.Name;
            string hotelAddress = HotelViewModel.NewHotel.Address;

            Hotel aHotel = new Hotel(hotelNr,hotelName,hotelAddress);

            HotelPersistencyFacade facade = new HotelPersistencyFacade();
            bool ok = await facade.PostAsync(aHotel);
            if (!ok)
            {
                MessageDialogHelper.Show("Der skete en fejl", $"Hotellet {aHotel.Name} blev ikke oprettet, du har muligvis samme ID som en i databasen");
            }
            else
            {
                MessageDialogHelper.Show("Alt gik godt", $"Hotellet {aHotel.Name} blev oprettet");
                HotelViewModel.HotelCatalogSingleton.Hotels.Clear();
                HotelViewModel.HotelCatalogSingleton.LoadHotels();
            }
        }

        public async void DeleteHotel()
        {
            int hotelNr = HotelViewModel.NewHotel.Id;
            string hotelName = HotelViewModel.NewHotel.Name;
            string hotelAddress = HotelViewModel.NewHotel.Address;

            Hotel aHotel = new Hotel(hotelNr, hotelName, hotelAddress);

            HotelPersistencyFacade facade = new HotelPersistencyFacade();

            bool ok = await facade.DeleteAsync(aHotel.Id);

            if (!ok)
            {
                MessageDialogHelper.Show("Der skete en fejl", $"Hotellet {aHotel.Name} blev ikke slettet, eksisterer ID'et i databasen?");
            }
            else
            {
                MessageDialogHelper.Show("Alt gik godt", $"Hotellet {aHotel.Name} blev slettet");
                HotelViewModel.HotelCatalogSingleton.Hotels.Clear();
                HotelViewModel.HotelCatalogSingleton.LoadHotels();
                HotelViewModel.NewHotel = new Hotel();
            }
        }

        public async void UpdateHotel()
        {
            int hotelNr = HotelViewModel.NewHotel.Id;
            string hotelName = HotelViewModel.NewHotel.Name;
            string hotelAddress = HotelViewModel.NewHotel.Address;

            Hotel aHotel = new Hotel(hotelNr, hotelName, hotelAddress);

            HotelPersistencyFacade facade = new HotelPersistencyFacade();
            bool ok = await facade.PutAsync(aHotel.Id,aHotel);
            if (!ok)
            {
                MessageDialogHelper.Show("Der skete en fejl", $"Hotellet {aHotel.Name} blev ikke opdateret, eksisterer ID'et i databasen?");
            }
            else
            {
                MessageDialogHelper.Show("Alt gik godt", $"Hotellet {aHotel.Name} blev opdateret");
                HotelViewModel.HotelCatalogSingleton.Hotels.Clear();
                HotelViewModel.HotelCatalogSingleton.LoadHotels();
            }
        }

        public async void ClearHotel()
        {
            int hotelNr = 0;
            string hotelName = "";
            string hotelAddress = "";

            Hotel aHotel = new Hotel(hotelNr, hotelName, hotelAddress);

            HotelPersistencyFacade facade = new HotelPersistencyFacade();
            HotelViewModel.NewHotel = aHotel;
            
            
        }

    }
}
