using Autodesk.Revit.DB;
using RevitAPI_Task_8_1_InspectWalls.Abstractions;
using RevitAPI_Task_8_1_InspectWalls.Models;
using System;

namespace RevitAPI_Task_8_1_InspectWalls.Services
{
    /// <summary>
    /// Сервис расчёта геометрических параметров стены Revit (длина, высота, толщина, объём, площадь).
    /// </summary>
    public class WallGeometryService : IWallGeometryService
    {
        /// <summary>
        /// Извлекает информацию о стене: размеры, объём, площадь и флаг соответствия пределу толщины.
        /// </summary>
        /// <param name="wall">Стена Revit.</param>
        /// <param name="limit">Допустимый предел толщины в мм.</param>
        /// <returns>Объект WallInfo с рассчитанными параметрами.</returns>
        public WallInfo GetWallInfo(Wall wall, double limit)
        {
            double length = GetWallLength(wall);
            double height = GetWallHeight(wall);
            double thickness = GetWallThickness(wall);
            double volume = GetWallVolume(wall);
            double area = (length * height) / 1000000;

            return new WallInfo()
            {
                Name = wall.Name,
                Type = wall.WallType.Name,
                Length = Math.Round(length, 2),
                Height = Math.Round(height, 2),
                Thickness = Math.Round(thickness, 2),
                Volume = Math.Round(volume, 3),
                Area = Math.Round(area, 2),
                IsCorrect = thickness <= limit
            };
        }

        private double GetWallLength(Wall wall)
        {
            var param = wall.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
            return UnitUtils.ConvertFromInternalUnits(param?.AsDouble() ?? 0, DisplayUnitType.DUT_MILLIMETERS);
        }

        private double GetWallHeight(Wall wall)
        {
            var param = wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM);
            return UnitUtils.ConvertFromInternalUnits(param?.AsDouble() ?? 0, DisplayUnitType.DUT_MILLIMETERS);
        }

        private double GetWallThickness(Wall wall)
        {
            return UnitUtils.ConvertFromInternalUnits(wall.Width, DisplayUnitType.DUT_MILLIMETERS);
        }

        private double GetWallVolume(Wall wall)
        {
            var param = wall.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED);
            return UnitUtils.ConvertFromInternalUnits(param?.AsDouble() ?? 0, DisplayUnitType.DUT_CUBIC_METERS);
        }
    }
}
