using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAPI_Task_9_1_CreateSections.Abstractions;
using RevitAPI_Task_9_1_CreateSections.ViewModels;
using RevitAPI_Task_9_1_CreateSections.Views;
using Microsoft.Extensions.DependencyInjection;
using RevitAPI_Task_9_1_CreateSections.Services;

namespace RevitAPI_Task_9_1_CreateSections
{
    /// <summary>
    /// Команда Revit для создания трёх разрезов по выбранному семейству.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class Cmd : IExternalCommand
    {
        /// <summary>
        /// Точка входа внешней команды Revit.
        /// </summary>
        /// <param name="commandData">Данные внешней команды Revit.</param>
        /// <param name="message">Сообщение об ошибке, если выполнение завершилось неудачно.</param>
        /// <param name="elements">Набор элементов, к которым относится ошибка.</param>
        /// <returns>Результат выполнения команды.</returns>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<ExternalCommandData>(commandData);
            services.AddSingleton<RevitTask>(new RevitTask());
            services.AddSingleton<ISelectionService, SelectionService>();
            services.AddSingleton<ISectionService, SectionService>();
            services.AddSingleton<MainWindowViewModel, MainWindowViewModel>();
            services.AddSingleton<MainWindow, MainWindow>();
            var provider = services.BuildServiceProvider();

            var mainWindow = provider.GetRequiredService<MainWindow>();                  

            mainWindow.Show();

            return Result.Succeeded;
        }
    }
}
