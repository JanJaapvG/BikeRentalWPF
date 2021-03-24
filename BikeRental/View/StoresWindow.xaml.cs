using BikeRental.ViewModel;
using System.Windows;

namespace BikeRental.View
{
    /// <summary>
    /// Interaction logic for StoresWindow.xaml
    /// </summary>
    public partial class StoresWindow : Window
    {
        public StoresWindow()
        {
            InitializeComponent();

            DataContext = new StoresWindowViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
