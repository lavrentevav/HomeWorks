using Autodesk.Revit.Attributes;
using Microsoft.Extensions.DependencyInjection;
using RevitAPI_Task_10_1_TreePlacement.Views;
using RxBim.Command.Revit;
using RxBim.Shared;
using System;

namespace RevitAPI_Task_10_1_TreePlacement
{
    [Transaction(TransactionMode.Manual)]
    public class Cmd : RxBimCommand
    {
        public PluginResult ExecuteCommand(IServiceProvider provider)
        {
            var mainWindow = provider.GetRequiredService<MainWindow>();
            mainWindow.ShowDialog();
            return PluginResult.Succeeded;
        }
    }
}
