using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DbConnection dbConnection = new DbConnection();
            Task t1=dbConnection.GetOneTask(123458);
            Console.WriteLine("priority before : "+t1.Priority);
            dbConnection.UpdateTaskPriority(123458, 1);
            Task t2 = dbConnection.GetOneTask(123458);
            Console.WriteLine("priority After : " + t2.Priority);
            DateTime now = DateTime.Now;
            Console.WriteLine(now.Year);

        }
    }
}
