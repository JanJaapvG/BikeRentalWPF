using System.ComponentModel;

namespace BikeRental.Model
{
    public enum Category
    {
        Mountainbike,
        Racefiets,
        Stadsfiets,
        Elektrischefiets
    }

    public enum BikeSize
    { 
        Small,
        Medium,
        Large,
        ExtraLarge
    }

    public class Bike : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private string _description;
        private string _brand;
        private double _hourRate;
        private double _dailyRate;
        private Category _type;
        private Gender _gender;
        private BikeSize _bikeSize;

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

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                Notify("Description");
            }
        }

        public string Brand 
        { 
            get => _brand;
            set
            {
                _brand = value;
                Notify("Brand");
            }
        }

        public double HourRate
        {
            get => _hourRate;
            set
            {
                _hourRate = value;
                Notify("HourRate");
            }
        }

        public double DailyRate
        {
            get => _dailyRate;
            set
            {
                _dailyRate = value;
                Notify("DailyRate");
            }
        }

        public Category Type
        {
            get => _type;
            set
            {
                _type = value;
                Notify("Category");
            }
        }

        public Gender Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                Notify("Gender");
            }
        }

        public BikeSize BikeSize
        {
            get => _bikeSize;
            set
            {
                _bikeSize = value;
                Notify("Size");
            }
        }
        
        public Store Store { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
