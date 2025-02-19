using Editor.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;

namespace Editor.ViewModel
{
    public class AddCircleViewModel
    {
        public string Name { get; set; }
        public int Radius1 { get; set; }
        public int Radius2 { get; set; }
        private readonly Action<Circle> _onCircleAdded;

        public AddCircleViewModel()
        {
        }

        public AddCircleViewModel(Action<Circle> onCircleAdded)
        {
            _onCircleAdded = onCircleAdded;
            AddCircleCommand = new RelayCommand(AddCircle);
        }

        private void AddCircle()
        {
            Circle circle = new Circle(Name, Radius1, Radius2);
            _onCircleAdded?.Invoke(circle);
        }

        public ICommand AddCircleCommand { get; }
    }
}
