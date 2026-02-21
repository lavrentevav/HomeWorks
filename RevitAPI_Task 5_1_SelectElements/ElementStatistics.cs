using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RevitAPI_Task_5_1_ElementsSelect
{
    [Transaction(TransactionMode.Manual)]
    public class ElementStatistics : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            IList<Reference> pickedRefs;

            try
            {
                pickedRefs = uidoc.Selection.PickObjects(ObjectType.Element, new FamilyInstanceSelectionFilter(), "Выберите элементы");
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                TaskDialog.Show("Отмена", "Выбор элементов был отменен пользователем.");
                return Result.Cancelled;
            }

            if (pickedRefs == null || pickedRefs.Count == 0)
            {
                TaskDialog.Show("Результат", "Не было выбрано ни одного элемента.");
                return Result.Succeeded;
            }

            List<FamilyInstance> pickedElements = new List<FamilyInstance>();
            foreach (var pickedRef in pickedRefs)
            {
                Element element = doc.GetElement(pickedRef);
                if (element is FamilyInstance familyInstance)
                {
                    pickedElements.Add(familyInstance);
                }
            }

            // Подсчитываем статистику по категориям
            Dictionary<string, int> categoryStatistics = new Dictionary<string, int>();

            foreach (var element in pickedElements)
            {
                string categoryName = element.Category.Name;

                if (categoryStatistics.ContainsKey(categoryName))
                {
                    categoryStatistics[categoryName]++;
                }
                else
                {
                    categoryStatistics[categoryName] = 1;
                }
            }

            string report = $"Общее количество выбранных элементов: {pickedElements.Count}\n\n" +
                            $"Распределение по категориям:\n";

            foreach (var category in categoryStatistics)
            {
                report += $" • {category.Key}: {category.Value}\n";
            }

            TaskDialog.Show("Статистика выбранных элементов", report);

            return Result.Succeeded;
        }
    }
}
