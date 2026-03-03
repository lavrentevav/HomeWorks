using RevitAPI_Task_10_1_TreePlacement.Services;
using RevitAPI_Task_10_1_TreePlacement.ViewModels;
using RevitAPI_Task_10_1_TreePlacement.Views;
using RevitAPI_Task_10_1_TreePlacement.Abstractions;
using RxBim.Di;
using Microsoft.Extensions.DependencyInjection;

namespace RevitAPI_Task_10_1_TreePlacement
{
    internal class Config : ICommandConfiguration
    {
        public void Configure(IServiceCollection services)
        {
            services.AddSingleton<IPlacementService, PlacementService>();
            services.AddSingleton<MainWindowViewModel, MainWindowViewModel>();
            services.AddSingleton<MainWindow, MainWindow>();
        }
    }
}
