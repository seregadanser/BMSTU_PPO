using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_course.View
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
            button1.Click += delegate { ShowWorker?.Invoke(this, EventArgs.Empty); };
            button2.Click += delegate { ShowHrAdmin?.Invoke(this, EventArgs.Empty); };
            button3.Click += delegate { ShowAdmin?.Invoke(this, EventArgs.Empty); };
        }

        public string SearchValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsEdit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsSuccessful { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler ShowWorker;
        public event EventHandler ShowAdmin;
        public event EventHandler ShowWarer;
        public event EventHandler ShowHrAdmin;

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
