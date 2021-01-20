using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TodoList
{
    class DataAccess
    {
        private static DataAccess instance = null;
        private  User currentUser;
        private DbConnection database;
        private List<UserList> userLists;
        private Random random;

        public  User CurrentUser { get => currentUser; set => currentUser = value; }
        internal List<UserList> UserLists { get => userLists; set => userLists = value; }

        private DataAccess()
        {
            this.database = new DbConnection();
            random = new Random();
        }
        
        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataAccess();                
                return instance;
            }
        }    


        public void collectUserLists()
        {
            UserLists = database.GetUserList(CurrentUser.Username);
        }

        public int ValidateUser(string username, string password)
        {
            CurrentUser = database.ValidateUser(username);
            if (CurrentUser != null)
            {
                if (CurrentUser.Password == password)
                {
                    collectUserLists();
                    return 1;
                }
               
                return 0;
            }
            else
                return -1;
        }

        public List<Task> GetListTasks(int listID)
        {
            return database.GetTaskList(listID);
        }

        public Task AddNewTask(string text, string sDate, string eDate,int priority,int state,int listID)
        {
            Console.WriteLine("Called");
            Task task = new Task
            {
                TaskID = generateTaskID(),
                TaskText = text,
                StartDate = sDate,
                EndDate = eDate,
                Priority = priority,
                State = state,
                ListID = listID,
                Remainder = "0"
            };
            database.AddNewTask(task);
            return task;
        }

        public void RemoveTask(int taskID)
        {
            database.RemoveTask(taskID);
        }

        public UserList GetListObject(string name)
        {
            UserList list = new UserList
            {
                ListID = generateListID(),
                Listname = name,
                Username = currentUser.Username
            };
            return list;
        }

        public void AddNewList(UserList l)
        {           
            database.AddNewList(l);
        }

        public void RemoveList(int listID)
        {
            bool n=database.RemoveList(listID);
            Console.WriteLine(n);
        }

        public void AddUser(string username,string fname,string lname,string email,string pass)
        {
            User user = new User
            {
                Username = username,
                Firstname = fname,
                Lastname = lname,
                Email = email,
                Password = pass
            };
            database.AddNewUser(user);
        }

        public void UpdateUser(string fname, string lname, string email, string pass)
        {
            User user = new User
            {
                Username = currentUser.Username,
                Firstname = fname,
                Lastname = lname,
                Email = email,
                Password = pass
            };
            database.UpdateUser(user);
        }

        //update task remainder
        public void UpdateRemainder(int taskID,string remainder)
        {
            database.UpdateRemainder(taskID, remainder);
        }

        public void RemoveRemainder(int taskID)
        {
            database.UpdateRemainder(taskID,"0");
        }




        public void RemoveUser()
        {
            database.RemoveUser(currentUser.Username);
        }

        public void UpdateTaskPriority(int taskID,int priority)
        {
            database.UpdateTaskPriority(taskID, priority);
        }

        public void updateTaskDuedate(int taskID, string date)
        {
            database.UpdateTaskEndDate(taskID, date);
        }

        public void UpdateTaskStatus(int taskID, int status)
        {
            database.UpdateTaskStatus(taskID, status);
        }


        private int generateTaskID()
        {
            int number = random.Next(100000, 999999);
            while (!database.CheckTaskIDAvailability(number))
            {
                number = random.Next(100000, 999999);
            }
            return number;            
        }

        private int generateListID()
        {
            int number = random.Next(10000, 99999);
            while (!database.CheckListIDAvailability(number))
            {
                number = random.Next(10000, 99999);
            }
            return number;
        }


        public List<Task> GetTodayTasks()
        {            
            return null;
        }


        public bool CheckUsernameAvailability(string username)
        {
            return database.checkUsernameAvailability(username);
        }

        public bool CheckEmailAvailability(string email)
        {
            return database.CheckEmailAvailability(email);
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
