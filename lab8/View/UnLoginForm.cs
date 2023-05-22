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
    public partial class UnLoginForm : Form, IUnLoginView
    {
        public UnLoginForm()
        {
            InitializeComponent();

            buttonOK.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public string WorkerLogin { get => textLogin.Text; set => throw new NotImplementedException(); }
        public string WorkerPassword { get => textPassword.Text; set => throw new NotImplementedException(); }
        public string SearchValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsEdit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsSuccessful { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler SaveEvent;

        private void UnLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
