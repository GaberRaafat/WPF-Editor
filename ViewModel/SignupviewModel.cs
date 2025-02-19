using Editor.DBContext;
using Editor.Model.Users;
using Editor.Utility;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Editor.ViewModel
{
    public class SignupviewModel : ObservableObject
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

        public SignupviewModel()
        {
            SignupCommand = new RelayCommand<object>(RunSignupCommand);
        }

        public void RunSignupCommand(object parameter)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(PassWord))
            {
                WrongCredentials = true;
                return;
            }
            User newUser = new User(UserName, PassWord);
            _context.Users.Add(newUser);
            _context.SaveChanges();
            WindowTrasnfer.Show(new LogInViewModel());

            if (parameter is System.Windows.Window window)
            {
                window.Close();
            }

        }

        public ICommand SignupCommand { get; }

    }
}
