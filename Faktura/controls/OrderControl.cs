using System;
using System.Data;
using System.Windows.Forms;

namespace Faktura
{
    public partial class OrderControl : UserControl
    {
        public event EventHandler<OrderEventArgs> UpdateText;
        private Order order;

        public OrderControl()
        {
            InitializeComponent();
            fillDataGrid();
            order = new Order();
        }

        private void btnUslDodajDoFV_Click(object sender, EventArgs e)
        {
            if(textBoxUslNazwa.Text != "")
            {
                OnUpdateText(new OrderEventArgs(order));
            }
            
        }

        protected virtual void OnUpdateText(OrderEventArgs e)
        {
            EventHandler<OrderEventArgs> eh = UpdateText;
            if (eh != null)
                eh(this, e);
        }

        private void fillDataGrid()
        {
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string sql = "SELECT COUNT(*) FROM usluga";
                if (db.ExecuteScalar(sql) == "0")
                {
                    string resetQUery = "UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'usluga'";
                    db.ExecuteScalar(resetQUery);
                    dataGridViewUslugi.DataSource = null;
                    dataGridViewUslugi.Update();
                    dataGridViewUslugi.Refresh();
                }
                else
                {
                    DataTable recipe;
                    string query = "SELECT id \"Id\", nazwa \"Nazwa\" FROM usluga";
                    recipe = db.GetDataTable(query);
                    dataGridViewUslugi.Update();
                    dataGridViewUslugi.Refresh();
                    dataGridViewUslugi.DataSource = recipe;
                    dataGridViewUslugi.Columns[0].Width = 20;
                    dataGridViewUslugi.Columns[1].Width = 310;
                }
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
            }
        }

        private void dataGridViewUslugi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int wiersz = dataGridViewUslugi.CurrentCell.RowIndex;
            int idUslugi = int.Parse(dataGridViewUslugi[0, wiersz].Value.ToString());
            textBoxUslNazwa.Text = dataGridViewUslugi[1, wiersz].Value.ToString();
            order.id = idUslugi;
            order.name = dataGridViewUslugi[1, wiersz].Value.ToString();
        }

        private void btnUslugaDodaj_Click(object sender, EventArgs e)
        {
            if (textBoxUslNazwa.Text != "")
            {
                SQLiteDatabase db = new SQLiteDatabase();
                Order order = db.getOrderByName(textBoxUslNazwa.Text);
                if(order.name == textBoxUslNazwa.Text)
                {
                    MessageBox.Show("Podana nazwa usługi już jest w bazie");
                } else
                {
                    db = new SQLiteDatabase();
                    string answer = db.insertOrder(textBoxUslNazwa.Text);
                    if (answer == "ok")
                    {
                        fillDataGrid();
                    }
                    else
                    {
                        MessageBox.Show(answer);
                    }
                }
            } else
            {
                MessageBox.Show("Wypełnij pole nazwa");
            }
        }

        private void btnUslDel_Click(object sender, EventArgs e)
        {
            if(order.id >0)
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string answer = db.deleteOrderById(order.id.ToString());
                if (answer == "ok")
                {
                    MessageBox.Show("Usługa usunięta z bazy");
                    textBoxUslNazwa.Clear();
                    fillDataGrid();
                }
                else
                {
                    MessageBox.Show(answer);
                }
            }
            else
            {
                MessageBox.Show("Wybierz uługę");
            }
            
        }
    }
}
