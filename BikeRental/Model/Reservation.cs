using System;
using System.ComponentModel;

namespace BikeRental.Model
{
    public class Reservation : INotifyPropertyChanged
    {
        private int _id;
        private Customer _customer;
        private Bike _bike;
        private Store _pickupStore;
        private Store _dropoffStore;
        private DateTime _start;
        private DateTime _end;
        private double _totalPrice;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                Notify("Id");
            }
        }

        public virtual Customer Customer {
            get => _customer;
            set
            {
                _customer = value;
                Notify("Customer");
            }
        }

        public virtual Bike Bike {
            get => _bike;
            set
            {
                _bike = value;
                Notify("Bike");
            }
        }

        public virtual Store PickupStore {
            get => _pickupStore;
            set
            {
                _pickupStore = value;
                Notify("PickupStore");
            }
        }

        public virtual Store DropoffStore
        {
            get => _dropoffStore;
            set
            {
                _dropoffStore = value;
                Notify("DropoffStore");
            }
        }

        public DateTime Start { 
            get => _start;
            set
            {
                _start = value;
                Notify("Start");
            }
        }

        public DateTime End
        {
            get => _end;
            set
            {
                _end = value;
                Notify("End");
            }
        }
        public double TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                Notify("TotalPrice");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //Method for notifying changes in properties
        public void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
