using BikeRental.Classes;
using BikeRental.Model;
using BikeRental.View;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;

namespace BikeRental.ViewModel
{
    public class MainWindowViewModel
    {
        // db
        private readonly BikeRentalModel _db = new BikeRentalModel();

        //properties
        public Store SelectedStore { get; set; }
        public Bike SelectedBike { get; set; }

        //collection
        public ObservableCollection<Store> AllStores
        {
            get
            {
                _db.Stores.Include(b => b.Bikes).Load();
                return _db.Stores.Local;
            }
            set { }
        }

        public ObservableCollection<Bike> AllBikes
        {
            get
            {
                _db.Bikes.Load();
                return _db.Bikes.Local;
            }
            set { }
        }

        //commands
        public RelayCommand ManageStoreButton { get; set; }
        public RelayCommand ManageBikeButton { get; set; }

        //constructor
        public MainWindowViewModel()
        {
           
            //commands to open stores window and bikes window by calling the methods ManageStore / ManageBike.
            ManageStoreButton = new RelayCommand(ManageStore);
            ManageBikeButton = new RelayCommand(ManageBike);
        }

        //method to open stores window to add, manage or remove stores.
        public void ManageStore(object a)
        {
            StoresWindow storeswindow = new StoresWindow();

            //gives the selected store to the store window if there is one.
            if (SelectedStore != null)
            {
                ((StoresWindowViewModel)storeswindow.DataContext).SelectedStore = SelectedStore;
            }
            ((StoresWindowViewModel)storeswindow.DataContext).Db = _db;
            ((StoresWindowViewModel)storeswindow.DataContext).AllStores = AllStores;

            storeswindow.Show();
        }


        //method to open bikes window to add, manage or remove bikes to / from stores.
        public void ManageBike(object a)
        {
            BikesWindow bikeswindow = new BikesWindow();
            
            // gives the selected bike to the bike window if there is one.
            if(SelectedBike != null)
            {
                ((BikesWindowViewModel)bikeswindow.DataContext).SelectedBike = SelectedBike;
            }
            ((BikesWindowViewModel)bikeswindow.DataContext).Db = _db;
            ((BikesWindowViewModel)bikeswindow.DataContext).AllBikes = AllBikes;
            ((BikesWindowViewModel)bikeswindow.DataContext).AllStores = AllStores;
            ((BikesWindowViewModel)bikeswindow.DataContext).SelectedStore = SelectedStore;
            bikeswindow.Show();
        }

    }
}
