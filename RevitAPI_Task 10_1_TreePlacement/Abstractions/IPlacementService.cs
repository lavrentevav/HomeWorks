using CSharpFunctionalExtensions;
using RevitAPI_Task_10_1_TreePlacement.Models;

namespace RevitAPI_Task_10_1_TreePlacement.Abstractions
{
    public interface IPlacementService
    {
        Result Place(TreeType selectedTreeType, int count);
    }
}
