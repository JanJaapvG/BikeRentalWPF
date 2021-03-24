using BikeRental.View;
using BikeRental.ViewModel;
using System.Windows;

namespace BikeRental
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }

    }
}
