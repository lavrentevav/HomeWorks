using Autodesk.Revit.DB;

namespace RevitAPI_Task_8_1_InspectWalls.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса выбора стены пользователем в документе Revit.
    /// </summary>
    public interface IWallSelectionService
    {
        /// <summary>
        /// Запрашивает выбор стены у пользователя.
        /// </summary>
        /// <returns>Выбранная стена или null при отмене.</returns>
        Wall PickWall();
    }
}
