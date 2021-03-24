using BikeRental.Classes;
using BikeRental.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;

namespace BikeRental.ViewModel
{
    public class BikesWindowViewModel : INotifyPropertyChanged
    {
        // db
        public BikeRentalModel Db { get; set; }

        //properties
        private Bike _selectedBike;
        public Bike SelectedBike
        {
            get => _selectedBike;
            set
            {
                _selectedBike = value;
                Notify("SelectedBike");
            }
        }

        private Store _selectedStore;
        public Store SelectedStore
        {
            get => _selectedStore;
            set
            {
                _selectedStore = value;
                Notify("SelectedStore");
            }
        }

        //collections
        public ObservableCollection<Store> AllStores { get; set; }
        public ObservableCollection<Bike> AllBikes { get; set; }

        //commands
        public RelayCommand AddBikeButton { get; set; }
        public RelayCommand SaveBikeButton { get; set; }
        public RelayCommand RemoveBikeButton { get; set; }

        //constructor
        public BikesWindowViewModel()
        {
            //commands to add or remove bike objects by calling the methods AddBike / RemoveBike.
            AddBikeButton = new RelayCommand(AddBike);
            SaveBikeButton = new RelayCommand(SaveBike);
            RemoveBikeButton = new RelayCommand(RemoveBike);
        }

        //method to add a bike object if there is a store selected with less than 5 bikes.
        public void AddBike(object a)
        {
            if (SelectedStore != null && SelectedStore.MaxCapacity < 5)
            {
                SelectedBike = new Bike()
                {
                    Name = "Naam",
                    Description = "Beschrijving",
                    Brand = "Merk"
                };

                SelectedStore.Bikes.Add(SelectedBike);
                SelectedStore.MaxCapacity++;
 
                Db.SaveChanges();
            }
            else if (SelectedStore == null) {
                MessageBox.Show("Er moet een winkel geselecteerd worden");
            } 
            else if (SelectedStore.MaxCapacity == 5)
            {
                MessageBox.Show("Er kunnen maar 5 fietsen in deze winkel"); 
            }
            else
            {
                MessageBox.Show("Er is een onbekend probleem opgetreden");
            }
        }

        public void SaveBike(object a)
        {
            Db.SaveChanges();
            MessageBox.Show("Succesfully saved bike information!");
        }
    

        //method to remove bike objects from a store if there is one selected.
        public void RemoveBike(object a)
        {
            if (SelectedStore != null && SelectedBike != null)
            {
                SelectedStore.MaxCapacity--;
                AllBikes.Remove(SelectedBike);

                Db.SaveChanges();
            }
            else if (SelectedStore == null)
            {
                MessageBox.Show("Er moet een winkel geselecteerd worden");
            }
            else if (SelectedBike == null)
            {
                MessageBox.Show("Er moet een fiets geselecteerd worden");
            }
            else
            {
                MessageBox.Show("Er is een onbekend probleem opgetreden");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
