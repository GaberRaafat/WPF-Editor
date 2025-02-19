using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using Editor.Model;
using Editor.Utility;
using System;

namespace Editor.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public Guid ProjectId { get; set; }
        public ObservableCollection<Shape> Shapes { get; set; }

        private Shape _selectedShape;
        public Shape SelectedShape
        {
            get => _selectedShape;
            set
            {
                if (Set(ref _selectedShape, value))
                {
                    HasSelectedItem = _selectedShape != null;
                }
            }
        }

        private Shape _onEditShape;

        public Shape OnEditShape
        {
            get => _onEditShape;
            set => Set(ref _onEditShape, value);
        }

        private bool _isAddMenuOpened;
        public bool IsAddMenuOpened
        {
            get => _isAddMenuOpened;
            set => Set(ref _isAddMenuOpened, value);
        }

        private bool _hasSelectedItem;
        public bool HasSelectedItem
        {
            get => _hasSelectedItem;
            set => Set(ref _hasSelectedItem, value);
        }
        public MainViewModel(Guid projectId)
        {
            ProjectId = projectId;
            IntilizeShapes();
            IntilizeCommands();
        }

        public MainViewModel()
        {
        }

        private void IntilizeShapes()
        {
            Shapes = new ObservableCollection<Shape>(ProjectShapesManager.GetProjectShapes(ProjectId));
        }

        private void UpdateShapes()
        {
            ProjectShapesManager.SaveProjectShapes(ProjectId, Shapes.ToList());
        }

        private void IntilizeCommands()
        {
            ShowCircleWindow = new RelayCommand(OpenAddCircleWindow);
            ShowRectangleWindow = new RelayCommand(OpenAddRectangleWindow);
            ShowLineWindow = new RelayCommand(OpenAddLineWindow);
            ShowPolygonWindow = new RelayCommand(OpenAddPolygonWindow);

            ExportShapesCommand = new RelayCommand(ExportShapes);
            ImportShapesCommand = new RelayCommand(ImportShapes);

            EditSelectedCommand = new RelayCommand(EditSelected);
            DeleteSelectedCommand = new RelayCommand(DeleteSelected);
            SaveEditCommand = new RelayCommand(SaveEdit);
        }

        private void OnShapeAdded(Shape newShape)
        {
            Shapes.Add(newShape);
            UpdateShapes();
        }

        private void ImportShapes()
        {
            Shapes = new ObservableCollection<Shape>(ShapesManager.LoadShapes());
            RaisePropertyChanged(nameof(Shapes));
            UpdateShapes();
        }

        private void ExportShapes()
        {
            ShapesManager.SaveShapes(Shapes.ToList());
        }

        private void OpenAddCircleWindow()
        {
            IsAddMenuOpened = false;
            var addCircleViewModel = new AddCircleViewModel(OnShapeAdded);
            WindowTrasnfer.ShowDialog(addCircleViewModel);
        }

        private void OpenAddRectangleWindow()
        {
            IsAddMenuOpened = false;
            var addRectangleViewModel = new AddRectangleViewModel(OnShapeAdded);
            WindowTrasnfer.ShowDialog(addRectangleViewModel);
        }

        private void OpenAddLineWindow()
        {
            IsAddMenuOpened = false;
            var addLineViewModel = new AddLineViewModel(OnShapeAdded);
            WindowTrasnfer.ShowDialog(addLineViewModel);
        }
        private void OpenAddPolygonWindow()
        {
            IsAddMenuOpened = false;
            var addPolygonViewModel = new AddPolygonViewModel(OnShapeAdded);
            WindowTrasnfer.ShowDialog(addPolygonViewModel);
        }

        private void DeleteSelected()
        {
            Shapes = new ObservableCollection<Shape>(Shapes.Where(x => x.Id != SelectedShape.Id).ToList());
            RaisePropertyChanged(nameof(Shapes));
            SelectedShape = null;
        }

        private void SaveEdit()
        {
            RaisePropertyChanged(nameof(Shapes));
            SelectedShape = null;
            OnEditShape = null;
        }

        private void EditSelected()
        {
            OnEditShape = SelectedShape;
        }

        public ICommand ShowCircleWindow { get; set; }
        public ICommand ShowRectangleWindow { get; set; }
        public ICommand ShowLineWindow { get; set; }
        public ICommand ShowPolygonWindow { get; set; }
        public ICommand ExportShapesCommand { get; set; }
        public ICommand ImportShapesCommand { get; set; }
        public ICommand EditSelectedCommand { get; set; }
        public ICommand DeleteSelectedCommand { get; set; }
        public ICommand SaveEditCommand { get; set; }
    }
}
