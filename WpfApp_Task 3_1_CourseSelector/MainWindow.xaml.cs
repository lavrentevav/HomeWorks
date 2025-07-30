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

namespace WpfApp_Task_3_1_CourseSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HoursSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (HoursTextBlock != null)
            {
                int hours = (int)HoursSlider.Value;
                HoursTextBlock.Text = $"{hours} часов";
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!AgreementCheckBox.IsChecked ?? false)
            {
                MessageBox.Show("Для записи необходимо согласие на обработку персональных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(StudentNameTextBox.Text))
            {
                MessageBox.Show("Введите имя студента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (FacultyComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите факультет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (CoursesListBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один курс", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string selectedCourses = string.Join(", ", CoursesListBox.SelectedItems.Cast<ListBoxItem>().Select(item => item.Content.ToString()));
            string studyForm = FullTimeRadio.IsChecked == true ? "очно" : "заочно";

            string message = $"Студент: {StudentNameTextBox.Text}\n" +
                             $"Факультет: {FacultyComboBox.Text}\n" +
                             $"Форма обучения: {studyForm}\n" +
                             $"Часов в неделю: {HoursSlider.Value}\n" +
                             $"Выбранные курсы: {selectedCourses}";

            MessageBox.Show(message, "Информация о записи", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}