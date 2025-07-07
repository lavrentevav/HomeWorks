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

namespace WpfApp_Task_1_3_RunawayButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random _rnd = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RunawayButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;

            // Расчёт доступного пространства для кнопки
            double gridWidth = MainGrid.ActualWidth - button.ActualWidth;
            double gridHeight = MainGrid.ActualHeight - button.ActualHeight;

            // Генерируем случайные координаты
            double newX = _rnd.Next(0, 101) / 100.0 * gridWidth;
            double newY = _rnd.Next(0, 101) / 100.0 * gridHeight;

            // Устанавливаем новые координаты кнопки
            button.Margin = new Thickness(newX, newY, 0, 0);
            button.HorizontalAlignment = HorizontalAlignment.Left;
            button.VerticalAlignment = VerticalAlignment.Top;
        }
    }
}