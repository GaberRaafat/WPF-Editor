using System.ComponentModel;
using System.Windows.Media;

namespace Editor.Model
{
    public class Polygon : Shape
    {
        public string Name { get; set; }
        public PointCollection Points { get; set; }
        public Polygon()
        {
            Points = new PointCollection();
        }

        public Polygon(string name, PointCollection points)
        {
            Name = name;
            Points = points;
        }
    }
    public class Point : INotifyPropertyChanged
    {
        private double _x;
        private double _y;

        public double X
        {
            get => _x;
            set
            {
                if (_x != value)
                {
                    _x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                if (_y != value)
                {
                    _y = value;
                    OnPropertyChanged(nameof(Y));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}