using Autodesk.Revit.DB;
using CSharpFunctionalExtensions;
using RevitAPI_Task_10_1_TreePlacement.Models;
using RevitAPI_Task_10_1_TreePlacement.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RevitAPI_Task_10_1_TreePlacement.Services
{
    public class PlacementService : IPlacementService
    {
        private readonly Document _document;

        public PlacementService(Document document)
        {
            _document = document;
        }

        public Result Place(TreeType treeType, int count)
        {
            return Validate(count)
                .Bind(() => FindFamily(treeType))
                .Bind(s => PlaceInstances(s, count));
        }

        private Result Validate(int count)
        {
            if (count <= 0)
                return Result.Failure("Количество должно быть больше 0");
            return Result.Success();
        }

        private Result<FamilySymbol> FindFamily(TreeType treeType)
        {
            string treeName = string.Empty;
            switch (treeType)
            {
                case TreeType.Сoniferous:
                    treeName = "хво";
                    break;
                case TreeType.Bush:
                    treeName = "куст";
                    break;
                case TreeType.Deciduous:
                    treeName = "лист";
                    break;
                case TreeType.Tropical:
                    treeName = "тропич";
                    break;
            }

            FamilySymbol familySymbol = new FilteredElementCollector(_document)
                .OfCategory(BuiltInCategory.OST_Planting)
                .OfClass(typeof(FamilySymbol))
                .OfType<FamilySymbol>()
                .Where(x => x.FamilyName.IndexOf(treeName, StringComparison.OrdinalIgnoreCase) >= 0)
                .FirstOrDefault();

            if (familySymbol == null)
                return Result.Failure<FamilySymbol>("Не найден типоразмер для размещения");

            return familySymbol;
        }

        private Result PlaceInstances(FamilySymbol familySymbol, int count)
        {
            try
            {
                int gridSize = (int)Math.Ceiling(Math.Sqrt(count));
                double step = UnitUtils.ConvertToInternalUnits(3, DisplayUnitType.DUT_METERS);
                var points = new List<XYZ>();
                for (int row = 0; row < gridSize; row++)
                {
                    for (int col = 0; col < gridSize; col++)
                    {
                        if (points.Count >= count)
                            break;

                        double x = col * step;
                        double y = row * step;
                        points.Add(new XYZ(x, y, 0));
                    }
                }

                var level = new FilteredElementCollector(_document)
                    .OfClass(typeof(Level))
                    .OfType<Level>()
                    .OrderBy(l => l.Elevation)
                    .FirstOrDefault();

                if (level == null)
                    return Result.Failure("Не удалось определить уровень для размещения");

                using (Transaction transaction = new Transaction(_document, "Размещение деревьев"))
                {
                    transaction.Start();

                    if (!familySymbol.IsActive)
                    {
                        familySymbol.Activate();
                    }

                    foreach (var point in points)
                    {
                        _document.Create.NewFamilyInstance(
                            point,
                            familySymbol,
                            level,
                            Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                    }
                    transaction.Commit();
                }
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}
