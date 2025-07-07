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

namespace WpfApp_Task_1_2_TrafficLight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _currentState = 0; // 0 - зелёный, 1 - желтый, 2 - красный, 3 - красный с жёлтым

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            // Переключаем состояние
            _currentState++;
            if (_currentState > 3)
                _currentState = 0;

            // Сбрасываем все цвета на серый
            redLight.Fill = Brushes.Gray;
            yellowLight.Fill = Brushes.Gray;
            greenLight.Fill = Brushes.Gray;

            // Устанавливаем цвет в зависимости от состояния
            switch (_currentState)
            {
                case 0:
                    greenLight.Fill = Brushes.Green;
                    break;                    
                case 1:
                    yellowLight.Fill = Brushes.Yellow;
                    break;
                case 2:
                    redLight.Fill = Brushes.Red;
                    break;
                case 3:
                    yellowLight.Fill = Brushes.Yellow;
                    redLight.Fill = Brushes.Red;
                    break;
            }
        }
    }
}