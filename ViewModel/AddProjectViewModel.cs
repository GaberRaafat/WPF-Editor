using Editor.Model;
using Editor.Model.Projects;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Editor.ViewModel
{
    public class AddProjectViewModel
    {

        public string Name { get; set; }
        public string Description { get; set; }


        private readonly Action<Project> _onProjectAdded;

        public AddProjectViewModel()
        {
        }

        public AddProjectViewModel(Action<Project> onProjectAdded)
        {
            _onProjectAdded = onProjectAdded;
            AddProjectCommand = new RelayCommand(AddProject);
        }

        private void AddProject()
        {
            Project rec = new Project(Name, Description);
            _onProjectAdded?.Invoke(rec);
        }

        public ICommand AddProjectCommand { get; }
    }
}
