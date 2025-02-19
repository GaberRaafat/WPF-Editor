using Editor.DBContext;
using Editor.Model.Users;
using Editor.Utility;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Editor.ViewModel
{
    public class LogInViewModel : ObservableObject
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        private bool _wrongCredentials;
        public bool WrongCredentials
        {
            get => _wrongCredentials;
            set => Set(ref _wrongCredentials, value);
        }

        private readonly AppDbContext _context = new AppDbContext();

        public LogInViewModel()
        {
            LoginCommand = new RelayCommand<object>(RunLoginCommand);
            SignupCommand = new RelayCommand<object>(RunSignupCommand);
        }

        public void RunLoginCommand(object parameter)
        {
            User user = _context.Users.FirstOrDefault(x => x.UserName == UserName && x.Password == PassWord);

            if (user == null)
            {
                WrongCredentials = true;
                return;
            }

            var projectSummaryViewModel = new ProjectSummaryViewModel(user.Id);

            if (!projectSummaryViewModel.AllProjects.Any())
            {
                MessageBox.Show("No projects assigned to this user. You can add new projects.");
                WindowTrasnfer.Show(projectSummaryViewModel);
            }
            else
            {
                WindowTrasnfer.Show(projectSummaryViewModel);
            }

            if (parameter is Window window)
            {
                window.Close();
            }
        }


        public void RunSignupCommand(object parameter)
        {
            WindowTrasnfer.Show(new SignupviewModel());
            if (parameter is Window window)
            {
                window.Close();
            }
        }
        public ICommand LoginCommand { get; }
        public ICommand SignupCommand { get; }
    }
}
