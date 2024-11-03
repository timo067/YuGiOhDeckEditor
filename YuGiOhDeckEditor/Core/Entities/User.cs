using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User:BaseID
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string CreatedDate { get; set; }

        public User(string username, string email, string password, string createdDate)
        {
            
        }
    }
}
