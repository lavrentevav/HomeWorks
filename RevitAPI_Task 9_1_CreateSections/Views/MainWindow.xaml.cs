using RevitAPI_Task_9_1_CreateSections.ViewModels;
using System;
using System.Windows;

namespace RevitAPI_Task_9_1_CreateSections.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Инициализирует новый экземпляр главного окна.
        /// </summary>
        /// <param name="mainWindowViewModel">Модель представления главного окна.</param>
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            DataContext = mainWindowViewModel;
            InitializeComponent();
        }
    }
}
