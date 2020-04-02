using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelMVVM2020Demo.Annotations;
using HotelMVVM2020Demo.Common;
using HotelMVVM2020Demo.Handler;
using HotelMVVM2020Demo.Model;
using ModelLibrary;

namespace HotelMVVM2020Demo.ViewModel
{
    public class GuestViewModel:INotifyPropertyChanged
    {
        public GuestCatalogSingleton GuestCatalogSingleton { get; set; }

        public GuestViewModel()
        {
            GuestCatalogSingleton = GuestCatalogSingleton.Instance;
            _newGuest = new Guest();
            GuestHandler = new GuestHandler(this);
            CreateGuestCommand = new RelayCommand(GuestHandler.CreateGuest);
            UpdateGuestCommand = new RelayCommand(GuestHandler.UpdateGuest);
            DeleteGuestCommand = new RelayCommand(GuestHandler.DeleteGuest, (() => NewGuest != null && NewGuest.Id != 0));
            ClearGuestCommand = new RelayCommand(GuestHandler.ClearGuest);

        }

        private Guest _newGuest;
        public Guest NewGuest
        {
            get { return _newGuest; }
            set { _newGuest = value; OnPropertyChanged(); ((RelayCommand)DeleteGuestCommand).RaiseCanExecuteChanged(); }
        }

        public GuestHandler GuestHandler { get; set; }

        public ICommand CreateGuestCommand { get; set; }

        public ICommand UpdateGuestCommand { get; set; }
        public ICommand DeleteGuestCommand { get; set; }
        public ICommand ClearGuestCommand { get; set; }




        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
