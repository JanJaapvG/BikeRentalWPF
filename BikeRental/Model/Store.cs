using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BikeRental.Model
{
    public class Store : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _adress;
        private string _city;
        private int _maxCapacity;
        private ObservableCollection<Bike> _bikes;
        private ObservableCollection<Reservation> _reservations;
        private ObservableCollection<Customer> _customers;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                Notify("Id");
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Notify("Name");
            }
        }

        public string Adress
        {
            get => _adress;
            set
            {
                _adress = value;
                Notify("Adress");
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                Notify("City");
            }
        }

        public int MaxCapacity
        {
            get => _maxCapacity;
            set
            {
                _maxCapacity = value;
                Notify("MaxCapacity");
            }
        }

        // List of bikes for rent at a store.
        public virtual ObservableCollection<Bike> Bikes
        {
            get => _bikes;
            set
            {
                _bikes = value;
                Notify("Bikes");
            }
        }

        //List with reservations made in a store.
        public virtual ObservableCollection<Reservation> Reservations
        {
            get => _reservations;
            set
            {
                _reservations = value;
                Notify("Reservations");
            }
        }

        // List with Customers linked to a store.
        public virtual ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                Notify("Customers");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        //Method for notifying changes in properties
        public void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Store()
        {
            Bikes = new ObservableCollection<Bike>();
            Customers = new ObservableCollection<Customer>();
            Reservations = new ObservableCollection<Reservation>();
        }
    }
}
