using Autodesk.Revit.DB;

namespace RevitAPI_Task_9_1_CreateSections.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для выбора экземпляров семейств в документе Revit.
    /// </summary>
    public interface ISelectionService
    {
        /// <summary>
        /// Выполняет выбор экземпляра семейства в документе Revit.
        /// </summary>
        /// <returns>Выбранный экземпляр семейства или null, если выбор был отменён.</returns>
        FamilyInstance PickFamilyInstance();
    }
}
