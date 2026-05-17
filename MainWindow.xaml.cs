using OE_Work_App.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OE_Work_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MainViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            MainViewModel = new MainViewModel();

            DataContext = MainViewModel;
        }

        private void AddIngredientBtn_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel.AddIngredient();
        }
    }
}
