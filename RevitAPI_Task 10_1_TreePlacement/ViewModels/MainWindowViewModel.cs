
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RevitAPI_Task_10_1_TreePlacement.Models;
using RevitAPI_Task_10_1_TreePlacement.Abstractions;
using System.Collections.ObjectModel;
using Autodesk.Revit.UI;

namespace RevitAPI_Task_10_1_TreePlacement.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IPlacementService _placementService;
        private TreeType _selectedTreeType;
        private int _count;
        private string _statusMessage;

        public MainWindowViewModel(IPlacementService placementService)
        {
            PlaceCommand = new RelayCommand(PlaceTree);

            TreeTypes = new ObservableCollection<TreeType>
            {
                TreeType.Tropical,
                TreeType.Сoniferous,
                TreeType.Deciduous,
                TreeType.Bush
            };

            _placementService = placementService;
        }

        public ObservableCollection<TreeType> TreeTypes { get; }

        public TreeType SelectedTreeType
        {
            get => _selectedTreeType;
            set => SetProperty(ref _selectedTreeType, value);
        }

        public int Count
        {
            get => _count;
            set => SetProperty(ref _count, value);
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public RelayCommand PlaceCommand { get; }

        private void PlaceTree()
        {
            CSharpFunctionalExtensions.Result result = _placementService.Place(SelectedTreeType, Count);
            if (result.IsSuccess)
            {
                StatusMessage = $"Размещено {Count} экземпляров деревьев";
                TaskDialog.Show("Размещение деревьев", StatusMessage);
            }
            else
            {
                StatusMessage = $"Ошибка {result.Error}";
                TaskDialog.Show("Размещение деревьев", result.Error);
            }
        }
    }
}
