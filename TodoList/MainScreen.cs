using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TodoList
{
    public partial class MainScreen : Form
    {
        DataAccess dataAccess;
        List<UserList> list;
        DateTimePicker dateTimePicker;
        DateTimePicker datePickerRemainder;
        DateTimePicker timePickerRemainder;
        Guna2Panel datetimePanel;
        private bool alreadyImportant;
        private bool alreadyremainded;
        private bool alreadyCompleted;
        private bool remainderMouseClicked;
        private bool mouseCliked;
        private Panel dateChangePanel;
        private Panel availableListShowPanel = new Panel();
        private bool firstTime;
        private bool firstTimeForTasks;
        private bool firstTimeForList;
        private bool filterAdded;
        IconPictureBox remainderIcon;
        Task remainderChangedTask;

        public MainScreen()
        {
            InitializeComponent();
            generalToolTip.SetToolTip(exportAllListIcon, "Export all Lists to Pdf");
            dateTimePicker = new DateTimePicker
            {
                Visible = false
            };

            datetimePanel = new Guna2Panel
            {
                Visible = false,
                BorderColor = Color.Orange,
                BorderThickness = 2,
                Width = 210,
                Height = 86
            };
            datePickerRemainder = new DateTimePicker
            {
                MinDate = DateTime.Today,
                Width = 128,
                Top = 13,
                Left = 11,
            };

            timePickerRemainder = new DateTimePicker
            {
                MinDate = DateTime.Today,
                CustomFormat = "HH:mm",
                Format = DateTimePickerFormat.Custom,
                ShowUpDown = true,
                Width = 56,
                Top = 13,
                Left = 145,
            };

            dataAccess = DataAccess.Instance;
            alreadyCompleted = false;
            alreadyImportant = false;
            alreadyremainded = false;
            remainderMouseClicked = false;
            mouseCliked = false;
            firstTime = true;
            firstTimeForTasks = true;
            firstTimeForList = true;
            filterAdded = false;
            AddPanelHoverEffects();
            AddLabelHoverEffects();
            AddIconHoverEffects();
            MakeAllActiveDisable();        
            

            SetClickEventsSideBar();
            InitializeUserData();
            SetDateTime();

            MakeAllPanelInVisible();
            //making only the tasks panel visible
            tasksActiveLine.Visible = true;
            mainPanelTasks.Visible = true;

            LoadUserData();
            IntializeListPanel();
            firstTime = false;

            AddEventListnersToAvailableLists();

            AddTasksToPanel();
            AddEventsToRemoveFilter();

        }
        //
        //*****************************************Initailize all data ********************************************************
        //
        private const int shadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = shadow;
                return cp;
            }
        }

        //intitaliza the user data
        private void InitializeUserData()
        {
            //setting user name
            usernameMainLabel.Text = dataAccess.CurrentUser.Username.ToUpper();
            list = dataAccess.UserLists;
        }

        //load user data
        private void LoadUserData()
        {
            if (dataAccess.CurrentUser.Firstname == "")
                fnameTextBox.Text = "Not set";
            else
                fnameTextBox.Text = dataAccess.CurrentUser.Firstname;

            if (dataAccess.CurrentUser.Lastname == "")
                lnameTextBox.Text = "Not set";
            else
                lnameTextBox.Text = dataAccess.CurrentUser.Lastname;

            emailTextBox.Text = dataAccess.CurrentUser.Email;
        }

        //DataAccess time settings
        private void SetDateTime()
        {
            dateTimePickerAddTask.MinDate = DateTime.Today;
            dateTimePickerAddTask.Value = DateTime.Today;
            filterDatePicker.MinDate = DateTime.Today;
            filterDatePicker.Value = DateTime.Today;
            dateTimePicker.ValueChanged += new EventHandler(ChangeDateHandler);
        }

        private void IntializeListPanel()
        {
            dataAccess.collectUserLists();
            int number = 1;
            foreach (UserList userList in dataAccess.UserLists)
            {
                IconButton button = new IconButton
                {
                    Name = ("list" + number),
                    IconChar = FontAwesome.Sharp.IconChar.ListAlt,
                    IconColor = Color.WhiteSmoke,
                    IconSize = 28,
                    ImageAlign = System.Drawing.ContentAlignment.MiddleLeft,
                    Text = userList.Listname,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    ForeColor = Color.WhiteSmoke,
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Height = 35,
                    Width = 200,
                    Cursor = System.Windows.Forms.Cursors.Hand
                };
                availableListShowPanel.Controls.Add(button);
                button.Dock = System.Windows.Forms.DockStyle.Top;
                number++;

                listFilterInTasks.Items.Add(userList.Listname);

                if (firstTime)
                {
                    Guna2Panel panel = MakeListPanel(userList);
                    allListPanel.Controls.Add(panel);
                    panel.Dock = System.Windows.Forms.DockStyle.Top;
                }
            }
            availableListShowPanel.Width = 200;
            availableListShowPanel.Height = 35 * (number - 1);

            if (allListPanel.Controls.Count == 0)
            {
                Panel p = NoTaskDisplayMaker();
                allListPanel.Controls.Add(p);
                p.BringToFront();
            }
        }
                
        private void AddTasksToPanel()
        {
            allTasksListPanel.Controls.Clear();
            dataAccess.collectUserLists();
            foreach (UserList userList in dataAccess.UserLists)
            {
                foreach (Task task in dataAccess.GetListTasks(userList.ListID))
                {
                    DateTime taskDate = DateTime.ParseExact(task.EndDate, "MM/dd/yyyy",
                                      System.Globalization.CultureInfo.InvariantCulture).Date;
                    DateTime today = DateTime.Now.Date;

                    if (task.Priority == 1 && task.State != 2)
                    {
                        Guna2Panel panel = MakeTaskPanel(task.TaskID,task.TaskText, userList.Listname, task.EndDate, true, task.State, task.Remainder);
                        importantTasksShowPanel.Controls.Add(panel);
                        panel.Dock = System.Windows.Forms.DockStyle.Top;
                        
                    }
                    if(task.State==1 || task.State == 2)
                    {
                        if (task.Priority == 1)
                        {
                            Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, true, task.State, task.Remainder);
                            allTasksListPanel.Controls.Add(panel1);
                            panel1.Dock = System.Windows.Forms.DockStyle.Top;
                        }
                        else
                        {
                            Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, false, task.State, task.Remainder);
                            allTasksListPanel.Controls.Add(panel1);
                            panel1.Dock = System.Windows.Forms.DockStyle.Top;
                        }
                       
                    }
                    //checking and putting weekly and today due tasks

                    if (DateTime.Compare(taskDate, today) == 0 && task.State != 2)
                    {
                        if (task.Priority == 1)
                        {
                            Guna2Panel newPanel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, true, task.State, task.Remainder);
                            allTodayTasksPanel.Controls.Add(newPanel1);
                            newPanel1.Dock = System.Windows.Forms.DockStyle.Top;
                        }
                        else
                        {
                            Guna2Panel newPanel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, false, task.State, task.Remainder);
                            allTodayTasksPanel.Controls.Add(newPanel1);
                            newPanel1.Dock = System.Windows.Forms.DockStyle.Top;
                        }
                    }

                    //due in a week

                    if ((taskDate.Day >= today.Day && taskDate.Day <= ((today.Day + 7) % DateTime.DaysInMonth(taskDate.Year, taskDate.Month))) && task.State != 2)
                    {

                        if (task.Priority == 1)
                        {
                            Guna2Panel newPanel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, true, task.State, task.Remainder);
                            allWeekTasksPanel.Controls.Add(newPanel1);
                            newPanel1.Dock = System.Windows.Forms.DockStyle.Top;
                        }
                        else
                        {
                            Guna2Panel newPanel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, false, task.State, task.Remainder);
                            allWeekTasksPanel.Controls.Add(newPanel1);
                            newPanel1.Dock = System.Windows.Forms.DockStyle.Top;
                        }
                    }
                    else if ((taskDate.Day > ((DateTime.Today.Day + 7) % DateTime.DaysInMonth(taskDate.Year, taskDate.Month))) && task.State != 2)
                    {

                        if (taskDate.Month + 1 == today.AddDays(7).Month)
                        {
                            if (task.Priority == 1)
                            {
                                Guna2Panel newPanel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, true, task.State, task.Remainder);
                                allWeekTasksPanel.Controls.Add(newPanel1);
                                newPanel1.Dock = System.Windows.Forms.DockStyle.Top;
                            }
                            else
                            {
                                Guna2Panel newPanel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, false, task.State, task.Remainder);
                                allWeekTasksPanel.Controls.Add(newPanel1);
                                newPanel1.Dock = System.Windows.Forms.DockStyle.Top;
                            }
                        }
                    }
                }
            }
            if (allTasksListPanel.Controls.Count == 0)
            {
                Panel p = NoTaskDisplayMaker();
                allTasksListPanel.Controls.Add(p);
                p.BringToFront();
            }
        }

        //********************************************** Adding hover effects Events on side bar ***************************************

        public void AddPanelHoverEffects()
        {
            importantTasks.MouseEnter += new EventHandler(AddColor);
            importantTasks.MouseLeave += new EventHandler(RemoveColor);
            dayTasks.MouseEnter += new EventHandler(AddColor);
            dayTasks.MouseLeave += new EventHandler(RemoveColor);
            weekTasks.MouseEnter += new EventHandler(AddColor);
            weekTasks.MouseLeave += new EventHandler(RemoveColor);
            allTasks.MouseEnter += new EventHandler(AddColor);
            allTasks.MouseLeave += new EventHandler(RemoveColor);
            listPanel.MouseEnter += new EventHandler(AddColor);
            listPanel.MouseLeave += new EventHandler(RemoveColor);
            settingPanel.MouseEnter += new EventHandler(AddColor);
            settingPanel.MouseLeave += new EventHandler(RemoveColor);
        }
        public void AddLabelHoverEffects()
        {
            importantLabelPart.MouseEnter += new EventHandler(AddLabelColor);
            importantLabelPart.MouseLeave += new EventHandler(RemoveLabelColor);
            dayTasksLabel.MouseEnter += new EventHandler(AddLabelColor);
            dayTasksLabel.MouseLeave += new EventHandler(RemoveLabelColor);
            weekTasksLabel.MouseEnter += new EventHandler(AddLabelColor);
            weekTasksLabel.MouseLeave += new EventHandler(RemoveLabelColor);
            allTasksLabel.MouseEnter += new EventHandler(AddLabelColor);
            allTasksLabel.MouseLeave += new EventHandler(RemoveLabelColor);
            listLabel.MouseEnter += new EventHandler(AddLabelColor);
            listLabel.MouseLeave += new EventHandler(RemoveLabelColor);
            settingLabel.MouseEnter += new EventHandler(AddLabelColor);
            settingLabel.MouseLeave += new EventHandler(RemoveLabelColor);
        }
        public void AddIconHoverEffects()
        {
            importantTasksIcon.MouseEnter += new EventHandler(AddIconColor);
            importantTasksIcon.MouseLeave += new EventHandler(RemoveIconColor);
            dayTasksIcon.MouseEnter += new EventHandler(AddIconColor);
            dayTasksIcon.MouseLeave += new EventHandler(RemoveIconColor);
            weekIconLabel.MouseEnter += new EventHandler(AddIconColor);
            weekIconLabel.MouseLeave += new EventHandler(RemoveIconColor);
            allTasksIcon.MouseEnter += new EventHandler(AddIconColor);
            allTasksIcon.MouseLeave += new EventHandler(RemoveIconColor);
            listIconLabel.MouseEnter += new EventHandler(AddIconColor);
            listIconLabel.MouseLeave += new EventHandler(RemoveIconColor);
            settingIcon.MouseEnter += new EventHandler(AddIconColor);
            settingIcon.MouseLeave += new EventHandler(RemoveIconColor);
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void SetClickEventsSideBar()
        {
            importantTasks.Click += new EventHandler(ImportantTaskClickEvent);
            importantLabelPart.Click += new EventHandler(ImportantTaskClickEvent);
            importantTasksIcon.Click += new EventHandler(ImportantTaskClickEvent);

            weekTasks.Click += new EventHandler(WeekTaskClickEvent);
            weekTasksLabel.Click += new EventHandler(WeekTaskClickEvent);
            weekIconLabel.Click += new EventHandler(WeekTaskClickEvent);

            dayTasks.Click += new EventHandler(DayTaskClickEvent);
            dayTasksLabel.Click += new EventHandler(DayTaskClickEvent);
            dayTasksIcon.Click += new EventHandler(DayTaskClickEvent);

            allTasks.Click += new EventHandler(AllTasksClickEvent);
            allTasksLabel.Click += new EventHandler(AllTasksClickEvent);
            allTasksIcon.Click += new EventHandler(AllTasksClickEvent);

            listPanel.Click += new EventHandler(ListPanelClickEvent);
            listLabel.Click += new EventHandler(ListPanelClickEvent);
            listIconLabel.Click += new EventHandler(ListPanelClickEvent);

            settingPanel.Click += new EventHandler(SettingPanelClickEvent);
            settingLabel.Click += new EventHandler(SettingPanelClickEvent);
            settingIcon.Click += new EventHandler(SettingPanelClickEvent);


        }
        //adding events listerners
        //
        private void AddEventListnersToAvailableLists()
        {
            dataAccess.collectUserLists();
            List<UserList> updatedList = dataAccess.UserLists;
            for (int i = 1; i < updatedList.Count + 1; i++)
            {
                IconButton button = (IconButton)availableListShowPanel.Controls["list" + i];
                button.Click += new EventHandler(HandleSelectedList);
            }
        }

        //
        //*********************************************Helper Functions***********************************************************
        //
        //checking and putting weekly and daily tasks
        //
        private void PutWeekAndTodayDue(Task task,UserList l)
        {
            DateTime taskDate = DateTime.ParseExact(task.EndDate, "MM/dd/yyyy",
                                     System.Globalization.CultureInfo.InvariantCulture).Date;
            DateTime today = DateTime.Now.Date;

            if (DateTime.Compare(taskDate, today) == 0)
            {
                if (task.Priority == 1)
                {
                    Guna2Panel newPanel1 = MakeTaskPanel(task.TaskID, task.TaskText, l.Listname, task.EndDate, true, 1, task.Remainder);
                    allTodayTasksPanel.Controls.Add(newPanel1);
                    newPanel1.Dock = System.Windows.Forms.DockStyle.Top;
                }
                else
                {
                    Guna2Panel newPanel1 = MakeTaskPanel(task.TaskID, task.TaskText, l.Listname, task.EndDate, false, 1, task.Remainder);
                    allTodayTasksPanel.Controls.Add(newPanel1);
                    newPanel1.Dock = System.Windows.Forms.DockStyle.Top;
                }
            }

            //due in a week

            if ((taskDate.Day >= today.Day && taskDate.Day <= ((today.Day + 7) % DateTime.DaysInMonth(taskDate.Year, taskDate.Month))))
            {

                if (task.Priority == 1)
                {
                    Guna2Panel newPanel1 = MakeTaskPanel(task.TaskID, task.TaskText, l.Listname, task.EndDate, true, 1, task.Remainder);
                    allWeekTasksPanel.Controls.Add(newPanel1);
                    newPanel1.Dock = System.Windows.Forms.DockStyle.Top;
                }
                else
                {
                    Guna2Panel newPanel1 = MakeTaskPanel(task.TaskID, task.TaskText, l.Listname, task.EndDate, false, 1, task.Remainder);
                    allWeekTasksPanel.Controls.Add(newPanel1);
                    newPanel1.Dock = System.Windows.Forms.DockStyle.Top;
                }
            }
            else if ((taskDate.Day > ((DateTime.Today.Day + 7) % DateTime.DaysInMonth(taskDate.Year, taskDate.Month))) && task.State != 2)
            {

                if (taskDate.Month + 1 == today.AddDays(7).Month)
                {
                    if (task.Priority == 1)
                    {
                        Guna2Panel newPanel1 = MakeTaskPanel(task.TaskID, task.TaskText, l.Listname, task.EndDate, true, 1, task.Remainder);
                        allWeekTasksPanel.Controls.Add(newPanel1);
                        newPanel1.Dock = System.Windows.Forms.DockStyle.Top;
                    }
                    else
                    {
                        Guna2Panel newPanel1 = MakeTaskPanel(task.TaskID, task.TaskText, l.Listname, task.EndDate, false, 1, task.Remainder);
                        allWeekTasksPanel.Controls.Add(newPanel1);
                        newPanel1.Dock = System.Windows.Forms.DockStyle.Top;
                    }
                }
            }
        }

        private Panel GetFrontPanel()
        {
            if (importantTasksShowPanel.Visible)
                return importantTasksShowPanel;
            return allTasksListPanel;
        }
        private Panel GetPanelFromTaskIDFromImportantTasks(int id)
        {
            foreach (Control con in importantTasksShowPanel.Controls)
            {
                if (con.Controls["id"].Text == Convert.ToString(id))
                {
                    return (Panel)con;
                }
            }
            return null;
        }
        private Panel GetPanelFromTaskIDFromAllTasks(int id)
        {
            foreach (Control con in allTasksListPanel.Controls)
            {
                if (con.Controls.Count > 3)
                {
                    if (con.Controls["id"].Text == Convert.ToString(id))
                    {
                        return (Panel)con;
                    }
                }
            }
            return null;
        }

        private Panel GetPanelFromTaskIDFromWeekTasks(int id)
        {
            foreach (Control con in allWeekTasksPanel.Controls)
            {
                if (con.Controls.Count > 3)
                {
                    if (con.Controls["id"].Text == Convert.ToString(id))
                    {
                        return (Panel)con;
                    }
                }
            }
            return null;
        }

        private Panel GetPanelFromTaskIDFromTodayTasks(int id)
        {
            foreach (Control con in allTodayTasksPanel.Controls)
            {
                if (con.Controls.Count > 3)
                {
                    if (con.Controls["id"].Text == Convert.ToString(id))
                    {
                        return (Panel)con;
                    }
                }
            }
            return null;
        }

        private UserList GetListFromListID(int listID)
        {
            UserList foundList=null;
            dataAccess.collectUserLists();
            foreach (UserList l in dataAccess.UserLists)
            {
                if (l.ListID == listID)
                {
                    foundList=l;
                    break;
                } 
            }
            return foundList;
        }

        private Task GetTaskFromID(string id)
        {
            foreach (UserList userList in dataAccess.UserLists)
            {
                foreach (Task task in dataAccess.GetListTasks(userList.ListID))
                {
                    if (Convert.ToString(task.TaskID)==id)
                        return task;
                }
            }
            return null;
        }
        private string MakeStringReprentationDate(DateTime date)
        {
            string stringDate = "";
            if (date.Month < 10)
                stringDate += "0" + date.Month + "/";
            else
                stringDate += date.Month + "/";
            if (date.Day < 10)
                stringDate += "0" + date.Day + "/" + date.Year;
            else
                stringDate += date.Day + "/" + date.Year;
            return stringDate;
        }

        private UserList GetListFromListname(string listname)
        {
            dataAccess.collectUserLists();
            foreach (UserList l in dataAccess.UserLists)
            {
                if (l.Listname == listname)
                {
                    return l;
                }
            }
            return null;
        }

        private void RefreshAllPanels()
        {
            //clear all pannels first
            importantTasksShowPanel.Controls.Clear();
            allWeekTasksPanel.Controls.Clear();
            allTodayTasksPanel.Controls.Clear();
            availableListShowPanel.Controls.Clear();

            //calling function to refill all

            dataAccess.collectUserLists();
            list = dataAccess.UserLists;
            IntializeListPanel();
            AddEventListnersToAvailableLists();
            AddTasksToPanel();
        }
        private int GetTotalTasksInList(int listID)
        {
            foreach (UserList l in list)
            {
                if (l.ListID == listID)
                {
                    return dataAccess.GetListTasks(l.ListID).Count;
                }
            }
            return 0;
        }
        private void MakeAllPanelInVisible()
        {
            mainPanelImportantTasks.Visible = false;
            mainPanelMyDay.Visible = false;
            mainPanelTasks.Visible = false;
            mainPanelMyList.Visible = false;
            mainPanelSettings.Visible = false;
            mainPanelMyWeek.Visible = false;
        }
        private void MakeAllActiveDisable()
        {
            importantTasksActiveLine.Visible = false;
            myWeekActiveLine.Visible = false;
            myDayActiveLine.Visible = false;
            tasksActiveLine.Visible = false;
            myListActiveLine.Visible = false;
            settingActiveLine.Visible = false;

        }
        //*****************************************Different Components Maker*************************************************
        //
        private Panel NoTaskDisplayMaker()
        {
            Panel displayPanel = new Panel {
                Height = 424,
                Width=700,
                Location=new Point(19, 21),
                Anchor = AnchorStyles.Right|AnchorStyles.Left|AnchorStyles.Top|AnchorStyles.Bottom,
                Name="noPanel"
            };

            PictureBox pic = new PictureBox
            {
                Image = System.Drawing.Image.FromFile("no task.png"),
                Height = 200,
                Width = 380,
                Location = new Point(155, 90),
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,
                Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom,
            };
            displayPanel.Controls.Add(pic);
            return displayPanel;
        }


        // List Panel Maker
        //
        private Guna2Panel MakeListPanel(UserList list)
        {
            Guna2Panel panel = new Guna2Panel
            {
                Width = 735,
                Height = 67,
                BorderColor = Color.WhiteSmoke,
                BorderThickness = 1

            };

            IconPictureBox picBox = new IconPictureBox
            {
                IconChar = FontAwesome.Sharp.IconChar.ListAlt,
                IconSize = 32,
                Location = new Point(14, 13),
                IconColor = Color.WhiteSmoke
            };

            Label label = new Label
            {
                Text = list.Listname,
                Font = new Font("Microsoft YaHei UI", 11),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(56, 15),
                AutoEllipsis = true,
                AutoSize = false,
                Width = 300
            };

            Label listID = new Label
            {
                Text = list.ListID.ToString(),
                Visible = false,
                Name = "id"
            };


            Label label1 = new Label();
            if (list.ListID == 0)
            {
                label1.Text = String.Format("Total tasks : {0}", 0);
            }
            else
            {
                label1.Text = String.Format("Total tasks : {0}", GetTotalTasksInList(list.ListID));
            }

            label1.Font = new Font("Microsoft YaHei UI", 8);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(57, 41);
            label1.AutoEllipsis = true;
            label1.AutoSize = false;
            label1.Width = 200;

            IconPictureBox deleteIcon = new IconPictureBox
            {
                IconChar = FontAwesome.Sharp.IconChar.TrashAlt,
                IconSize = 25,
                Location = new Point(684, 17),
                IconColor = Color.WhiteSmoke,
                Anchor = AnchorStyles.Right,
                Cursor = System.Windows.Forms.Cursors.Hand
            };
            generalToolTip.SetToolTip(deleteIcon, "Delete the list");
            //adding its events
            deleteIcon.MouseEnter += new EventHandler(DeleteIconMouesEnter);
            deleteIcon.MouseLeave += new EventHandler(DeteleIconMouseLeave);
            deleteIcon.Click += new EventHandler(DeleteListClickEvent);

            IconPictureBox exportIcon = new IconPictureBox
            {
                IconChar = FontAwesome.Sharp.IconChar.FileExport,
                IconSize = 25,
                Location = new Point(650, 17),
                IconColor = Color.WhiteSmoke,
                Anchor = AnchorStyles.Right,
                Cursor = System.Windows.Forms.Cursors.Hand
            };

            generalToolTip.SetToolTip(exportIcon, "Export to pdf");
            exportIcon.MouseEnter += new EventHandler(ExportIconMouesEnter);
            exportIcon.MouseLeave += new EventHandler(ExportIconMouesLeave);
            exportIcon.Click += new EventHandler(ExportIconMouesClick);

            panel.Controls.Add(listID);
            panel.Controls.Add(picBox);
            panel.Controls.Add(label);
            panel.Controls.Add(label1);
            panel.Controls.Add(deleteIcon);
            panel.Controls.Add(exportIcon);
            return panel;
        }
        //
        //Make Task panel
        //
        private Guna2Panel MakeTaskPanel(int taskId,string taskname, string listname, string due, bool isImportant, int status, string remainder)
        {
            DateTime taskDate = DateTime.ParseExact(due, "MM/dd/yyyy",
                                      System.Globalization.CultureInfo.InvariantCulture).Date;
            DateTime today = DateTime.Now.Date;
            DateTime remainderDateTime;
            string remainderDisplayFormat = "";

            if (!remainder.Equals("0"))
            {
                remainderDateTime = DateTime.ParseExact(remainder, "MM/dd/yyyy HH:mm",
                                     System.Globalization.CultureInfo.InvariantCulture);

                remainderDisplayFormat += remainderDateTime.DayOfWeek + " " + remainderDateTime.Day + "/"
                    + remainderDateTime.Month + "/" + remainderDateTime.Year+"  at "+remainderDateTime.Hour+":"+remainderDateTime.Minute;
            }

            Guna2Panel panel = new Guna2Panel
            {
                //setting width and height
                Width = 735,
                Height = 67,
                //setting border
                BorderColor = Color.WhiteSmoke,
                BorderThickness = 1
            };

            //setting atask id with he panel
            Label taskIDLabel = new Label
            {
                Text = Convert.ToString(taskId), 
                Name="id",
                Visible=false                
            };


            //setting done button
            IconPictureBox completeIcon = new IconPictureBox
            {
                IconChar = FontAwesome.Sharp.IconChar.Circle,
                IconSize = 32,
                Location = new Point(14, 13),
                IconColor = Color.WhiteSmoke,
                Cursor = System.Windows.Forms.Cursors.Hand
            };
            generalToolTip.SetToolTip(completeIcon, "Mark it Completed");

            //setting task Label
            Label taskNameLabel = new Label
            {
                Text = taskname,
                Font = new Font("Microsoft YaHei UI", 11),
                ForeColor = Color.WhiteSmoke,
                Location = new Point(56, 15),
                AutoEllipsis = true,
                AutoSize = false,
                Width = 300
            };

            //setting other details label
            Label infoLabel = new Label
            {
                Text = String.Format("List : {0} | Due : {1}", listname, due),
                Font = new Font("Microsoft YaHei UI", 8),
                ForeColor = Color.Silver,
                Location = new Point(57, 41),
                AutoEllipsis = true,
                AutoSize = false,
                Width = 200
            };

            //status icon
            IconPictureBox statusIcon = new IconPictureBox
            {
                IconSize = 32,
                Location = new Point(640, 14),
                IconColor = Color.WhiteSmoke,
                Cursor = System.Windows.Forms.Cursors.Hand,
                Anchor = AnchorStyles.Right
            };

            // setting up an inportant icon
            IconPictureBox importantIcon = new IconPictureBox
            {
                IconChar = FontAwesome.Sharp.IconChar.Star,
                IconSize = 32,
                Location = new Point(600, 13),
                IconColor = Color.WhiteSmoke,
                Anchor = AnchorStyles.Right,
                Cursor = System.Windows.Forms.Cursors.Hand
            };
            
            // setting up an remiander icon

            IconPictureBox remainderIcon = new IconPictureBox
            {
                IconChar = FontAwesome.Sharp.IconChar.Bell,
                IconSize = 32,
                Location = new Point(560, 15),
                IconColor = Color.WhiteSmoke,
                Anchor = AnchorStyles.Right,
                Cursor = System.Windows.Forms.Cursors.Hand
            };

          
            if (remainder !="0")
            {
                remainderIcon.IconColor = Color.Orange;
                remainderIcon.IconFont = FontAwesome.Sharp.IconFont.Solid;
                generalToolTip.SetToolTip(remainderIcon, "Reaminder at: " + remainderDisplayFormat + ". Click to remove");
            }
           

            //setting up an delete icon
            IconPictureBox deleteIcon = new IconPictureBox
            {
                IconChar = FontAwesome.Sharp.IconChar.TrashAlt,
                IconSize = 25,
                Location = new Point(684, 17),
                IconColor = Color.WhiteSmoke,
                Anchor = AnchorStyles.Right,
                Cursor = System.Windows.Forms.Cursors.Hand
            };
            generalToolTip.SetToolTip(deleteIcon, "Delete the task");
            //adding its events
            deleteIcon.MouseEnter += new EventHandler(DeleteIconMouesEnter);
            deleteIcon.MouseLeave += new EventHandler(DeteleIconMouseLeave);
            deleteIcon.Click += new EventHandler(DeleteIconClickEvent);


            if (status != 2)
            {
                importantIcon.MouseEnter += new EventHandler(TaskImportantMouseEnter);
                importantIcon.MouseLeave += new EventHandler(TaskImportantMouseLeave);
                importantIcon.Click += new EventHandler(TaskImportantClickEvent);

                remainderIcon.MouseEnter += new EventHandler(ReminderIconMouesEnter);
                remainderIcon.MouseLeave += new EventHandler(RemainderIconMouseLeave);
                remainderIcon.Click += new EventHandler(RemainderIconClickEvent);

                generalToolTip.SetToolTip(importantIcon, "Mark it important");
                generalToolTip.SetToolTip(remainderIcon, "Add a remiander");
            }
            else
            {
                importantIcon.IconColor = Color.FromArgb(171,171,171);
                remainderIcon.IconColor = Color.FromArgb(171, 171, 171);
            }


            if ((DateTime.Compare(taskDate, today) < 0 ) && status != 2)
            {
                statusIcon.IconChar = FontAwesome.Sharp.IconChar.CalendarTimes;
                generalToolTip.SetToolTip(statusIcon, "Task experied. Change due");
                statusIcon.Click += new EventHandler(ChangeDueDateHandler);
                label1.Font = new Font("Microsoft YaHei UI", 8, FontStyle.Strikeout);
            }
            else if ((DateTime.Compare(taskDate, today) >= 0) && status == 2)
            {
                statusIcon.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
                statusIcon.IconColor = Color.Orange;
                generalToolTip.SetToolTip(statusIcon, "Task Completed");
                completeIcon.IconColor = Color.WhiteSmoke;
                completeIcon.IconFont = FontAwesome.Sharp.IconFont.Solid;
                generalToolTip.SetToolTip(completeIcon, "Task Completed");

                completeIcon.Click += new EventHandler(TaskCompleteClickEvent);
            }
            else
            {
                completeIcon.MouseEnter += new EventHandler(TaskCompleteMouseEnter);
                completeIcon.MouseLeave += new EventHandler(TaskCompleteMouseLeave);
                completeIcon.Click += new EventHandler(TaskCompleteClickEvent);


                statusIcon.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
                generalToolTip.SetToolTip(statusIcon, "Change due date");
                statusIcon.Click += new EventHandler(ChangeDueDateHandler);
            }

            if (isImportant)
            {
                importantIcon.IconColor = Color.Orange;
                importantIcon.IconFont = FontAwesome.Sharp.IconFont.Solid;
                generalToolTip.SetToolTip(importantIcon, "Important Task");
            }

            //adding all these elements to panel
            panel.Controls.Add(taskNameLabel);
            panel.Controls.Add(statusIcon);
            panel.Controls.Add(completeIcon);
            panel.Controls.Add(infoLabel);
            panel.Controls.Add(importantIcon);
            panel.Controls.Add(deleteIcon);
            panel.Controls.Add(remainderIcon);
            panel.Controls.Add(taskIDLabel);

            return panel;
        }
        //
        //Panel line maker
        //
        private Guna2Panel GetPanelLine()
        {
            Guna2Panel panel = new Guna2Panel
            {
                //setting width and height
                Width = 700,
                Height = 2,
                BackColor = Color.WhiteSmoke,
                //setting border
                BorderColor = Color.WhiteSmoke,
                BorderThickness = 1
            };
            return panel;
        }

        //
        //****************************************Click events on differnt components*******************************************
        //
        //Change password button
        //
        //adding a new list
        //
        
        private void ImportantTaskClickEvent(object sender, EventArgs e)
        {
            MakeAllActiveDisable();
            importantTasksActiveLine.Visible = true;
            //making main panel visible
            MakeAllPanelInVisible();
            mainPanelImportantTasks.Visible = true;
        }

        private void WeekTaskClickEvent(object sender, EventArgs e)
        {
            MakeAllActiveDisable();
            myWeekActiveLine.Visible = true;
            //making main panel visible
            MakeAllPanelInVisible();
            mainPanelMyWeek.Visible = true;
        }
        private void DayTaskClickEvent(object sender, EventArgs e)
        {
            MakeAllActiveDisable();
            myDayActiveLine.Visible = true;
            //making main panel visible
            MakeAllPanelInVisible();
            mainPanelMyDay.Visible = true;
        }

        private void AllTasksClickEvent(object sender, EventArgs e)
        {
            MakeAllActiveDisable();
            tasksActiveLine.Visible = true;
            //making main panel visible
            MakeAllPanelInVisible();
            mainPanelTasks.Visible = true;
        }

        private void ListPanelClickEvent(object sender, EventArgs e)
        {
            MakeAllActiveDisable();
            myListActiveLine.Visible = true;
            //making main panel visible
            MakeAllPanelInVisible();
            mainPanelMyList.Visible = true;
        }

        private void SettingPanelClickEvent(object sender, EventArgs e)
        {
            MakeAllActiveDisable();
            settingActiveLine.Visible = true;
            //making main panel visible
            MakeAllPanelInVisible();
            mainPanelSettings.Visible = true;
        }

        private void addToListButton_Click_1(object sender, EventArgs e)
        {
            int heightOfPanel = availableListShowPanel.Height;
            int heightOfMainPanel = 550;
            int heightOfAddTask = 64;
            int newLocationX = 465;
            int newLocationY = (heightOfMainPanel - heightOfAddTask - heightOfPanel) + 30;
            availableListShowPanel.Location = new Point(newLocationX, newLocationY);
            mainPanel.Controls.Add(availableListShowPanel);
            availableListShowPanel.BringToFront();
            availableListShowPanel.Visible = true;

        }
        private void addListButton_Click(object sender, EventArgs e)
        {
            if (firstTimeForList)
            {
                allListPanel.Controls.Remove(allListPanel.Controls["noPanel"]);
                firstTimeForList = false;
            }

            string listname = addListText.Text;
            UserList l = dataAccess.GetListObject(listname);



            Guna2Panel panel = MakeListPanel(l);
            allListPanel.Controls.Add(panel);

            panel.Dock = System.Windows.Forms.DockStyle.Top;
            //added to database
            dataAccess.AddNewList(l);

            availableListShowPanel.Controls.Clear();
            IntializeListPanel();

            AddEventListnersToAvailableLists();

            listFilterInTasks.Items.Clear();
            PerformSuccessfulListAddition();

        }
        //
        //Add new task button Click Event
        //
        private void addTaskButton_Click(object sender, EventArgs e)
        {
            dataAccess.collectUserLists();
            List<UserList> list = dataAccess.UserLists;
            if (list.Count>0)
            {
                if (firstTimeForTasks)
                {
                    allTasksListPanel.Controls.Remove(allTasksListPanel.Controls["noPanel"]);
                    firstTimeForTasks = false;
                }                
                UserList selectedList = null;
                string listname = addToListButton.Text;
                string taskname = addTaskInputTaskName.Text;
                DateTime dueDate = dateTimePickerAddTask.Value.Date;
                DateTime today = DateTime.Now.Date;

                //making due date
                string dueDateString = MakeStringReprentationDate(dueDate);
                //making start date
                string startDateString = MakeStringReprentationDate(today);


                if (taskname.Equals(""))
                    taskname = "New Task";
                if (listname == "Add to list")
                {
                    selectedList = list[0];
                }
                else
                {
                    foreach (UserList l in list)
                    {
                        if (l.Listname == listname)
                        {
                            selectedList = l;
                            break;
                        }
                    }
                }              

                Panel frontPanel = GetFrontPanel();
                if (frontPanel.Name == "importantTasksShowPanel")
                {
                    //adding task to database
                    Task task = dataAccess.AddNewTask(taskname, startDateString, dueDateString, 1, 1, selectedList.ListID);

                    Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, selectedList.Listname, task.EndDate, true, task.State, task.Remainder);
                    importantTasksShowPanel.Controls.Add(panel1);
                    panel1.Dock = System.Windows.Forms.DockStyle.Top;

                    Guna2Panel panel2 = MakeTaskPanel(task.TaskID, task.TaskText, selectedList.Listname, task.EndDate, true, task.State, task.Remainder);
                    allTasksListPanel.Controls.Add(panel2);
                    panel2.Dock = System.Windows.Forms.DockStyle.Top;

                    //checking and putting a task in daily nad weekly due tasks
                    PutWeekAndTodayDue(task, selectedList);
                }
                else
                {
                    Task task = dataAccess.AddNewTask(taskname, startDateString, dueDateString, 0, 1, selectedList.ListID);
                    Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, selectedList.Listname, task.EndDate, false, task.State, task.Remainder);
                    
                    allTasksListPanel.Controls.Add(panel1);
                    panel1.Dock = System.Windows.Forms.DockStyle.Top;

                    //checking and putting a task in daily nad weekly due tasks
                    PutWeekAndTodayDue(task, selectedList);
                }
                
                //empty the input fields
                addTaskInputTaskName.Text = "";
                addToListButton.Text = "Add to List";
                dateTimePickerAddTask.Value = DateTime.Now.Date;
                //calling a funciton to display successfulness
                PerformSuccessfulOperation();
                ChangeNumberTaskInListPanel(Convert.ToString(selectedList.ListID),true);
            }
            else
            {
                string message = "Add a list to map the task with";
                string title = "Information";
                MessageBox.Show(message,title);
                addTaskInputTaskName.Text = "";
            }        
           
        }

        private void ChangeNumberTaskInListPanel(string listID,bool operation)
        {
            Guna2Panel panel=new Guna2Panel();
            for(int i=0;i< allListPanel.Controls.Count; i++)
            {
                if (allListPanel.Controls[i].Controls["id"].Text == listID)
                {
                    panel = (Guna2Panel)allListPanel.Controls[i];
                    int tasks = Convert.ToInt32(panel.Controls[3].Text.Split(':')[1]);
                    if (operation)
                        tasks++;
                    else
                        tasks--;
                    panel.Controls[3].Text = String.Format("Total tasks : {0}", tasks);
                    break;
                }
            }
            
        }
        //
        //Edit settings click event
        //
        private void editSettings_Click(object sender, EventArgs e)
        {
            saveChangesButton.Enabled = true;
            fnameTextBox.ReadOnly = false;
            fnameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            lnameTextBox.ReadOnly = false;
            lnameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            emailTextBox.ReadOnly = false;
            emailTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
        }

        private string newPassword = "";
        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            if (saveChangesButton.Enabled)
            {
                //update user data
                string fname = fnameTextBox.Text;
                string lname = lnameTextBox.Text;
                string email = emailTextBox.Text;
                if (newPassword.Equals(""))
                    newPassword = dataAccess.CurrentUser.Password;

                if (fname == dataAccess.CurrentUser.Firstname &&
                    lname == dataAccess.CurrentUser.Lastname &&
                    email == dataAccess.CurrentUser.Email &&
                    newPassword == dataAccess.CurrentUser.Password)
                {
                    PerformNoChanges();
                }
                else
                {
                    //database access
                    dataAccess.UpdateUser(fname, lname, email, newPassword);
                    PerformSuccessfullSaveChanges();
                }
                fnameTextBox.ReadOnly = true;
                lnameTextBox.ReadOnly = true;
                emailTextBox.ReadOnly = true;
            }
        }
        //change password click Event
        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            string currentPass = currentPassTextBox.Text;
            string newPass1 = newPass1TextBox.Text;
            string newPass2 = newPass2TextBox.Text;

            if (currentPass == dataAccess.CurrentUser.Password)
            {
                if (newPass1 == newPass2)
                {
                    if (newPass1 != "" && newPass2 != "")
                    {
                        saveChangesButton.Enabled = true;
                        newPassword = newPass1;
                    }
                    else
                    {
                        newPass1TextBox.BorderColor = Color.Red;
                        newPass1TextBox.BorderThickness = 2;
                        newPass2TextBox.BorderThickness = 2;
                        newPass2TextBox.BorderColor = Color.Red;
                    }
                }
                else
                {
                    newPass1TextBox.BorderColor = Color.Red;
                    newPass1TextBox.BorderThickness = 2;
                    newPass2TextBox.BorderThickness = 2;
                    newPass2TextBox.BorderColor = Color.Red;
                    passwordDoesNotMatchError.Visible = true;
                }
            }
            else
            {
                currentPassTextBox.BorderColor = Color.Red;
                currentPassTextBox.BorderThickness = 2;
                incorrectPasswordError.Visible = true;
            }
        }
        //
        //text change in password field
        //
        private void currentPassTextBox_TextChanged(object sender, EventArgs e)
        {
            currentPassTextBox.BorderColor = Color.WhiteSmoke;
            currentPassTextBox.BorderThickness = 1;
            incorrectPasswordError.Visible = false;
        }
        //
        //text change in password field
        //
        private void newPass1TextBox_TextChanged(object sender, EventArgs e)
        {
            newPass1TextBox.BorderColor = Color.WhiteSmoke;
            newPass1TextBox.BorderThickness = 1;
            newPass2TextBox.BorderThickness = 1;
            newPass2TextBox.BorderColor = Color.WhiteSmoke;
            passwordDoesNotMatchError.Visible = false;
        }
        //
        //text change in password field
        //
        private void seePasswordCheckBoxNewPassword_CheckedChanged(object sender, EventArgs e)
        {
            currentPassTextBox.PasswordChar = seePasswordCheckBoxNewPassword.Checked ? '\0' : '●';
            newPass1TextBox.PasswordChar = seePasswordCheckBoxNewPassword.Checked ? '\0' : '●';
            newPass2TextBox.PasswordChar = seePasswordCheckBoxNewPassword.Checked ? '\0' : '●';
        }
        //
        //logout button click event
        //
        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Startup().Show();
        }
        //
        //Delete Account button click event handler
        //
        private void deleteAccountButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Delete Account", "Confirmation", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                dataAccess.RemoveUser();
                this.Hide();
                new Startup().Show();
            }
        }
        private void AddColor(object sender, EventArgs e)
        {

            Panel panelName = ((Panel)sender);
            panelName.BackColor = Color.FromArgb(25, 25, 25);

        }
        private void RemoveColor(object sender, EventArgs e)
        {
            Panel panelName = ((Panel)sender);
            panelName.BackColor = Color.FromArgb(36, 36, 36);
        }

        private void AddLabelColor(object sender, EventArgs e)
        {
            Panel panelName = (Panel)(((Label)sender).Parent);
            panelName.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void RemoveLabelColor(object sender, EventArgs e)
        {
            Panel panelName = (Panel)(((Label)sender).Parent);
            panelName.BackColor = Color.FromArgb(36, 36, 36);
        }

        private void AddIconColor(object sender, EventArgs e)
        {
            Panel panel = (Panel)(((IconPictureBox)sender).Parent);
            panel.BackColor = Color.FromArgb(25, 25, 25);
        }

        private void RemoveIconColor(object sender, EventArgs e)
        {
            Panel panel = (Panel)(((IconPictureBox)sender).Parent);
            panel.BackColor = Color.FromArgb(36, 36, 36);

        }
        private void HandleSelectedList(object sender, EventArgs e)
        {
            IconButton button = ((IconButton)sender);
            addToListButton.Text = button.Text;
            availableListShowPanel.Visible = false;
        }
        //
        //
        //************************************************my evenet handlers******************************************************
        //
        //--------------------------------------------Task Compelete Icon Events---------------------------------------------------
        //
        //Task Complelete Click event
        //
        private void TaskCompleteClickEvent(object sender, EventArgs e)
        {
            mouseCliked = true;

            IconPictureBox senderIcon = (IconPictureBox)sender;
            senderIcon.IconFont = FontAwesome.Sharp.IconFont.Solid;

            string taskID = senderIcon.Parent.Controls["id"].Text;

            Task task = GetTaskFromID(taskID);        

            UserList taskList = GetListFromListID(task.ListID);

            Panel panel = GetPanelFromTaskIDFromAllTasks(task.TaskID);

            IconPictureBox icon = (IconPictureBox)panel.Controls[2];

            IconPictureBox statusIcon = (IconPictureBox)panel.Controls[1];


            if (task.State == 1)
            {
                icon.IconFont = FontAwesome.Sharp.IconFont.Solid;
                statusIcon.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
                statusIcon.IconColor = Color.Orange;
                generalToolTip.SetToolTip(statusIcon, "Task Completed");
                generalToolTip.SetToolTip(icon, "Mark it uncomplete");

                //disposing panels from other panels on completion

                Panel importantPanel = GetPanelFromTaskIDFromImportantTasks(task.TaskID);
                if (importantPanel != null)
                {
                    importantPanel.Dispose();
                }

                Panel weekPanel = GetPanelFromTaskIDFromWeekTasks(task.TaskID);
                if (weekPanel != null)
                {
                    weekPanel.Dispose();
                }

                Panel todayPanel= GetPanelFromTaskIDFromTodayTasks(task.TaskID);
                if (todayPanel != null)
                {
                    todayPanel.Dispose();
                }

                //save to database
                dataAccess.UpdateTaskStatus(task.TaskID, 2);

                //disabling elements on it
                Panel p = GetPanelFromTaskIDFromAllTasks(task.TaskID);

                IconPictureBox remainderIcon = (IconPictureBox)p.Controls[6];
                remainderIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
                //updating database remove remainder
                dataAccess.RemoveRemainder(task.TaskID);

                IconPictureBox importantIcon = (IconPictureBox)p.Controls[4];
                importantIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
                //updating database update priority
                dataAccess.UpdateTaskPriority(task.TaskID, 0);

                remainderIcon.MouseEnter -= ReminderIconMouesEnter;
                remainderIcon.MouseLeave -= RemainderIconMouseLeave;
                remainderIcon.Click -= RemainderIconClickEvent;

                importantIcon.MouseEnter -= TaskImportantMouseEnter;
                importantIcon.MouseLeave -= TaskImportantMouseLeave;
                importantIcon.Click -= TaskImportantClickEvent;

                importantIcon.IconColor = Color.FromArgb(171,171,171);
                remainderIcon.IconColor = Color.FromArgb(171, 171, 171);

                generalToolTip.SetToolTip(importantIcon, "");
                generalToolTip.SetToolTip(remainderIcon, "");

            }
            else if (task.State == 2)
            {
                icon.IconFont = FontAwesome.Sharp.IconFont.Auto;
                statusIcon.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
                statusIcon.IconColor = Color.WhiteSmoke;
                generalToolTip.SetToolTip(statusIcon, "Change due date");

                DateTime taskDate = DateTime.ParseExact(task.EndDate, "MM/dd/yyyy",
                                     System.Globalization.CultureInfo.InvariantCulture).Date;
                DateTime today = DateTime.Now.Date;

                UserList l = GetListFromListID(task.TaskID);               
               

                //addig tasks in other panels

                if (task.Priority == 1)
                {
                    Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, l.Listname, task.EndDate, true, 1, task.Remainder);
                    importantTasksShowPanel.Controls.Add(panel1);
                    panel1.Dock = System.Windows.Forms.DockStyle.Top;
                }
                
                //checking and puttin weke and today due tasks
                PutWeekAndTodayDue(task, l); 

                //save to database
                dataAccess.UpdateTaskStatus(task.TaskID, 1);

                //enabling elements on it
                Panel p = GetPanelFromTaskIDFromAllTasks(task.TaskID);
                IconPictureBox remainderIcon = (IconPictureBox)p.Controls[6];
                IconPictureBox importantIcon = (IconPictureBox)p.Controls[4];

                remainderIcon.MouseEnter += new EventHandler(ReminderIconMouesEnter);
                remainderIcon.MouseLeave += new EventHandler(RemainderIconMouseLeave);
                remainderIcon.Click += new EventHandler(RemainderIconClickEvent);

                importantIcon.MouseEnter += new EventHandler(TaskImportantMouseEnter);
                importantIcon.MouseLeave += new EventHandler(TaskImportantMouseLeave);
                importantIcon.Click += new EventHandler(TaskImportantClickEvent);

                importantIcon.IconColor = Color.WhiteSmoke;
                remainderIcon.IconColor = Color.WhiteSmoke;

                generalToolTip.SetToolTip(importantIcon, "Mark it important");
                generalToolTip.SetToolTip(remainderIcon, "Add a remiander");
            }
        }
        //
        // Task compelete Mouse Leave Event
        //
        private void TaskCompleteMouseLeave(object sender, EventArgs e)
        {
            if (!alreadyCompleted && !mouseCliked)
            {
                IconPictureBox box = ((IconPictureBox)sender);
                box.IconFont = FontAwesome.Sharp.IconFont.Auto;
            }
        }
        //
        //Task Compelete Mouse Enter Event
        //
        private void TaskCompleteMouseEnter(object sender, EventArgs e)
        {
            IconPictureBox box = ((IconPictureBox)sender);
            if (box.IconFont == FontAwesome.Sharp.IconFont.Solid)
            {
                alreadyCompleted = true;
            }
            else
            {
                box.IconFont = FontAwesome.Sharp.IconFont.Solid;
                alreadyCompleted = false;
                mouseCliked = false;
            }
        }
        //
        //-----------------------------------------------Export icon Events------------------------------------------------
        //
        //Export click event
        //
        private void ExportAllListIconMouesClick(object sender, EventArgs e)
        {
             string taskText = "";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Browse Text Files";
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.Filter = "Pdf Files|*.pdf";
            saveFileDialog.FilterIndex = 0;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName == "")
                    saveFileDialog.FileName = "ToDo Lists";
                PdfDocument doc = new PdfDocument();
                doc.Info.Title = "Created with PDFsharp";
                PdfPage oPage = doc.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(oPage);
                XFont font = new XFont("Verdana", 12, XFontStyle.Regular);                

                int py = 5;

                dataAccess.collectUserLists();
                foreach(UserList l in dataAccess.UserLists)
                {
                    gfx.DrawString("List name : " + l.Listname, font, XBrushes.Black,
                    new XRect(5, py, oPage.Width, oPage.Height), XStringFormat.TopLeft);

                    foreach (Task t in dataAccess.GetListTasks(l.ListID))
                    {
                        py += 20;
                        taskText += "Task name : " + t.TaskText + "   |   Due Date : " + t.EndDate;
                        gfx.DrawString(taskText, font, XBrushes.Black,
                        new XRect(10, py, oPage.Width, oPage.Height), XStringFormat.TopLeft);                       
                        taskText = "";
                    }
                    py += 20;                    
                }                

                string filename = Path.GetFullPath(saveFileDialog.FileName);
                doc.Save(filename);
                Process.Start(filename);
            }
        }


        private void ExportIconMouesClick(object sender, EventArgs e)
        {
            Panel panel = (Panel)((IconPictureBox)sender).Parent;
            int listID = Convert.ToInt32(((Label)panel.Controls[0]).Text);
            string listName = ((Label)panel.Controls[2]).Text;
            string taskText = "";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Browse Text Files";
            saveFileDialog.DefaultExt = "pdf";
            saveFileDialog.Filter = "Pdf Files|*.pdf";
            saveFileDialog.FilterIndex = 0;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName == "")
                    saveFileDialog.FileName = listName;
                PdfDocument doc = new PdfDocument();
                doc.Info.Title = "Created with PDFsharp";
                PdfPage oPage = doc.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(oPage);
                XFont font = new XFont("Verdqana", 12, XFontStyle.Regular);

                gfx.DrawString("List name : " + listName, font, XBrushes.Black,
                new XRect(5, 5, oPage.Width, oPage.Height), XStringFormat.TopLeft);

                int py = 40;

                foreach (Task t in dataAccess.GetListTasks(listID))
                {
                    taskText += "Task name : " + t.TaskText + "   |   Due Date : " + t.EndDate;
                    gfx.DrawString(taskText, font, XBrushes.Black,
                    new XRect(5, py, oPage.Width, oPage.Height), XStringFormat.TopLeft);
                    py += 20;
                    taskText = "";
                }

                string filename = Path.GetFullPath(saveFileDialog.FileName);
                doc.Save(filename);
                Process.Start(filename);
            }
        }
        //
        //Export Icon Mouse Leave event
        //
        private void ExportIconMouesLeave(object sender, EventArgs e)
        {
            IconPictureBox box = ((IconPictureBox)sender);
            box.IconColor = Color.WhiteSmoke;
        }
        //
        //Export Icon Mouse Leave event
        //
        private void ExportIconMouesEnter(object sender, EventArgs e)
        {
            IconPictureBox box = ((IconPictureBox)sender);
            box.IconColor = Color.Orange;
        }
        //
        //------------------------------------------Task Important Click Events---------------------------------------------------
        //
        //
        //Task Important Click Event
        //
        private void TaskImportantClickEvent(object sender, EventArgs e)
        {
            mouseCliked = true;
            IconPictureBox icon = (IconPictureBox)sender;
            string taskID = icon.Parent.Controls["id"].Text;
            Task task = GetTaskFromID(taskID);
            UserList taskList = GetListFromListID(task.ListID);

            Panel taskPanel = GetPanelFromTaskIDFromAllTasks(task.TaskID);
            Panel wPanel = GetPanelFromTaskIDFromWeekTasks(task.TaskID);
            Panel tPanel = GetPanelFromTaskIDFromTodayTasks(task.TaskID);
            Panel iPanel = GetPanelFromTaskIDFromImportantTasks(task.TaskID);


            if (task.Priority == 1)
            {
                if (taskPanel != null)
                {
                    IconPictureBox iconBox = (IconPictureBox)taskPanel.Controls[4];
                    iconBox.IconColor = Color.WhiteSmoke;
                    iconBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
                }

                if (wPanel != null)
                {
                    IconPictureBox iconBox = (IconPictureBox)wPanel.Controls[4];
                    iconBox.IconColor = Color.WhiteSmoke;
                    iconBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
                }

                if (tPanel != null)
                {
                    IconPictureBox iconBox = (IconPictureBox)tPanel.Controls[4];
                    iconBox.IconColor = Color.WhiteSmoke;
                    iconBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
                }

                if (iPanel != null)
                {
                    iPanel.Dispose();
                }

                //sending to database
                dataAccess.UpdateTaskPriority(task.TaskID, 0);
            }
            else
            {
                if (taskPanel != null)
                {
                    IconPictureBox iconBox = (IconPictureBox)taskPanel.Controls[4];
                    iconBox.IconColor = Color.Orange;
                    iconBox.IconFont = FontAwesome.Sharp.IconFont.Solid;
                }

                if (wPanel != null)
                {
                    IconPictureBox iconBox = (IconPictureBox)wPanel.Controls[4];
                    iconBox.IconColor = Color.Orange;
                    iconBox.IconFont = FontAwesome.Sharp.IconFont.Solid;
                }

                if (tPanel != null)
                {
                    IconPictureBox iconBox = (IconPictureBox)tPanel.Controls[4];
                    iconBox.IconColor = Color.Orange;
                    iconBox.IconFont = FontAwesome.Sharp.IconFont.Solid;
                }

                //replacing to important task in important tasks
                Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, taskList.Listname, task.EndDate, true, task.State, task.Remainder);
                importantTasksShowPanel.Controls.Add(panel1);
                panel1.Dock = System.Windows.Forms.DockStyle.Top;

                //sending to database
                dataAccess.UpdateTaskPriority(task.TaskID, 1);
            }
        }
        //
        //Task important Mouse Leave Event
        //
        private void TaskImportantMouseLeave(object sender, EventArgs e)
        {
            if (!alreadyImportant && !mouseCliked)
            {
                IconPictureBox box = ((IconPictureBox)sender);
                box.IconColor = Color.WhiteSmoke;
                box.IconFont = FontAwesome.Sharp.IconFont.Auto;
            }
        }
        //
        //Task important Mouse Enter Event
        //
        private void TaskImportantMouseEnter(object sender, EventArgs e)
        {
            IconPictureBox box = (IconPictureBox)sender;
            if (box.IconColor == Color.Orange)
            {
                alreadyImportant = true;
            }
            else
            {
                box.IconColor = Color.Orange;
                box.IconFont = FontAwesome.Sharp.IconFont.Solid;
                mouseCliked = false;
                alreadyImportant = false;
            }
        }
        //
        //------------------------------------------List & Task Delete Click Events---------------------------------------------------
        //
        //
        //Task delete Mouse Click Event
        //
        private void DeleteListClickEvent(object sender, EventArgs e)
        {
            mouseCliked = true;
            Panel panel = (Panel)((IconPictureBox)sender).Parent;
            int listID = Convert.ToInt32(((Label)panel.Controls["id"]).Text);

            UserList l = GetListFromListID(listID);            

            var confirmResult = MessageBox.Show("Are you sure to delete this List",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                panel.Controls.Clear();
                Label label = new Label
                {
                    Text = "List Deleted Successfully",
                    Font = new Font("Microsoft YaHei UI", 11),
                    ForeColor = Color.Orange,
                    Location = new Point(14, 22)
                };
                panel.Controls.Add(label);
                label.AutoEllipsis = true;
                label.AutoSize = false;
                label.Width = 350;
                //add to database

                dataAccess.RemoveList(l.ListID); 
                
                RefreshAllPanels();

                if (allListPanel.Controls.Count == 1)
                {
                    allListPanel.Controls.Clear();
                    Panel noTaskPanel = NoTaskDisplayMaker();
                    allListPanel.Controls.Add(noTaskPanel);
                    noTaskPanel.BringToFront();
                    firstTimeForTasks = true;
                }
                else
                {
                    PerformSuccessfulOperationOnDelete(panel);
                }
            }
        }
        //
        //Delete Task Click Event
        //
        private void DeleteIconClickEvent(object sender, EventArgs e)
        {
            // delete the task 
            var confirmResult = MessageBox.Show("Are you sure to delete this task",
                                     "Confirm Delete",
                                     MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                string taskID = ((Label)((IconPictureBox)sender).Parent.Controls["id"]).Text;               
                Task task = GetTaskFromID(taskID);
                dataAccess.RemoveTask(task.TaskID);
                Panel panel = (Panel)((IconPictureBox)sender).Parent;
                panel.Controls.Clear();
                Label label = new Label
                {
                    Text = "Task Deleted Successfully",
                    Font = new Font("Microsoft YaHei UI", 11),
                    ForeColor = Color.Orange,
                    Location = new Point(14, 22)
                };
                panel.Controls.Add(label);
                label.AutoEllipsis = true;
                label.AutoSize = false;
                label.Width = 350;

                Panel p = GetPanelFromTaskIDFromWeekTasks(task.TaskID);
                if (p != null)
                    p.Dispose();

                Panel p1 = GetPanelFromTaskIDFromTodayTasks(task.TaskID);
                if (p1 != null)
                    p1.Dispose();

                Panel p2 = GetPanelFromTaskIDFromImportantTasks(task.TaskID);
                if (p2 != null)
                    p2.Dispose();

                //decrement number of tasks in list realtime
                ChangeNumberTaskInListPanel(Convert.ToString(task.ListID), false);

                if (allTasksListPanel.Controls.Count == 1)
                {
                    allTasksListPanel.Controls.Clear();
                    Panel noTaskPanel = NoTaskDisplayMaker();
                    allTasksListPanel.Controls.Add(noTaskPanel);
                    noTaskPanel.BringToFront();
                    firstTimeForTasks = true;
                }
                else
                {
                    PerformSuccessfulOperationOnDelete(panel);
                }              
            }
        }
        //
        //Task delete Mouse Leave Event
        //
        private void DeteleIconMouseLeave(object sender, EventArgs e)
        {
            IconPictureBox box = ((IconPictureBox)sender);
            box.IconColor = Color.WhiteSmoke;
        }
        //
        //Task delete Mouse Enter Event
        //
        private void DeleteIconMouesEnter(object sender, EventArgs e)
        {
            IconPictureBox box = ((IconPictureBox)sender);
            box.IconColor = Color.Red;
        }
        //
        //------------------------------------change date handlers (due date  for task)-------------------------------------------
        //
        //it visibles the data picker on the screen
        //
        private void ChangeDueDateHandler(object sender, EventArgs e)
        {
            IconPictureBox icon = (IconPictureBox)sender;
            Panel panel = (Panel)icon.Parent.Parent;
            dateChangePanel = ((Panel)icon.Parent);

            //to make the date time visible           
            panel.Controls.Add(dateTimePicker);
            dateTimePicker.BringToFront();

            dateTimePicker.Visible = !dateTimePicker.Visible;
            dateTimePicker.MinDate = DateTime.Today;

            dateTimePicker.Width = 150;

            dateTimePicker.Left = (panel.Left + icon.Right) - dateTimePicker.Width;
            dateTimePicker.Top = icon.Top + 30 + ((Panel)icon.Parent).Top;
        }
        //
        //It occurs when data value changed
        //
        private void ChangeDateHandler(object sender, EventArgs e)
        {
            dateTimePicker.Visible = false;

            Task task = GetTaskFromID(((Label)dateChangePanel.Controls["id"]).Text);
            UserList l = GetListFromListID(task.ListID);
            DateTime date = dateTimePicker.Value;
            string stringDate = MakeStringReprentationDate(date);
            Label label = (Label)dateChangePanel.Controls[3];

            IconPictureBox icon = (IconPictureBox)dateChangePanel.Controls[1];
            //not experied
            if (icon.IconChar == FontAwesome.Sharp.IconChar.CalendarAlt)
            {
                label.Text = String.Format("List : {0} | Due : {1}", l.Listname, stringDate);
                //store in the database
                dataAccess.updateTaskDuedate(task.TaskID, stringDate);
                PerformSuccessfulOfDateChange(label);
            }
            else //experied
            {
                //change the font                
                label.Font = new Font("Microsoft YaHei UI", 8);
                //change the label 
                label.Text = String.Format("List : {0} | Due : {1}", l.Listname, stringDate);
                //change the icon
                icon.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;

                //store in the database
                dataAccess.updateTaskDuedate(task.TaskID, stringDate);
                PerformSuccessfulOfDateChangeExpire(label, icon);
            }
        }

        //
        //-------------------------------------------------Remainder Icon Event handlers------------------------------------------
        //
        //Remainder icon click event
        //
        private void RemainderIconClickEvent(object sender, EventArgs e)
        {
            //DateTime myDate = datePortionDateTimePicker.Value.Date +
            //        timePortionDateTimePicker.Value.TimeOfDay;

            remainderIcon = (IconPictureBox)sender;
            string taskID = remainderIcon.Parent.Controls["id"].Text;

            remainderChangedTask = GetTaskFromID(taskID);
            Panel taskPanel = (Panel)remainderIcon.Parent;

            Panel panel = (Panel)remainderIcon.Parent.Parent;


            if (remainderChangedTask.Remainder == "0")
            {
                if (datetimePanel.Controls.Count == 0)
                {
                    //to make the date time visible                

                    Guna2Button submittButton = new Guna2Button
                    {
                        Text = "Add Remainder",
                        Width = 190,
                        Height = 35,
                        BorderThickness = 2,
                        BorderColor = Color.White,
                        FillColor = Color.FromArgb(26, 27, 28),
                        Top = 40,
                        Left = 11,
                        Cursor = System.Windows.Forms.Cursors.Hand
                    };

                    submittButton.Click += AddRemainderClickEvent;

                    datetimePanel.Controls.Add(datePickerRemainder);
                    datetimePanel.Controls.Add(timePickerRemainder);
                    datetimePanel.Controls.Add(submittButton);
                    datetimePanel.Visible = !datetimePanel.Visible;

                    panel.Controls.Add(datetimePanel);                 

                    datetimePanel.Top = taskPanel.Top+remainderIcon.Top + 33;
                    datetimePanel.Left = remainderIcon.Left - 92;

                    datetimePanel.BringToFront();
                }
                else
                {
                    panel.Controls.Add(datetimePanel);

                    datetimePanel.Top = remainderIcon.Top + 33;
                    datetimePanel.Left = remainderIcon.Left - 92;
                    datetimePanel.BringToFront();

                    datetimePanel.Visible = !datetimePanel.Visible;
                }
            }
            else
            {
                remainderIcon.IconColor = Color.WhiteSmoke;
                remainderIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
                generalToolTip.SetToolTip(remainderIcon, "Add a remainder");
                dataAccess.UpdateRemainder(remainderChangedTask.TaskID, "");
            }
        }
        //
        //Remainder icon button submitt click button
        //
        private void AddRemainderClickEvent(object sender, EventArgs e)
        {
            DateTime date = datePickerRemainder.Value;
            DateTime time = timePickerRemainder.Value;           

            string forwardString = MakeStringReprentationDate(date);
            if (time.Hour < 10)
            {
                forwardString += " 0" + time.Hour;
            }
            else
            {
                forwardString += " " + time.Hour;
            }
            if (time.Minute < 10)
            {
                forwardString += ":0" + time.Minute;
            }
            else
            {
                forwardString += ":" + time.Minute;
            }

            dataAccess.UpdateRemainder(remainderChangedTask.TaskID, forwardString);
            datetimePanel.Visible = false;

            // reflecting the same in other places
            // in important panels

            Panel taskPanel = GetPanelFromTaskIDFromAllTasks(remainderChangedTask.TaskID);
            Panel iPanel = GetPanelFromTaskIDFromImportantTasks(remainderChangedTask.TaskID);
            Panel wPanel = GetPanelFromTaskIDFromWeekTasks(remainderChangedTask.TaskID);
            Panel tPanel = GetPanelFromTaskIDFromTodayTasks(remainderChangedTask.TaskID);

            if (taskPanel != null)
            {
                IconPictureBox icon = (IconPictureBox)taskPanel.Controls[6];
                icon.IconColor = Color.Orange;
                icon.IconFont = FontAwesome.Sharp.IconFont.Solid;
                generalToolTip.SetToolTip(icon, "Remainder at: " + date.DayOfWeek + "  " + date.Month + "/" + date.Day + "/" + date.Year + "  " + time.Hour + ":" + time.Minute + " .Click to remove");
            }

            if (iPanel != null)
            {
                IconPictureBox icon = (IconPictureBox)iPanel.Controls[6];
                icon.IconColor = Color.Orange;
                icon.IconFont = FontAwesome.Sharp.IconFont.Solid;
                generalToolTip.SetToolTip(icon, "Remainder at: " + date.DayOfWeek + "  " + date.Month + "/" + date.Day + "/" + date.Year + "  " + time.Hour + ":" + time.Minute + " .Click to remove");
            }

            if (wPanel != null)
            {
                IconPictureBox icon = (IconPictureBox)wPanel.Controls[6];
                icon.IconColor = Color.Orange;
                icon.IconFont = FontAwesome.Sharp.IconFont.Solid;
                generalToolTip.SetToolTip(icon, "Remainder at: " + date.DayOfWeek + "  " + date.Month + "/" + date.Day + "/" + date.Year + "  " + time.Hour + ":" + time.Minute + " .Click to remove");
            }

            if (tPanel != null)
            {
                IconPictureBox icon = (IconPictureBox)tPanel.Controls[6];
                icon.IconColor = Color.Orange;
                icon.IconFont = FontAwesome.Sharp.IconFont.Solid;
                generalToolTip.SetToolTip(icon, "Remainder at: " + date.DayOfWeek + "  " + date.Month + "/" + date.Day + "/" + date.Year + "  " + time.Hour + ":" + time.Minute + " .Click to remove");
            }
        }
        //
        //Remainder Icon Mouse Leave
        //
        private void RemainderIconMouseLeave(object sender, EventArgs e)
        {
            if (!alreadyremainded && !remainderMouseClicked)
            {
                IconPictureBox box = ((IconPictureBox)sender);
                box.IconColor = Color.WhiteSmoke;
                box.IconFont = FontAwesome.Sharp.IconFont.Auto;
            }
        }
        //
        //Remainder Icon Mouse Enter
        //
        private void ReminderIconMouesEnter(object sender, EventArgs e)
        {
            IconPictureBox box = (IconPictureBox)sender;
            if (box.IconColor == Color.Orange)
            {
                alreadyremainded = true;
            }
            else
            {
                box.IconColor = Color.Orange;
                box.IconFont = FontAwesome.Sharp.IconFont.Solid;
                remainderMouseClicked = false;
                alreadyremainded = false;
            }
        }
        //
        //-----------------------------------------------Filter Events---------------------------------------------------------------
        //
        //
        //Selected index change
        //
        private void listFilterInTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int listIndex = listFilterInTasks.SelectedIndex;
            if (listIndex > 0)
            {
                filterAdded = true;
                UserList selectedList = list[listIndex - 1];
                //remove all other panels.
                allTasksListPanel.Controls.Clear();
                //making new
                foreach (Task task in dataAccess.GetListTasks(selectedList.ListID))
                {
                    DateTime taskDate = DateTime.ParseExact(task.EndDate, "MM/dd/yyyy",
                                      System.Globalization.CultureInfo.InvariantCulture);

                    if (task.Priority == 1)
                    {

                        Guna2Panel panel = MakeTaskPanel(task.TaskID, task.TaskText, selectedList.Listname, task.EndDate, true, task.State, task.Remainder);
                        allTasksListPanel.Controls.Add(panel);
                        panel.Dock = System.Windows.Forms.DockStyle.Top;
                    }
                    else
                    {
                        Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, selectedList.Listname, task.EndDate, false, task.State, task.Remainder);
                        allTasksListPanel.Controls.Add(panel1);
                        panel1.Dock = System.Windows.Forms.DockStyle.Top;
                    }
                }
            }            
        }
        //
        //filter task on the basis of date
        //
        private void filterDatePicker_ValueChanged(object sender, EventArgs e)
        {
            
            DateTime selectedDate = filterDatePicker.Value;
            //remove all other panels.
            allTasksListPanel.Controls.Clear();
            if (allTasksListPanel.Visible)
            {
                filterAdded = true;
            }            

            foreach (UserList userList in list)
            {
                foreach (Task task in dataAccess.GetListTasks(userList.ListID))
                {
                    DateTime taskDate = DateTime.ParseExact(task.EndDate, "MM/dd/yyyy",
                                      System.Globalization.CultureInfo.InvariantCulture);
                    if (taskDate.Day == selectedDate.Day && taskDate.Month == selectedDate.Month && taskDate.Year == selectedDate.Year)
                    {
                        if (task.Priority == 1)
                        {
                            Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, true, task.State, task.Remainder);
                            allTasksListPanel.Controls.Add(panel1);
                            panel1.Dock = System.Windows.Forms.DockStyle.Top;
                        }
                        else
                        {
                            Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, false, task.State, task.Remainder);
                            allTasksListPanel.Controls.Add(panel1);
                            panel1.Dock = System.Windows.Forms.DockStyle.Top;
                        }
                    }
                }
            }
        }
        //
        //Other filter tasks selected index change
        //        
        private void otherFilterOnTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedFilter = otherFilterOnTasks.SelectedIndex;
            if (selectedFilter > 0)
            {
                filterAdded = true;
                allTasksListPanel.Controls.Clear();
                allTasksListPanel.Hide();
                DateTime today = DateTime.Now;
                foreach (UserList userList in list)
                {
                    foreach (Task task in dataAccess.GetListTasks(userList.ListID))
                    {
                        DateTime taskDate = DateTime.ParseExact(task.EndDate, "MM/dd/yyyy",
                                          System.Globalization.CultureInfo.InvariantCulture);
                        if (selectedFilter == 1)
                        {
                            if (task.State == 2)
                            {
                                if (task.Priority == 1)
                                {
                                    Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, true, task.State, task.Remainder);
                                    allTasksListPanel.Controls.Add(panel1);
                                    panel1.Dock = System.Windows.Forms.DockStyle.Top;
                                }
                                else
                                {
                                    Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, false, task.State, task.Remainder);
                                    allTasksListPanel.Controls.Add(panel1);
                                    panel1.Dock = System.Windows.Forms.DockStyle.Top;
                                }
                            }
                        }
                        else if (selectedFilter == 2)
                        {
                            if (task.State != 2 && DateTime.Compare(taskDate, today) < 0)
                            {
                                if (task.Priority == 1)
                                {
                                    Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, true, task.State, task.Remainder);
                                    allTasksListPanel.Controls.Add(panel1);
                                    panel1.Dock = System.Windows.Forms.DockStyle.Top;
                                }
                                else
                                {
                                    Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, false, task.State, task.Remainder);
                                    allTasksListPanel.Controls.Add(panel1);
                                    panel1.Dock = System.Windows.Forms.DockStyle.Top;
                                }
                            }
                        }
                    }
                }
                allTasksListPanel.Show();
            }            
        }
        //
        //apply remove filter event
        //
        private void AddEventsToRemoveFilter()
        {
            filterCrossRemove.Click += new EventHandler(RemoveFilterHander);
            filterRemoveFunnel.Click += new EventHandler(RemoveFilterHander);
        }
        //
        //Remove filter handler
        //
        private void RemoveFilterHander(object sender, EventArgs e)
        {
            if (filterAdded)
            {
                allTasksListPanel.Controls.Clear();
                allTasksListPanel.Hide();

                foreach (UserList userList in list)
                {
                    foreach (Task task in dataAccess.GetListTasks(userList.ListID))
                    {
                        if (task.Priority == 1)
                        {
                            Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, true, task.State, task.Remainder);
                            allTasksListPanel.Controls.Add(panel1);
                            panel1.Dock = System.Windows.Forms.DockStyle.Top;
                        }
                        else
                        {
                            Guna2Panel panel1 = MakeTaskPanel(task.TaskID, task.TaskText, userList.Listname, task.EndDate, false, task.State, task.Remainder);
                            allTasksListPanel.Controls.Add(panel1);
                            panel1.Dock = System.Windows.Forms.DockStyle.Top;
                        }
                    }
                }
                allTasksListPanel.Show();
                filterAdded = false;
            }            
        }

        //
        //**********************************************Perform async operations*********************************************
        //
        private async void PerformSuccessfulOfDateChangeExpire(Label label, IconPictureBox icon)
        {
            icon.IconColor = Color.Orange;
            label.ForeColor = Color.Orange;
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2));
            icon.IconColor = Color.WhiteSmoke;
            label.ForeColor = Color.WhiteSmoke;
        }
        private async void PerformSuccessfulOfDateChange(Label label)
        {
            label.ForeColor = Color.Orange;
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2));
            label.ForeColor = Color.WhiteSmoke;
        }
        private async void PerformSuccessfulOperationOnDelete(Panel panel)
        {
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2));
            panel.Dispose();

        }

        // async operation
        private async void PerformSuccessfulOperation()
        {
            successfulMessagePanel.Visible = true;
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2));
            successfulMessagePanel.Visible = false;
        }
        private async void PerformSuccessfulListAddition()
        {
            successfulListAddiiton.Visible = true;
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2));
            successfulListAddiiton.Visible = false;
        }
        private async void PerformSuccessfullSaveChanges()
        {
            saveChangesButton.Text = "Saved";
            saveChangesButton.FillColor = Color.FromArgb(0, 92, 0);
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2));
            saveChangesButton.Text = "Save Changes";
            saveChangesButton.FillColor = Color.FromArgb(15, 16, 17);

            saveChangesButton.Enabled = false;
        }

        private async void PerformNoChanges()
        {
            saveChangesButton.Text = "No Changes Detected";
            saveChangesButton.FillColor = Color.FromArgb(122, 0, 0);
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2));
            saveChangesButton.Text = "Save Changes";
            saveChangesButton.FillColor = Color.FromArgb(15, 16, 17);
            saveChangesButton.Enabled = false;
        }

        //
        //**************************************Adding remainder check***********************************
        //
        private void remiandTimer_Tick(object sender, EventArgs e)
        {
            dataAccess.collectUserLists();
            foreach (UserList userList in list)
            {
                foreach (Task task in dataAccess.GetListTasks(userList.ListID))
                {
                    if (task.Remainder != "0")
                    {
                        DateTime taskDate = DateTime.ParseExact(task.Remainder, "MM/dd/yyyy HH:mm",
                                     System.Globalization.CultureInfo.InvariantCulture);

                        DateTime now = DateTime.Now;
                        if (taskDate.Year == now.Year && taskDate.Month == now.Month && taskDate.Day == now.Day)
                        {
                            if (taskDate.Hour == now.Hour && taskDate.Minute == now.Minute)
                            {
                                taskNotification.Icon = SystemIcons.Exclamation;
                                taskNotification.BalloonTipTitle = "Task Remainder";
                                taskNotification.BalloonTipText = task.TaskText + " | Due is " + task.EndDate;
                                taskNotification.BalloonTipIcon = ToolTipIcon.Info;
                                taskNotification.Visible = true;
                                taskNotification.ShowBalloonTip(20000);
                                task.Remainder = "0";
                                //removing a remainder
                                dataAccess.RemoveRemainder(task.TaskID);
                                //reset icon
                                RemoveRemainder(task.TaskID);

                            }
                        }
                    }
                   
                }
            }
        }
        private void RemoveRemainder(int id)
        {
            Guna2Panel p = (Guna2Panel)GetPanelFromTaskIDFromAllTasks(id);
            IconPictureBox icon1 = (IconPictureBox)p.Controls[6];
            icon1.IconColor = Color.WhiteSmoke;
            icon1.IconFont = FontAwesome.Sharp.IconFont.Auto;

            Panel taskPanel = GetPanelFromTaskIDFromAllTasks(id);
            Panel iPanel = GetPanelFromTaskIDFromImportantTasks(id);
            Panel wPanel = GetPanelFromTaskIDFromWeekTasks(id);
            Panel tPanel = GetPanelFromTaskIDFromTodayTasks(id);

            if (taskPanel != null)
            {
                IconPictureBox icon = (IconPictureBox)taskPanel.Controls[6];
                icon.IconColor = Color.WhiteSmoke;
                icon.IconFont = FontAwesome.Sharp.IconFont.Auto;
                generalToolTip.SetToolTip(icon, "Add remainder");            
            }

            if (iPanel != null)
            {
                IconPictureBox icon = (IconPictureBox)iPanel.Controls[6];
                icon.IconColor = Color.WhiteSmoke;
                icon.IconFont = FontAwesome.Sharp.IconFont.Auto;
                generalToolTip.SetToolTip(icon, "Add remainder");
            }

            if (wPanel != null)
            {
                IconPictureBox icon = (IconPictureBox)wPanel.Controls[6];
                icon.IconColor = Color.WhiteSmoke;
                icon.IconFont = FontAwesome.Sharp.IconFont.Auto;
                generalToolTip.SetToolTip(icon, "Add remainder");
            }

            if (tPanel != null)
            {
                IconPictureBox icon = (IconPictureBox)tPanel.Controls[6];
                icon.IconColor = Color.WhiteSmoke;
                icon.IconFont = FontAwesome.Sharp.IconFont.Auto;
                generalToolTip.SetToolTip(icon, "Add remainder");
            }
        }
    }
}
