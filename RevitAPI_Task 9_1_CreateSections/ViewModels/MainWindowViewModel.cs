using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RevitAPI_Task_9_1_CreateSections.Abstractions;
using System.Threading.Tasks;

namespace RevitAPI_Task_9_1_CreateSections.ViewModels
{
    /// <summary>
    /// Модель представления главного окна для создания трёх разрезов.
    /// </summary>
    public class MainWindowViewModel : ObservableObject
    {
        private readonly ISelectionService _selectionService;
        private readonly ISectionService _sectionService;
        private readonly RevitTask _revitTask;
        private string _sectionName = "Разрез";
        private double _widthOffsetMm = 100;
        private double _depthOffsetMm = 100;
        private double _heightOffsetMm = 100;

        /// <summary>
        /// Инициализирует новый экземпляр модели представления главного окна.
        /// </summary>
        /// <param name="selectionService">Сервис выбора экземпляра семейства.</param>
        /// <param name="sectionService">Сервис создания разрезов.</param>
        /// <param name="revitTask">Обёртка для выполнения задач в Revit.</param>
        public MainWindowViewModel(
            ISelectionService selectionService,
            ISectionService sectionService,
            RevitTask revitTask
            )
        {
            CreateSectionCommand = new AsyncRelayCommand(OnCreateSectionCommandExecute);
            _selectionService = selectionService;
            _sectionService = sectionService;
            _revitTask = revitTask;
        }

        /// <summary>
        /// Имя создаваемых разрезов.
        /// </summary>
        public string SectionName
        {
            get => _sectionName;
            set => SetProperty(ref _sectionName, value);
        }

        /// <summary>
        /// Отступ по ширине в миллиметрах.
        /// </summary>
        public double WidthOffsetMm
        {
            get => _widthOffsetMm;
            set => SetProperty(ref _widthOffsetMm, value);
        }

        /// <summary>
        /// Отступ по глубине в миллиметрах.
        /// </summary>
        public double DepthOffsetMm
        {
            get => _depthOffsetMm;
            set => SetProperty(ref _depthOffsetMm, value);
        }

        /// <summary>
        /// Отступ по высоте в миллиметрах.
        /// </summary>
        public double HeightOffsetMm
        {
            get => _heightOffsetMm;
            set => SetProperty(ref _heightOffsetMm, value);
        }

        /// <summary>
        /// Команда создания трёх разрезов по выбранному экземпляру семейства.
        /// </summary>
        public AsyncRelayCommand CreateSectionCommand { get; }

        private async Task OnCreateSectionCommandExecute()
        {
            FamilyInstance familyInstance = _selectionService.PickFamilyInstance();
            if (familyInstance == null)
            {
                return;
            }

            bool isCreated = await _revitTask.Run<bool>(app =>
            _sectionService.CreateSections(
                familyInstance,
                WidthOffsetMm,
                DepthOffsetMm,
                HeightOffsetMm,
                SectionName
                ));

            if (!isCreated)
            {
                TaskDialog.Show("Ошибка", "Не удалось создать разрезы");
            }
            else
            {
                TaskDialog.Show("Успех", "Три разреза успешно созданы");
            }
        }
    }
}
