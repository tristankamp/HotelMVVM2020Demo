using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMVVM2020Demo.Common;
using HotelMVVM2020Demo.Model;
using HotelMVVM2020Demo.Persistency;
using HotelMVVM2020Demo.ViewModel;
using ModelLibrary;

namespace HotelMVVM2020Demo.Handler
{
    public class GuestHandler
    {
        private GuestViewModel GuestViewModel;

        public GuestHandler(GuestViewModel guestviewmodel)
        {
            GuestViewModel = guestviewmodel;
        }

        public async void CreateGuest()
        {
            int guestNo = GuestViewModel.NewGuest.Id;
            string guestName = GuestViewModel.NewGuest.Name;
            string guestAddress = GuestViewModel.NewGuest.Address;

            Guest aGuest = new Guest(guestNo,guestName,guestAddress);

            GuestPersistencyFacade Gfacade = new GuestPersistencyFacade();

            bool ok = await Gfacade.PostAsync(aGuest);

            if (!ok)
            {
                MessageDialogHelper.Show("Der skete en fejl", $"Gæsten {aGuest.Name} blev ikke oprettet, check ID");
            }
            else
            {
                MessageDialogHelper.Show("Alt gik godt", $"Gæsten {aGuest.Name} blev oprettet");
                GuestViewModel.GuestCatalogSingleton.Guests.Clear();
                GuestViewModel.GuestCatalogSingleton.LoadGuests();
            }

        }

        public async void DeleteGuest()
        {
            int guestNo = GuestViewModel.NewGuest.Id;
            string guestName = GuestViewModel.NewGuest.Name;
            string guestAddress = GuestViewModel.NewGuest.Address;

            Guest aGuest = new Guest(guestNo, guestName, guestAddress);

            GuestPersistencyFacade Gfacade = new GuestPersistencyFacade();

            bool ok = await Gfacade.DeleteAsync(aGuest.Id);

            if (!ok)
            {
                MessageDialogHelper.Show("Der skete en fejl", $"Gæsten {aGuest.Name} blev ikke slettet, eksisterer ID'et i databasen?");
            }
            else
            {
                MessageDialogHelper.Show("Alt gik godt", $"Gæsten {aGuest.Name} blev slettet");
                GuestViewModel.GuestCatalogSingleton.Guests.Clear();
                GuestViewModel.GuestCatalogSingleton.LoadGuests();
                GuestViewModel.NewGuest = new Guest();
            }

        }

        public async void UpdateGuest()
        {
            int guestNo = GuestViewModel.NewGuest.Id;
            string guestName = GuestViewModel.NewGuest.Name;
            string guestAddress = GuestViewModel.NewGuest.Address;

            Guest aGuest = new Guest(guestNo, guestName, guestAddress);

            GuestPersistencyFacade Gfacade = new GuestPersistencyFacade();

            bool ok = await Gfacade.PutAsync(aGuest.Id, aGuest);

            if (!ok)
            {
                MessageDialogHelper.Show("Der skete en fejl", $"Gæsten {aGuest.Name} blev ikke opdateret, du har muligvis samme ID som en i databasen");
            }
            else
            {
                MessageDialogHelper.Show("Alt gik godt", $"Gæsten {aGuest.Name} blev opdateret");
                GuestViewModel.GuestCatalogSingleton.Guests.Clear();
                GuestViewModel.GuestCatalogSingleton.LoadGuests();
            }

        }

        public async void ClearGuest()
        {
            int guestNo = 0;
            string guestName = "";
            string guestAddress = "";

            Guest aGuest = new Guest(guestNo, guestName, guestAddress);

            GuestPersistencyFacade Gfacade = new GuestPersistencyFacade();

            GuestViewModel.NewGuest = aGuest;


        }

    }
}
