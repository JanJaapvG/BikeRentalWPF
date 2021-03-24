using BikeRental.ViewModel;
using System.Windows;

namespace BikeRental.View
{
    /// <summary>
    /// Interaction logic for BikesWindow.xaml
    /// </summary>
    public partial class BikesWindow : Window
    {
        public BikesWindow()
        {
            InitializeComponent();

            DataContext = new BikesWindowViewModel();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
