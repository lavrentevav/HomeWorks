using Autodesk.Revit.DB;
using RevitAPI_Task_8_1_InspectWalls.Models;

namespace RevitAPI_Task_8_1_InspectWalls.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса расчёта геометрических параметров стены.
    /// </summary>
    public interface IWallGeometryService
    {
        /// <summary>
        /// Возвращает информацию о стене с учётом допустимого предела толщины.
        /// </summary>
        /// <param name="wall">Стена Revit.</param>
        /// <param name="limit">Допустимый предел толщины в мм.</param>
        /// <returns>Данные о стене.</returns>
        WallInfo GetWallInfo(Wall wall, double limit);
    }
}