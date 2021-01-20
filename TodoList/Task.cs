using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    class Task
    {
        int taskID,state,priority,listID;
        string taskText;
        string startDate, endDate,remainder;

        public int TaskID { get => taskID; set => taskID = value; }
        public int State { get => state; set => state = value; }
        public int ListID { get => listID; set => listID = value; }
        public int Priority { get => priority; set => priority = value; }
        public string TaskText { get => taskText; set => taskText = value; }
        public string StartDate { get => startDate; set => startDate = value; }
        public string EndDate { get => endDate; set => endDate = value; }
        public string Remainder { get => remainder; set => remainder = value; }
    }
}
