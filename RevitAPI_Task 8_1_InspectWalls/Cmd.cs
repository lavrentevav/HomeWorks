using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Extensions.DependencyInjection;
using RevitAPI_Task_8_1_InspectWalls.Abstractions;
using RevitAPI_Task_8_1_InspectWalls.Services;
using RevitAPI_Task_8_1_InspectWalls.ViewModels;
using RevitAPI_Task_8_1_InspectWalls.Views;

namespace RevitAPI_Task_8_1_InspectWalls
{
    /// <summary>
    /// Внешняя команда Revit для запуска приложения инспекции стен.
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    internal class Cmd : IExternalCommand
    {
        /// <summary>
        /// Выполняет команду: настраивает DI-контейнер, регистрирует сервисы и показывает главное окно.
        /// </summary>
        /// <param name="commandData">Данные внешней команды Revit.</param>
        /// <param name="message">Сообщение, возвращаемое при сбое.</param>
        /// <param name="elements">Набор элементов для подсветки при сбое.</param>
        /// <returns>Результат выполнения команды.</returns>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var services = new ServiceCollection();

            services.AddSingleton<ExternalCommandData>(commandData);
            services.AddSingleton<IWallSelectionService, WallSelectionService>();
            services.AddSingleton<IWallGeometryService, WallGeometryService>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainWindow>();

            var provider = services.BuildServiceProvider();
            var mainWindow = provider.GetRequiredService<MainWindow>();

            mainWindow.Show();
            return Result.Succeeded;
        }
    }
}
