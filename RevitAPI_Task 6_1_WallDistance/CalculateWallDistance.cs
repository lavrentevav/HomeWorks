using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI_Task_6_1_WallDistance
{
    [Transaction(TransactionMode.Manual)]
    public class CalculateWallDistance : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;

            // Проверка выбора
            var selectedIds = uiDoc.Selection.GetElementIds();

            if (selectedIds.Count != 2)
            {
                TaskDialog.Show("Ошибка", "Выберите ровно две стены.");
                return Result.Failed;
            }

            if (!(uiDoc.Document.GetElement(selectedIds.First()) is Wall wall1) || !(uiDoc.Document.GetElement(selectedIds.Last()) is Wall wall2))
            {
                TaskDialog.Show("Ошибка", "Один из выбранных элементов не является стеной.");
                return Result.Failed;
            }

            // Определение нормалей стен
            XYZ normal1 = GetWallNormal(wall1);
            XYZ normal2 = GetWallNormal(wall2);

            // Проверка параллельности
            double dotProduct = normal1.DotProduct(normal2);
            const double tolerance = 0.001;

            if (Math.Abs(Math.Abs(dotProduct) - 1) > tolerance)
            {
                TaskDialog.Show("Ошибка", $"Стены не параллельны.");
                return Result.Failed;
            }

            // Находим центры каждой стены
            XYZ midPoint1 = GetWallMidpoint(wall1);
            XYZ midPoint2 = GetWallMidpoint(wall2);

            // Вычисляем вектор между центрами
            XYZ vectorBetween = midPoint2 - midPoint1;

            // Проецируем вектор на нормаль стены для получения перпендикулярного расстояния
            double distance = Math.Abs(vectorBetween.DotProduct(normal1));

            // Конвертация единиц
            double distanceInMm = UnitUtils.ConvertFromInternalUnits(distance, DisplayUnitType.DUT_MILLIMETERS);

            // Вывод результата
            TaskDialog.Show("Результат",
                $"Расстояние между параллельными стенами: {distanceInMm:F2} мм");

            return Result.Succeeded;
        }

        // метод получения нормали стены
        private XYZ GetWallNormal(Wall wall)
        {
            if (!(wall.Location is LocationCurve locationCurve))
                return null;

            Curve curve = locationCurve.Curve;

            // Получаем направление стены
            XYZ wallDirection = (curve.GetEndPoint(1) - curve.GetEndPoint(0)).Normalize();

            XYZ up = XYZ.BasisZ;

            // Нормаль к стене
            return wallDirection
              .CrossProduct(up)
              .Normalize();
        }

        // метод получения середины стены
        private XYZ GetWallMidpoint(Wall wall)
        {
            LocationCurve locationCurve = wall.Location as LocationCurve;
            Curve curve = locationCurve.Curve;

            // Получаем длину кривой
            double length = curve.Length;

            // Находим точку на расстоянии половины длины от начала
            XYZ midPoint = curve.Evaluate(length / 2, false);

            return midPoint;
        }
    }
}
