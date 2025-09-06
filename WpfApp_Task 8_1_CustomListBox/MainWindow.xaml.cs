using System.Collections.ObjectModel;
using System.Globalization;
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

namespace WpfApp_Task_8_1_CustomListBox
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; }

        public MainWindow()
        {
            InitializeComponent();
            Products =
            [
                new Product("Холодильник", 45000.00m, "images/fridge.jpg", ProductCategory.HouseholdEquipment),
                new Product("Яблоки", 140.00m, "images/apple.jpg", ProductCategory.Food),
                new Product("Бананы", 160.00m, "images/banana.jpg", ProductCategory.Food)
            ];
            DataContext = this;
        }        
    }
}
