namespace TodoList
{
    using System.Collections.Generic;

    public class User
    {

        private string username, firstname, lastname, email, password;     

        public string Username { get=> username; set=> username = value; }
        public string Firstname { get=> firstname; set=> firstname = value; }
        public string Lastname { get=> lastname; set=> lastname = value; }
        public string Email { get=> email; set=> email = value; }
        public string Password { get=> password; set=> password = value; }
        
    }
}
