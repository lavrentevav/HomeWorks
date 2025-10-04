using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_Task_11_1_CircleProgressBar
{
    public partial class CircularProgressBar : UserControl
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(0.0, OnValueChanged));

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register(
                nameof(Maximum),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(100.0, OnValueChanged));

        // Read-only Dependency Properties
        private static readonly DependencyPropertyKey ProgressAnglePropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(ProgressAngle),
                typeof(double),
                typeof(CircularProgressBar),
                new PropertyMetadata(0.0));

        public static readonly DependencyProperty ProgressAngleProperty = ProgressAnglePropertyKey.DependencyProperty;

        private static readonly DependencyPropertyKey PercentageTextPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(PercentageText),
                typeof(string),
                typeof(CircularProgressBar),
                new PropertyMetadata("0%"));

        public static readonly DependencyProperty PercentageTextProperty = PercentageTextPropertyKey.DependencyProperty;

        private static readonly DependencyPropertyKey ArcEndPointPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(ArcEndPoint),
                typeof(Point),
                typeof(CircularProgressBar),
                new PropertyMetadata(new Point(50, 95)));

        public static readonly DependencyProperty ArcEndPointProperty = ArcEndPointPropertyKey.DependencyProperty;

        private static readonly DependencyPropertyKey IsLargeArcPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(IsLargeArc),
                typeof(bool),
                typeof(CircularProgressBar),
                new PropertyMetadata(false));

        public static readonly DependencyProperty IsLargeArcProperty = IsLargeArcPropertyKey.DependencyProperty;

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public double Maximum
        {
            get => (double)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public double ProgressAngle
        {
            get => (double)GetValue(ProgressAngleProperty);
            private set => SetValue(ProgressAnglePropertyKey, value);
        }

        public string PercentageText
        {
            get => (string)GetValue(PercentageTextProperty);
            private set => SetValue(PercentageTextPropertyKey, value);
        }

        public Point ArcEndPoint
        {
            get => (Point)GetValue(ArcEndPointProperty);
            private set => SetValue(ArcEndPointPropertyKey, value);
        }

        public bool IsLargeArc
        {
            get => (bool)GetValue(IsLargeArcProperty);
            private set => SetValue(IsLargeArcPropertyKey, value);
        }

        public CircularProgressBar()
        {
            InitializeComponent();
            UpdateProgress();
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var progressBar = (CircularProgressBar)d;
            progressBar.UpdateProgress();
        }

        private void UpdateProgress()
        {
            // Ограничиваем значения
            if (Value < 0) Value = 0;
            if (Value > Maximum) Value = Maximum;
            if (Maximum <= 0) Maximum = 100;

            // Количество оборотов стартовой точки дуги
            int turnsNumber = 5;

            // Вычисляем прогресс
            double percentage = Maximum == 0 ? 0 : (Value / Maximum);
            ProgressAngle = 360 * percentage * turnsNumber;
            PercentageText = $"{(percentage * 100):F0}%";

            // Вычисляем конечную точку дуги для эффекта заполнения
            CalculateArcEndPoint(percentage);
        }

        private void CalculateArcEndPoint(double percentage)
        {
            // чтобы при 100% не происходил сброс шкалы
            double calculatedPercentage = Math.Min(0.9999999, percentage);

            double angle = 2 * Math.PI * calculatedPercentage + Math.PI / 2;

            double centerX = 50;
            double centerY = 50;
            double radius = 45;

            double endX = centerX + radius * Math.Cos(angle);
            double endY = centerY + radius * Math.Sin(angle);

            ArcEndPoint = new Point(endX, endY);

            // Определяем, является ли дуга большой (более 180 градусов)
            IsLargeArc = percentage > 0.5;
        }
    }
}