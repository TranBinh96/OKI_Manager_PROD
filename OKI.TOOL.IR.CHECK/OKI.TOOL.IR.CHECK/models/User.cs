using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKI.TOOL.IR.CHECK.models
{
    public class User
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public User(string username, string password)
        {
            Username = username;    
            Password = password;
            
        }
    }
}
