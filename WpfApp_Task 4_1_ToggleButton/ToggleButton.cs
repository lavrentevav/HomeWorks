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

namespace WpfApp_Task_4_1_ToggleButton
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class ToggleButton : Button
    {
        public static readonly DependencyProperty IsToggledProperty =
            DependencyProperty.Register(
                nameof(IsToggled),
                typeof(bool),
                typeof(ToggleButton),
                new FrameworkPropertyMetadata(
                    false,
                    FrameworkPropertyMetadataOptions.None,
                    OnIsToggledChanged
                )
            );
        public bool IsToggled
        {
            get { return (bool)GetValue(IsToggledProperty); }
            set { SetValue(IsToggledProperty, value); }
        }

        public ToggleButton()
        {
            Click += (sender, e) => IsToggled = !IsToggled;
            UpdateButtonState();
        }

        private static void OnIsToggledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (ToggleButton)d;
            button.UpdateButtonState();
        }
        private void UpdateButtonState()
        {
            Background = IsToggled ? Brushes.Green : Brushes.Red;
            Content = IsToggled ? "ON" : "OFF";
        }
    }
}