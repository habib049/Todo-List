using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class DbConnection
    {
        private IDbConnection getConneciton()
        {
            return new SQLiteConnection(@"Data Source =.\database.db;Version=3;");
        }

        //adding a new user
        public bool AddNewUser(User user)
        {
            if (checkUsernameAvailability(user.Username))
            {
                string query = "insert into User (Username,Firstname,Lastname,Email,Password) Values(@username,@fname,@lname,@email,@pass)";
                using (IDbConnection connection = getConneciton())
                {
                    connection.Execute(query, new
                    {
                        username = user.Username,
                        fname = user.Firstname,
                        lname = user.Lastname,
                        email = user.Email,
                        pass = user.Password
                    });
                    return true;
                }
            }
            return false;
        }

        public void UpdateUser(User user) 
        {
            using (IDbConnection connection = getConneciton())
            {
                var resultTasks = connection.Execute("Update User set FirstName=@fname, LastName=@lname,Email=@email, Password=@pass where Username=@username",
                    new
                    {
                        fname = user.Firstname,
                        lname = user.Lastname,
                        email = user.Email,
                        pass=user.Password,
                        username=user.Username
                    });
                
            }
        }

        //remove user
        public bool RemoveUser(string username)
        {
            if (!checkUsernameAvailability(username))
            {
                string query = "Delete from User where Username=@name;";
                using (IDbConnection connection = getConneciton())
                {
                    int n=connection.Execute(query, new
                    {
                        name = username
                    });
                    Console.WriteLine("value of n is "+n);
                    return true;
                }
            }
            return false;
        }

        public bool checkUsernameAvailability(string username)
        {
            using (IDbConnection connection = getConneciton())
            {
                var user = connection.Query<User>("Select * from User where username=@username", new { username = username }).ToList();
                if (user.Count == 0)
                {
                    return true;
                }
                return false;               
            }
        }

        //check for email if it is already registered
        public bool CheckEmailAvailability(string email)
        {
            using (IDbConnection connection = getConneciton())
            {
                var user = connection.Query<User>("Select * from User where Email=@email", new { email = email }).ToList();
                if (user.Count == 0)
                {
                    return true;
                }
                return false;
            }
        }

        //add new task  
        public bool AddNewTask(Task task)
        {
            Console.WriteLine("data base Called");
            string query = "insert into Task (TaskID,TaskText,CreatedDate,EndDate,State,Priority,Remainder,ListID) Values(@id,@text,@cDate,@eDate,@state,@priority,@remainder,@lid)";
            using (IDbConnection connection = getConneciton())
            {
                connection.Execute(query, new
                {
                    id = task.TaskID,
                    text=task.TaskText,
                    cDate=task.StartDate,
                    eDate = task.EndDate,
                    state=task.State,
                    priority=task.Priority,
                    remainder=task.Remainder,
                    lid=task.ListID
                });
                return true;
            }
        }

        //removing a task
        public bool RemoveTask(int taskID)
        {
            if (!CheckTaskIDAvailability(taskID))
            {
                string query = "Delete from Task Where TaskID=@id";
                using (IDbConnection connection = getConneciton())
                {
                    connection.Execute(query, new
                    {
                        id = taskID
                    });
                    return true;
                }
            }
            return false;
        }


        //add new List 
        public bool AddNewList(UserList list)
        {
            string query = "insert into List (ListID,ListName,Username) Values(@id,@name,@username)";
            using (IDbConnection connection = getConneciton())
            {
                connection.Execute(query, new
                {
                     id=list.ListID,
                     name=list.Listname,
                     username=list.Username
                });
                return true;
            }
        }

        //removing a list
        public bool RemoveList(int listID)
        {
            if (!CheckListIDAvailability(listID))
            {
                string query = "Delete from List Where ListID=@id";
                using (IDbConnection connection = getConneciton())
                {
                    int n=connection.Execute(query, new
                    {
                        id = listID
                    });
                    Console.WriteLine(n);
                    return true;
                }
            }
            return false;
        }
        
        // username and passsword confirmation
        public User ValidateUser(string username)
        {
            using (IDbConnection connection = getConneciton())
            {
                try
                {
                    var currentUser = connection.QueryFirst<User>("Select * from User where username=@username  ", new { username = username });
                    if (currentUser != null)
                    {                        
                        return currentUser;                      
                    }
                }
                catch(InvalidOperationException e)
                {
                    return null;
                }                                           
            }
            return null;
        }

        //get user tasks list
        public List<UserList> GetUserList(string username)
        {
            using (IDbConnection connection = getConneciton())
            {
                var resultLists = connection.Query<UserList>("Select * from List where username=@username", new { username = username });
              
                return resultLists.ToList();
            }
        }

        //get user tasks from particular list
        public List<Task> GetTaskList(int listId)
        {
            using (IDbConnection connection = getConneciton())
            {
                var resultTasks = connection.Query<Task>("Select * from Task where ListID=@id", new { id=listId});
                
                return resultTasks.ToList();
            }
        }

        //get particular one task
        public Task GetOneTask(int taskId)
        {
            using (IDbConnection connection = getConneciton())
            {
                 return (Task)connection.Query<Task>("Select * from Task where TaskID=@id ", new { id = taskId }).SingleOrDefault();

            }
        }


        //update task data
        public bool UpdateTaskPriority(int taskID,int priority)
        {
            using (IDbConnection connection = getConneciton())
            {
                var resultTasks = connection.Execute("Update Task set Priority=@priority where TaskID=@taskID", new { priority=priority, taskID = taskID });
                return true;
            }
        }
        public bool UpdateTaskStatus(int taskID, int status)
        {
            using (IDbConnection connection = getConneciton())
            {
                var resultTasks = connection.Execute("Update Task set State=@status where TaskID=@taskID", new { status = status, taskID = taskID });
                return true;
            }
        }

        public bool UpdateTaskStartDate(int taskID, string sDate)
        {
            using (IDbConnection connection = getConneciton())
            {
                var resultTasks = connection.Execute("Update Task set CreatedDate=@sDate where TaskID=@taskID", new { sDate = sDate, taskID = taskID });
                return true;
            }
        }

        public bool UpdateTaskEndDate(int taskID, string eDate)
        {
            using (IDbConnection connection = getConneciton())
            {
                var resultTasks = connection.Execute("Update Task set EndDate=@eDate where TaskID=@taskID", new { eDate = eDate,taskID=taskID });
                return true;
            }
        }


        //update list Date
        public bool UpdateListname(int listID, string name)
        {
            using (IDbConnection connection = getConneciton())
            {
                var resultTasks = connection.Execute("Update List set Listname=@listname where ListID=@listID", new { listname = name,listID=listID });
                return true;
            }
        }

        //update user data
        public bool UpdateUserEmail(string username, string email)
        {
            using (IDbConnection connection = getConneciton())
            {
                var resultTasks = connection.Execute("Update User set Email=@email  where Username=@username", new { email = email, username = username });
                return true;
            }
        }
        public bool UpdateUserFirstname(string username, string fname)
        {
            using (IDbConnection connection = getConneciton())
            {
                var resultTasks = connection.Execute("Update User set Firstname=@firstname where Username=@username ", new { firstname = fname, username = username });
                return true;
            }
        }
        public bool UpdateUserLastname(string username, string lname)
        {
            using (IDbConnection connection = getConneciton())
            {
                var resultTasks = connection.Execute("Update User set Lastname=@lastname where Username=@username", new { lastname = lname,username=username});
                return true;
            }
        }


        // to prevenet id duplicaiton
        public bool CheckTaskIDAvailability(int id)
        {
            using (IDbConnection connection = getConneciton())
            {
                var result = connection.Query<Task>("Select * from Task where TaskID=@id", new {id = id }).ToList();
                if (result.Count==0)
                {
                    return true;
                }
                return false;                              
            }
        }

        // to prevenet id duplicaiton
        public bool CheckListIDAvailability(int id)
        {
            using (IDbConnection connection = getConneciton())
            {
                var result= connection.Query<UserList>("Select * from List where ListID=@id", new { id = id }).ToList();
                if (result.Count == 0)
                {
                    return true;
                }
                return false;

            }
        }

        //update the remainder
        public void UpdateRemainder(int taskID,string remainder)
        {
            using (IDbConnection connection = getConneciton())
            {
                var resultTasks = connection.Execute("Update Task set Remainder=@remainder where taskID=@id",
                    new
                    {
                        id=taskID,
                        remainder=remainder,
                    });
            }
        }


    }
}
