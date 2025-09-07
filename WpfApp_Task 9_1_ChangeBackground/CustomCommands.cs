using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp_Task_9_1_ChangeBackground
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand ChangeColor = new(
            "Изменить цвет",
            "ChangeColor",
            typeof(CustomCommands),
            [
                new KeyGesture(Key.C, ModifierKeys.Control)
            ]);
    }
}
