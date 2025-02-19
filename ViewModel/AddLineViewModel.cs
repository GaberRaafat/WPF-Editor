using Editor.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using System.Xml.Linq;

namespace Editor.ViewModel
{
    public class AddLineViewModel
    {
        public string Name { get; set; }

        public double X1 { get; set; }
        public double X2 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }

        private readonly Action<Line> _onLineAdded;

        public AddLineViewModel()
        {
        }

        public AddLineViewModel(Action<Line> onLineAdded)
        {
            _onLineAdded = onLineAdded;
            AddLineCommand = new RelayCommand(AddCLine);
        }

        private void AddCLine()
        {
            Line line = new Line(Name, X1, X2, Y1, Y2);
            _onLineAdded?.Invoke(line);
        }

        public ICommand AddLineCommand { get; }
    }
}
