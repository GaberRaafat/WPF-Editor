using Editor.DBContext;
using Editor.Model.Projects;
using Editor.Model.Users;
using Editor.Utility;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Editor.ViewModel
{
    public class ProjectSummaryViewModel : ObservableObject
    {
        public ObservableCollection<Project> AllProjects { get; set; } = new ObservableCollection<Project>();
        public ObservableCollection<Project> OpenedTabs { get; set; } = new ObservableCollection<Project>(new List<Project>()
                                                                                   { new Project("Projects Summary", "") });

        private Project _selectedProject;
        public Project SelectedProject
        {
            get => _selectedProject;
            set
            {
                _selectedProject = value;
                RaisePropertyChanged(nameof(SelectedProject));
                RaisePropertyChanged(nameof(CanAddProject));
            }
        }

        private readonly AppDbContext _context = new AppDbContext();
        public Guid CurrentUserId { get; set; }

        public bool CanAddProject
        {
            get => SelectedProject?.Name == "Projects Summary" || SelectedProject == null;
        }


        public ProjectSummaryViewModel()
        {
            CloseTabCommand = new RelayCommand<Project>(RunCloseTabCommand);
        }

        public ProjectSummaryViewModel(Guid currentUserId)
        {
            _context.Database.OpenConnection();
            CurrentUserId = currentUserId;

            List<Project> list = _context.Projects.Where(x => x.UserId == CurrentUserId).ToList();
            list = list == null ? new List<Project>() : list;

            AllProjects = new ObservableCollection<Project>(list);

            SelectProjectCommand = new RelayCommand<Guid>(RunSelectProjectCommand);
            AddProjectCommand = new RelayCommand(RunAddProjectCommand);
            CloseTabCommand = new RelayCommand<Project>(RunCloseTabCommand);
        }

        private void RunCloseTabCommand(Project project)
        {
            if (project != null && OpenedTabs.Contains(project))
            {
                OpenedTabs.Remove(project);
            }
        }

        private void RunSelectProjectCommand(Guid guid)
        {
            if (OpenedTabs.Any(x => x.Id == guid))
            {
                SelectedProject = OpenedTabs.FirstOrDefault(x => x.Id == guid);
                return;
            }
            var selectedProject = AllProjects.FirstOrDefault(x => x.Id == guid);
            if (selectedProject != null)
            {
                OpenedTabs.Add(selectedProject);
                if (selectedProject.EditorViewModel == null)
                {
                    selectedProject.EditorViewModel = new MainViewModel(selectedProject.Id);
                }
            }
            SelectedProject = selectedProject;
            RaisePropertyChanged(nameof(SelectedProject));
        }



        private void RunAddProjectCommand()
        {
            var addProjectViewModel = new AddProjectViewModel(OnProjectAdded);
            WindowTrasnfer.Show(addProjectViewModel);
        }

        private void OnProjectAdded(Project newProject)
        {
            newProject.UserId = CurrentUserId;
            AllProjects.Add(newProject);
            _context.Projects.Add(newProject);
            _context.SaveChanges();
        }

        public ICommand SelectProjectCommand { get; }
        public ICommand AddProjectCommand { get; }
        public ICommand CloseTabCommand { get; }

    }


}
