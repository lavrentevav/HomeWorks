using RevitAPI_Task_8_1_InspectWalls.ViewModels;
using System.Windows;

namespace RevitAPI_Task_8_1_InspectWalls.Views
{
    /// <summary>
    /// Главное окно приложения инспекции стен.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Создаёт экземпляр главного окна с указанной моделью представления.
        /// </summary>
        /// <param name="mainWindowViewModel">Модель представления главного окна.</param>
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = mainWindowViewModel;
        }
    }
}
