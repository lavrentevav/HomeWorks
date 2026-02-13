using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RevitAPI_Task_4_1_FilterWalls
{
    [Transaction(TransactionMode.Manual)]
    public class WallStat : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            // Получаем все стены
            var walls = new FilteredElementCollector(doc)
                .OfClass(typeof(Wall))
                .OfType<Wall>()
                .ToList();

            // Обрабатываем случай, когда стен нет
            if (!walls.Any())
            {
                TaskDialog.Show("Статистика стен", "В проекте нет стен.");
                return Result.Succeeded;
            }

            double totalWallLength = 0;
            double maxWallLength = 0;
            double minWallLength = 0;
            Wall shortestWall = null;
            Wall longestWall = null;

            using (Transaction t = new Transaction(doc, "Затирание комментариев"))
            {
                t.Start();
                foreach (Wall wall in walls)
                {
                    // Получаем параметр длины
                    Parameter lengthParam = wall.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
                    if (lengthParam == null || !lengthParam.HasValue) continue;
                    double wallLengh = lengthParam.AsDouble();
                    if (wallLengh > maxWallLength)
                    {
                        maxWallLength = wallLengh;
                        longestWall = wall;
                    }
                    if (wallLengh < minWallLength || minWallLength == 0)
                    {
                        minWallLength = wallLengh;
                        shortestWall = wall;
                    }
                    //Затираем комментарии от предыдущего запуска
                    Parameter commentParam = wall.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                    if (commentParam != null && !commentParam.IsReadOnly && commentParam.HasValue)
                    {
                        string currentComment = commentParam.AsString();
                        if (!string.IsNullOrEmpty(currentComment) && currentComment.StartsWith("Самая"))
                        {
                            commentParam.Set(string.Empty);
                        }
                    }

                    totalWallLength += wallLengh;
                }
                t.Commit();
            }

            double averageWallLength = totalWallLength / walls.Count;

            // Преобразуем длины в метры для отчета
            double minWallLengthM = UnitUtils.ConvertFromInternalUnits(minWallLength, DisplayUnitType.DUT_METERS);
            double maxWallLengthM = UnitUtils.ConvertFromInternalUnits(maxWallLength, DisplayUnitType.DUT_METERS);
            double averageWallLengthM = UnitUtils.ConvertFromInternalUnits(averageWallLength, DisplayUnitType.DUT_METERS);

            string report = $"Статистика по стенам\n\n" +
               $"Всего стен: {walls.Count}\n" +
               $"Самая короткая стена: {minWallLengthM:F2} м\n" +
               $"Самая длинная стена: {maxWallLengthM:F2} м\n" +
               $"Средняя длина стен: {averageWallLengthM:F2} м";

            //если в проекте одна стена или все стены одинаковой длины, то нет смысла записывать комментарий
            if (walls.Count <= 1 || longestWall == shortestWall)
            {
                TaskDialog.Show("Статистика стен", report);
                return Result.Succeeded;
            }

            using (Transaction t = new Transaction(doc, "Заполнение комментариев"))
            {
                t.Start();

                // Получаем комментарий
                Parameter commentParam = longestWall.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                if (commentParam != null && !commentParam.IsReadOnly)
                    commentParam.Set("Самая длинная стена");

                // Получаем комментарий
                commentParam = shortestWall.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                if (commentParam != null && !commentParam.IsReadOnly)
                    commentParam.Set("Самая короткая стена");

                t.Commit();
            }
            TaskDialog.Show("Статистика стен", report);
            return Result.Succeeded;
        }
    }
}
