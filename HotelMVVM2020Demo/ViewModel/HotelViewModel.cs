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
    public class HotelViewModel:INotifyPropertyChanged
    {
        public HotelCatalogSingleton HotelCatalogSingleton { get; set; }

        public HotelViewModel()
        {
            HotelCatalogSingleton = HotelCatalogSingleton.Instance;
            _newHotel = new Hotel();
            HotelHandler = new HotelHandler(this);
            CreateHotelCommand = new RelayCommand(HotelHandler.CreateHotel);
            DeleteHotelCommand= new RelayCommand(HotelHandler.DeleteHotel, (() => NewHotel != null && NewHotel.Id != 0 ));
            UpdateHotelCommand = new RelayCommand(HotelHandler.UpdateHotel);
            ClearHotelCommand = new RelayCommand(HotelHandler.ClearHotel);
        }

        public HotelHandler HotelHandler { get; set; }

        private Hotel _newHotel;

        public Hotel NewHotel
        {
            get { return _newHotel; }
            set { _newHotel = value; OnPropertyChanged(); ((RelayCommand)DeleteHotelCommand).RaiseCanExecuteChanged();  }
        }

        public ICommand CreateHotelCommand { get; set; }
        public ICommand DeleteHotelCommand { get; set; }

        public ICommand UpdateHotelCommand { get; set; }

        public ICommand ClearHotelCommand { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
