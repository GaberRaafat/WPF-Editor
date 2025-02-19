using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Model.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public User() { }
        public User(string userName, string password)
        {
            Id = Guid.NewGuid();
            Password = password;
            UserName = userName;
        }
    }
}
