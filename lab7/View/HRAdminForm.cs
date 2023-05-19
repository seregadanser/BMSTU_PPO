using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_course.View
{
    public partial class HRAdminForm : Form, IHRAdminView
    {
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        public HRAdminForm()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPage2);
        }

        
        public void SetWorkerListBindingSource(BindingSource WorkerList)
        {
            dataGridView1.DataSource = WorkerList;
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Search
            Search.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            SearchText.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Add new
            Add.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                passwordText.Visible = true;
                label5.Visible = true;
                LoginText.Visible = true;
                label4.Visible = true;
                tabPage2.Text = "Add new worker";
            };
            //Edit
            Edit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Add(tabPage2);
                    passwordText.Visible = false;
                    label5.Visible = false;
                    LoginText.Visible = false;
                    label4.Visible = false;
                    tabPage2.Text = "Edit worker";
                }
                else
                    MessageBox.Show(Message);
              
            };
            //Save changes
             Save.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Add(tabPage1);
                }
                MessageBox.Show(Message);
            };
            //Cancel
            Cancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage1);
            };
            //Delete
            Delit.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected worker?", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public string WorkerName { get { return NameText.Text; } set { NameText.Text = value; } }
        public string WorkerSecondName { get { return SecondNameText.Text; } set { SecondNameText.Text = value; } }
        public string WorkerPosition { get { return (string)comboBox1.SelectedItem; } set { comboBox1.SelectedIndex = 0; } }
        public string WorkerBirthday { get { return BirthdayText.Text; } set { BirthdayText.Text = value; } }
        public string WorkerLogin { get { return LoginText.Text; } set { LoginText.Text = value; } }
        public string WorkerPassword { get { return passwordText.Text; } set { passwordText.Text = value; } }
        public string SearchValue { get { return SearchText.Text; } set { SearchText.Text = value; } }
        public bool IsEdit { get { return isEdit; } set { isEdit = value; } }
        public bool IsSuccessful { get { return isSuccessful; } set { isSuccessful = value; } } 
        public string Message { get { return message; } set { message = value; } }

        private static HRAdminForm instance;
        public static  HRAdminForm GetInstace(Form parentContainer)
        {
            if(instance == null || instance.IsDisposed)
            {
                instance = new HRAdminForm
                {
                    MdiParent = parentContainer
                };
                //instance.FormBorderStyle = FormBorderStyle.None;
                //instance.Dock = DockStyle.Fill;
            }
            else
            {
                if(instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        public static HRAdminForm GetInstace()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new HRAdminForm();
                //instance.FormBorderStyle = FormBorderStyle.None;
                //instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
          
        }
        private void HRAdminForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SearchText_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellErrorTextNeeded(object sender, DataGridViewCellErrorTextNeededEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Columns.Count > 7)
            {
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {

        }
    }
}
