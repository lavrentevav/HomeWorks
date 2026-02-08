using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitAPI_Task_3_1_Intro
{
    [Transaction(TransactionMode.Manual)]
    public class ApplicationClass : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab("LAVMod");
            var panel = application.CreateRibbonPanel("LAVMod", "Общее");
            var button = new PushButtonData(
                "Delete",
                "Удалить",
                "C:\\Software Development Kit\\Samples\\DeleteObject\\CS\\bin\\Debug\\DeleteObject.dll",
                "Revit.SDK.Samples.DeleteObject.CS.Command"
                );
            BitmapImage bitmapImage = new BitmapImage(new Uri("C:\\Users\\user\\AppData\\Roaming\\Autodesk\\Revit\\Addins\\2019\\test\\img\\delete.png", UriKind.Absolute));
            button.LargeImage = bitmapImage;
            panel.AddItem(button);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
