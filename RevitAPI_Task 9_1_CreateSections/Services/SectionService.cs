using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAPI_Task_9_1_CreateSections.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI_Task_9_1_CreateSections.Services
{
    /// <summary>
    /// Сервис для создания трёх разрезов по выбранному экземпляру семейства.
    /// </summary>
    internal class SectionService : ISectionService
    {
        private readonly ExternalCommandData _commandData;

        /// <summary>
        /// Инициализирует новый экземпляр сервиса создания разрезов.
        /// </summary>
        /// <param name="commandData">Данные внешней команды Revit.</param>
        public SectionService(
            ExternalCommandData commandData)
        {
            _commandData = commandData;
        }

        /// <summary>
        /// Создаёт три разреза (Front, Left, Top) вокруг указанного экземпляра семейства.
        /// </summary>
        /// <param name="instance">Экземпляр семейства, вокруг которого создаются разрезы.</param>
        /// <param name="widthOffsetMm">Отступ по ширине в миллиметрах.</param>
        /// <param name="depthOffsetMm">Отступ по глубине в миллиметрах.</param>
        /// <param name="heightOffsetMm">Отступ по высоте в миллиметрах.</param>
        /// <param name="baseSectionName">Базовое имя для создаваемых разрезов.</param>
        /// <returns>True, если все разрезы успешно созданы; иначе false.</returns>
        public bool CreateSections(
            FamilyInstance instance,
            double widthOffsetMm,
            double depthOffsetMm,
            double heightOffsetMm,
            string baseSectionName)
        {
            var doc = _commandData.Application.ActiveUIDocument.Document;

            var bbox = instance.get_BoundingBox(null);

            if (bbox == null)
            {
                return false;
            }

            var center = (bbox.Min + bbox.Max) / 2;
            var size = bbox.Max - bbox.Min;

            var widthOffset = UnitUtils.ConvertToInternalUnits(widthOffsetMm, DisplayUnitType.DUT_MILLIMETERS);
            var depthOffset = UnitUtils.ConvertToInternalUnits(depthOffsetMm, DisplayUnitType.DUT_MILLIMETERS);
            var heightOffset = UnitUtils.ConvertToInternalUnits(heightOffsetMm, DisplayUnitType.DUT_MILLIMETERS);

            var viewType = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewFamilyType))
                .OfType<ViewFamilyType>()
                .FirstOrDefault(x => x.ViewFamily == ViewFamily.Section);

            if (viewType == null)
            {
                return false;
            }

            try
            {
                using (var transaction = new Transaction(doc, "Создание трёх разрезов"))
                {
                    transaction.Start();

                    // Разрез Front
                    var transformFront = Transform.Identity;
                    transformFront.Origin = center;
                    transformFront.BasisX = (XYZ.BasisZ.CrossProduct(XYZ.BasisY)).Normalize();
                    transformFront.BasisY = XYZ.BasisZ;
                    transformFront.BasisZ = XYZ.BasisY;

                    var sectionBoxFront = new BoundingBoxXYZ
                    {
                        Transform = transformFront,
                        Min = new XYZ(-size.X / 2 - widthOffset, -size.Z / 2 - heightOffset, -size.Y / 2 - depthOffset),
                        Max = new XYZ(size.X / 2 + widthOffset, size.Z / 2 + heightOffset, size.Y / 2 + depthOffset)
                    };

                    var viewFront = ViewSection.CreateSection(doc, viewType.Id, sectionBoxFront);
                    viewFront.Name = $"{baseSectionName}_Front";

                    // Разрез Left
                    var transformLeft = Transform.Identity;
                    transformLeft.Origin = center;
                    transformLeft.BasisX = (XYZ.BasisZ.CrossProduct(XYZ.BasisX)).Normalize();
                    transformLeft.BasisY = XYZ.BasisZ;
                    transformLeft.BasisZ = XYZ.BasisX;

                    var sectionBoxLeft = new BoundingBoxXYZ
                    {
                        Transform = transformLeft,
                        Min = new XYZ(-size.Y / 2 - widthOffset, -size.Z / 2 - heightOffset, -size.X / 2 - depthOffset),
                        Max = new XYZ(size.Y / 2 + widthOffset, size.Z / 2 + heightOffset, size.X / 2 + depthOffset)
                    };

                    var viewLeft = ViewSection.CreateSection(doc, viewType.Id, sectionBoxLeft);
                    viewLeft.Name = $"{baseSectionName}_Left";

                    // Разрез Top
                    var transformTop = Transform.Identity;
                    transformTop.Origin = center;
                    transformTop.BasisX = (XYZ.BasisY.CrossProduct(-XYZ.BasisZ)).Normalize();
                    transformTop.BasisY = XYZ.BasisY;
                    transformTop.BasisZ = -XYZ.BasisZ;

                    var sectionBoxTop = new BoundingBoxXYZ
                    {
                        Transform = transformTop,
                        Min = new XYZ(-size.X / 2 - widthOffset, -size.Y / 2 - heightOffset, -size.Z / 2 - depthOffset),
                        Max = new XYZ(size.X / 2 + widthOffset, size.Y / 2 + heightOffset, size.Z / 2 + depthOffset)
                    };

                    var viewTop = ViewSection.CreateSection(doc, viewType.Id, sectionBoxTop);
                    viewTop.Name = $"{baseSectionName}_Top";

                    transaction.Commit();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
