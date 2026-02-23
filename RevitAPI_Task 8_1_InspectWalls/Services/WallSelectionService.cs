using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitAPI_Task_8_1_InspectWalls.Abstractions;

namespace RevitAPI_Task_8_1_InspectWalls.Services
{
    /// <summary>
    /// Сервис выбора стены пользователем в активном документе Revit.
    /// </summary>
    public class WallSelectionService : IWallSelectionService
    {
        private readonly ExternalCommandData _commandData;

        /// <summary>
        /// Создаёт экземпляр сервиса с данными команды Revit для доступа к документу и выделению.
        /// </summary>
        /// <param name="commandData">Данные внешней команды Revit.</param>
        public WallSelectionService(ExternalCommandData commandData)
        {
            _commandData = commandData;
        }

        /// <summary>
        /// Запрашивает у пользователя выбор стены. Возвращает null при отмене выбора.
        /// </summary>
        /// <returns>Выбранная стена или null.</returns>
        public Wall PickWall()
        {
            try
            {
                Reference reference = _commandData.Application.ActiveUIDocument.Selection.PickObject(
                    ObjectType.Element,
                    new WallSelectionFilter(),
                    "Выберите стену для анализа");

                return _commandData.Application.ActiveUIDocument.Document.GetElement(reference) as Wall;
            }
            catch
            {
                return null;
            }
        }
    }
}
