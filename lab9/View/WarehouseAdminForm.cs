using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_course.View
{
    public partial class WarehouseAdminForm : Form,IWarehouseAdminView
    {
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        public WarehouseAdminForm()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(addProductPage);
            tabControl1.TabPages.Remove(PlaceComponent);
        }
        private void AssociateAndRaiseViewEvents()
        {
            //Search
            buttonSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            textSearch.KeyDown += (s, e) =>
            {
                if(e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            searchPlaceBtn.Click += delegate { SearchPlaceEvent?.Invoke(this, EventArgs.Empty); };
            //Add new
            buttonAdd.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(productsPage);
                tabControl1.TabPages.Remove(PlacePage);
                tabControl1.TabPages.Add(addProductPage);
            };
            addPlaceBtn.Click += delegate
            {
                AddNewPlaceEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(productsPage);
                tabControl1.TabPages.Remove(PlacePage);
                tabControl1.TabPages.Add(PlaceComponent);
                placeIdText.Visible = true;
                label7.Visible = true;
            };
            //Edit
            updatePlaceBtn.Click += delegate
            {
                EditPlaceEvent?.Invoke(this, EventArgs.Empty);
                if(isSuccessful)
                {
                    tabControl1.TabPages.Remove(productsPage);
                    tabControl1.TabPages.Remove(PlacePage);
                    tabControl1.TabPages.Add(PlaceComponent);
                    placeIdText.Visible = false;
                    label7.Visible = false;
                }
                else
                    MessageBox.Show(Message);

            };
            //Save changes
            buttonSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if(isSuccessful)
                {
                    tabControl1.TabPages.Remove(addProductPage);
                    tabControl1.TabPages.Add(productsPage);
                    tabControl1.TabPages.Add(PlacePage);
                }
                MessageBox.Show(Message);
            };
            savePlaceBtn.Click += delegate
            {
                SavePlaceEvent?.Invoke(this, EventArgs.Empty);
                if(isSuccessful)
                {
                    tabControl1.TabPages.Remove(PlaceComponent);
                    tabControl1.TabPages.Add(productsPage);
                    tabControl1.TabPages.Add(PlacePage);
                }
                MessageBox.Show(Message);
            };

            //Cancel
            buttonCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(addProductPage);
                tabControl1.TabPages.Add(productsPage);
                tabControl1.TabPages.Add(PlacePage);
            };
            cancelPlaceBtn.Click += delegate
            {
                CancelPlaceEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(PlaceComponent);
                tabControl1.TabPages.Add(productsPage);
                tabControl1.TabPages.Add(PlacePage);
            };
            //Delete
            buttonDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected worker?", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };

            deletePlaceBtn.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected palce?", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    DeletePlaceEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }

        public string PlaceId { get => textPlaceId.Text; set => textPlaceId.Text = value; }
        public int ProductId
        {
            get => int.TryParse(textProductId.Text, out _) ?
                                        Convert.ToInt32(textProductId.Text) : -1;
            set => textProductId.Text = Convert.ToString(value);
        }
        string IWarehouseAdminView.ProductName { get => textProductName.Text;  set => textProductName.Text = value; }
        public string DateCome { get => textDateCome.Text; set => textDateCome.Text = value; }
        public string DateProduction { get => textDateProduction.Text; set => textDateProduction.Text = value; }
        public int InventoryNumber
        {
            get => int.TryParse(textInventoryNumber.Text, out _) ?
                                            Convert.ToInt32(textInventoryNumber.Text) : -1;
            set => textInventoryNumber.Text = Convert.ToString(value);
        }

        public string SearchValue { get => textSearch.Text;  set => textSearch.Text = value;  }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }
        public string Message { get => message;  set => message = value;  }
        public string PlaceId1 { get => placeIdText.Text; set => placeIdText.Text = value; }
        public string PlaceSize { get => sizePlaceText.Text; set => sizePlaceText.Text = value; }
        public string PlaceLayer { get => laerPlaceText.Text; set => laerPlaceText.Text = value; }
        public string PlaceStay { get => StayPlaceText.Text; set => StayPlaceText.Text = value; }
        public string SearchPlaceValue { get => searchPlaceTextBox.Text; set => searchPlaceTextBox.Text =value; }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler SearchPlaceEvent;
        public event EventHandler AddNewPlaceEvent;
        public event EventHandler EditPlaceEvent;
        public event EventHandler DeletePlaceEvent;
        public event EventHandler SavePlaceEvent;
        public event EventHandler CancelPlaceEvent;

        public void SetPlaceListBindingSource(BindingSource WorkerList)
        {
            dataGridView2.DataSource = WorkerList;
        }

        public void SetProductListBindingSource(BindingSource WorkerList)
        {
            dataGridView1.DataSource = WorkerList;
        }

        private void WarehouseAdminForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private static WarehouseAdminForm instance;
        public static WarehouseAdminForm GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new WarehouseAdminForm
                {
                    MdiParent = parentContainer
                };
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
        public static WarehouseAdminForm GetInstace()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new WarehouseAdminForm();
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
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Columns.Count > 7)
            {
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
            }
        }

        private void PlaceComponent_Click(object sender, EventArgs e)
        {

        }
    }
}
