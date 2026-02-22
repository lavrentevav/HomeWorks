using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace RevitAPI_Task_8_1_InspectWalls.Services
{
    /// <summary>
    /// Фильтр выбора элементов Revit: допускает выбор только стен.
    /// </summary>
    internal class WallSelectionFilter : ISelectionFilter
    {
        /// <summary>
        /// Разрешает выбор элемента, если он является стеной.
        /// </summary>
        public bool AllowElement(Element elem) => elem is Wall;

        /// <summary>
        /// Запрещает выбор по ссылке (требуется выбор целиком по элементу).
        /// </summary>
        public bool AllowReference(Reference reference, XYZ position) => false;
    }
}
