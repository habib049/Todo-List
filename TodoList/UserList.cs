using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class UserList
    {
        int listID;
        string listname,username;
        public UserList()
        {
            ListID = 0;
        }
        public int ListID { get => listID; set => listID = value; }
        public string Listname { get => listname; set => listname = value; }
        public string Username { get => username; set => username = value; }
    }
}
