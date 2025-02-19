using Editor.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Editor.ViewModel
{
    public class AddRectangleViewModel
    {

        public string Name { get; set; }

        public int Width { get; set; }
        
        public int Height { get; set; }

        private readonly Action<Rectangle> _onRectangleAdded;

        public AddRectangleViewModel()
        {
        }

        public AddRectangleViewModel(Action<Rectangle> onRectangleAdded)
        {
            _onRectangleAdded = onRectangleAdded;
            AddRectangleCommand = new RelayCommand(AddRectangle);
        }

        private void AddRectangle()
        {
            Rectangle rec = new Rectangle(Name,Width,Height);
            _onRectangleAdded?.Invoke(rec);
        }

        public ICommand AddRectangleCommand { get; }
    }
}
