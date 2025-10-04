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

namespace WpfApp_Task_9_1_ChangeBackground
{
    public partial class MainWindow : Window
    {
        private readonly Stack<Brush> _colorHistory = new();
        private Brush _currentColor;

        public Brush CurrentColor
        {
            get => _currentColor;
            set
            {
                _currentColor = value;

                // Добавляем новый цвет в стек, если предыдущий цвет не такой же
                // (либо стек пустой) 
                if (_colorHistory.Count == 0 || _colorHistory.Peek() != value)
                {
                    _colorHistory.Push(value);
                }

                MainDock.Background = _currentColor;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            CurrentColor = Brushes.White;
        }

        private void ChangeColorExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var random = new Random();
            CurrentColor = new SolidColorBrush(Color.FromRgb(
                (byte)random.Next(256),
                (byte)random.Next(256),
                (byte)random.Next(256)));
        }

        private void UndoExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (_colorHistory.Count > 1)
            {
                _colorHistory.Pop(); // Удаляем текущий цвет
                CurrentColor = _colorHistory.Peek(); // Берём предыдущий
            }
        }

        private void UndoCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _colorHistory.Count > 1;
        }
    }
}