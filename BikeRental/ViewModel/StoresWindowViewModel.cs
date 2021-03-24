using BikeRental.Classes;
using BikeRental.Model;
using BikeRental.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows;

namespace BikeRental.ViewModel
{
    public class StoresWindowViewModel : INotifyPropertyChanged
    {
        // db
        public BikeRentalModel Db { get; set; }

        //properties
        private Store _selectedStore;
        public Store Store { get; set; }
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

        //commands
        public RelayCommand AddStoreButton { get; set; }
        public RelayCommand SaveStoreButton { get; set; }
        public RelayCommand RemoveStoreButton { get; set; }

        //constructor
        public StoresWindowViewModel()
        {
            //commands to add or remove objects by calling the methods Addstore / Removstore.
            AddStoreButton = new RelayCommand(AddStore);
            SaveStoreButton = new RelayCommand(SaveStore);
            RemoveStoreButton = new RelayCommand(RemoveStore);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //method to add new store object.
        public void AddStore(object a)
        {
                SelectedStore = new Store()
                {
                    Name = "Naam",
                    Adress = "Adres",
                    City = "Stad"
                };
                AllStores.Add(SelectedStore);

                Db.SaveChanges();
        }

        public void SaveStore(object a)
        {
            Db.SaveChanges();
            MessageBox.Show("Succesfully saved store information!");
        }

        //methods to remove a store object if there is one selected.
        public void RemoveStore(object a)
        {
            if (SelectedStore != null)
            {
                AllStores.Remove(SelectedStore);
                Db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Er moet een winkel geselecteerd worden");
            }
        }

        public void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
