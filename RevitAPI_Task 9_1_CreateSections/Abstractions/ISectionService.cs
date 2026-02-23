using Autodesk.Revit.DB;

namespace RevitAPI_Task_9_1_CreateSections.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса для создания разрезов по экземпляру семейства.
    /// </summary>
    public interface ISectionService
    {
        /// <summary>
        /// Создаёт три разреза по указанному экземпляру семейства.
        /// </summary>
        /// <param name="familyInstance">Экземпляр семейства, вокруг которого создаются разрезы.</param>
        /// <param name="widthOffsetMm">Отступ по ширине в миллиметрах.</param>
        /// <param name="depthOffsetMm">Отступ по глубине в миллиметрах.</param>
        /// <param name="heightOffsetMm">Отступ по высоте в миллиметрах.</param>
        /// <param name="sectionName">Базовое имя для создаваемых разрезов.</param>
        /// <returns>True, если все разрезы успешно созданы; иначе false.</returns>
        bool CreateSections(FamilyInstance familyInstance, double widthOffsetMm, double depthOffsetMm, double heightOffsetMm, string sectionName);
    }
}
