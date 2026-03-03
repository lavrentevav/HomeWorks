using RevitAPI_Task_10_1_TreePlacement.ViewModels;
using System.Windows;

namespace RevitAPI_Task_10_1_TreePlacement.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            DataContext = mainWindowViewModel;
            InitializeComponent();
        }
    }
}
