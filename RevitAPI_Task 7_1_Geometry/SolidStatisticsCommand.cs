using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI_Task_7_1_Geometry
{
    [Transaction(TransactionMode.Manual)]
    public class SolidStatisticsCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            try
            {
                Reference pickedRef = uidoc.Selection.PickObject(ObjectType.Element, new SystemFamilySelectionFilter(), "Выберите экземпляр системного семейства");

                Element elem = doc.GetElement(pickedRef);

                Options options = new Options
                {
                    DetailLevel = ViewDetailLevel.Fine
                };

                GeometryElement geomElement = elem.get_Geometry(options);

                double totalVolume = 0;
                double totalArea = 0;
                int totalFaces = 0;
                int totalEdges = 0;
                double totalEdgesLength = 0;

                foreach (GeometryObject geomObj in geomElement)
                {
                    if (geomObj is Solid solid)
                    {
                        totalVolume += solid.Volume;
                        totalArea += solid.SurfaceArea;
                        totalFaces += solid.Faces.Size;
                        totalEdges += solid.Edges.Size;
                        foreach (Edge edge in solid.Edges)
                        {
                            Curve curve = edge.AsCurve();
                            totalEdgesLength += curve.Length;
                        }
                        //Интересная штука обнаружилась при тестировании на круглом воздуховоде.
                        //Этот код выдаёт на нём восемь рёбер (4 четверти окружностей на каждом торце), суммарная длина которых равна, соответственно, двум длинам окружности воздуховода.
                        //Но ревит лукап даёт выделить на круглом воздуховоде ещё 4 ребра - верх, низ, правый бок и левый бок воздуховода.
                        //Если собрать уникальные рёбра, пройдясь по всем граням солида, то ребер получится не 8, а 12, и к общей длине добавится +4 длины воздуховода.
                        //В целом вроде логично, что круглая поверхность цилиндра ребёр не имеет.
                    }
                }
                // Конвертация единиц
                double totalVolumeM3 = UnitUtils.ConvertFromInternalUnits(totalVolume, DisplayUnitType.DUT_CUBIC_METERS);
                double totalAreaM2 = UnitUtils.ConvertFromInternalUnits(totalArea, DisplayUnitType.DUT_SQUARE_METERS);
                double totalEdgesLengthMm = UnitUtils.ConvertFromInternalUnits(totalEdgesLength, DisplayUnitType.DUT_MILLIMETERS);

                string report = $"Элемент: {elem.Name}\n\n" +
                    $"Суммарный объем всех Solid: {totalVolumeM3:F2} куб. м.\n" +
                    $"Суммарная площадь поверхностей: {totalAreaM2:F2} кв. м.\n" +
                    $"Количество граней: {totalFaces}\n" +
                    $"Количество ребер: {totalEdges}\n" +
                    $"Суммарная длина ребер: {totalEdgesLengthMm:F2} мм";

                TaskDialog.Show("Статистика по геометрии", report);

                return Result.Succeeded;

            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }
        }
    }
}
