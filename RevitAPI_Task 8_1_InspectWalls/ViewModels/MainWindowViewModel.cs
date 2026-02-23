using Autodesk.Revit.DB;
using RevitAPI_Task_8_1_InspectWalls.Abstractions;
using RevitAPI_Task_8_1_InspectWalls.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RevitAPI_Task_8_1_InspectWalls.ViewModels
{
    /// <summary>
    /// Модель представления главного окна инспекции стен.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IWallSelectionService _selectionService;
        private readonly IWallGeometryService _geometryService;

        /// <summary>
        /// Создаёт экземпляр модели представления с указанными сервисами выбора и геометрии стен.
        /// </summary>
        /// <param name="selectionService">Сервис выбора стены в Revit.</param>
        /// <param name="geometryService">Сервис расчёта геометрических параметров стены.</param>
        public MainWindowViewModel(IWallSelectionService selectionService, IWallGeometryService geometryService)
        {
            SelectWallCommand = new RelayCommand(OnSelectWallExecute);
            _selectionService = selectionService;
            _geometryService = geometryService;
        }

        /// <summary>
        /// Событие изменения свойства для уведомления представления.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private WallInfo _wallInfo;

        /// <summary>
        /// Информация о выбранной стене (название, размеры, соответствие норме).
        /// </summary>
        public WallInfo WallInfo
        {
            get => _wallInfo;
            set
            {
                _wallInfo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(StatusText));
            }
        }

        private double _thicknessLimit = 300;

        /// <summary>
        /// Допустимый предел толщины стены в мм. Превышение отмечается как некорректное.
        /// </summary>
        public double ThicknessLimit
        {
            get => _thicknessLimit;
            set
            {
                _thicknessLimit = value;
                OnPropertyChanged();

                if (WallInfo != null)
                {
                    WallInfo.IsCorrect = WallInfo.Thickness <= value;
                    OnPropertyChanged(nameof(WallInfo));
                    OnPropertyChanged(nameof(StatusText));
                }
            }
        }

        /// <summary>
        /// Текстовое представление статуса: «Норма» или «Превышение».
        /// </summary>
        public string StatusText
        {
            get
            {
                if (WallInfo == null) return "-";
                return WallInfo.IsCorrect ? "Норма" : "Превышение";
            }
        }

        /// <summary>
        /// Команда выбора стены для анализа.
        /// </summary>
        public ICommand SelectWallCommand { get; }

        private void OnSelectWallExecute(object parameter)
        {
            Wall wall = _selectionService.PickWall();
            if (wall == null) return;

            WallInfo = _geometryService.GetWallInfo(wall, ThicknessLimit);
        }
    }
}
