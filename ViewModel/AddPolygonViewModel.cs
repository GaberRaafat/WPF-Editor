using Editor.Model;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

namespace Editor.ViewModel
{
    public class AddPolygonViewModel
    {
        public string Name { get; set; }
        public ObservableCollection<Point> PointsCollection { get; set; }

        public ICommand AddPolygonCommand { get; }
        public ICommand AddPointCommand { get; }

        private readonly Action<Polygon> _onShapeAdded;
        public AddPolygonViewModel()
        {
        }

        public AddPolygonViewModel(Action<Polygon> onShapeAdded)
        {
            _onShapeAdded = onShapeAdded;
            PointsCollection = new ObservableCollection<Point>();
            AddPolygonCommand = new RelayCommand(AddPolygon);
            AddPointCommand = new RelayCommand(AddPoint);
        }

        private void AddPolygon()
        {
            var points = new PointCollection();
            foreach (var point in PointsCollection)
            {
                points.Add(new System.Windows.Point(point.X, point.Y));
            }

            Polygon polygon = new Polygon(Name, points);
            _onShapeAdded.Invoke(polygon);
        }

        private void AddPoint()
        {
            PointsCollection.Add(new Point { X = 0, Y = 0 });
        }
    }

}