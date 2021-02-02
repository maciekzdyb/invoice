using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Faktura
{
    public partial class BuyersControl : UserControl
    {
        public event EventHandler<BuyerEventArgs> UpdateText;
        private Buyer buyer;

        public BuyersControl()
        {
            InitializeComponent();
            fillDataGrid();
            buyer = new Buyer();

        }

        private void btnDodajOdbiorce_Click(object sender, EventArgs e)
        {
            if (textBoxNazwaNabywcy.Text != "" & textBoxAdresNabywcy.Text != "" & textBoxMisatoNabywcy.Text != "")
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string sql = String.Format("SELECT COUNT(*) FROM {0} WHERE nazwa = '{1}'", "nabywca", textBoxNazwaNabywcy.Text);
                if (db.ExecuteScalar(sql) == "0")
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("nazwa", textBoxNazwaNabywcy.Text);
                    data.Add("kod", textBoxKodNabywcy.Text);
                    data.Add("miasto", textBoxMisatoNabywcy.Text);
                    data.Add("adres", textBoxAdresNabywcy.Text);
                    if (textBoxNipNabywcy.Text != "")
                    {
                        data.Add("nip", textBoxNipNabywcy.Text);
                    }
                    string insert = db.Insert("nabywca", data);
                    if (insert == "ok")
                    {
                        MessageBox.Show("Pozycja dodana");
                        textBoxNazwaNabywcy.Clear();
                        textBoxKodNabywcy.Clear();
                        textBoxMisatoNabywcy.Clear();
                        textBoxAdresNabywcy.Clear();
                        textBoxNipNabywcy.Clear();
                        fillDataGrid();
                    }
                    else
                    {
                        MessageBox.Show(insert);
                    }
                }
                else
                {
                    MessageBox.Show("Podana pozycja jest już w bazie");
                }
            }
            else
            {
                MessageBox.Show("Uzupełnij pola");
            }
        }

        private void btnDodajDoFaktury_Click(object sender, EventArgs e)
        {
            Buyer buyer = new Buyer();
            buyer.name = textBoxNazwaNabywcy.Text;
            buyer.nip = textBoxNipNabywcy.Text;
            buyer.postCode = textBoxKodNabywcy.Text;
            buyer.address = textBoxAdresNabywcy.Text;
            buyer.city = textBoxMisatoNabywcy.Text;
            OnUpdateText(new BuyerEventArgs(buyer));
        }

        private void fillDataGrid()
        {
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string sql = "SELECT COUNT(*) FROM nabywca";
                if (db.ExecuteScalar(sql) == "0")
                {
                    string resetQUery = "UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'nabywca'";
                    db.ExecuteScalar(resetQUery);
                    dataGridViewOdbiorcy.DataSource = null;
                    dataGridViewOdbiorcy.Update();
                    dataGridViewOdbiorcy.Refresh();
                }
                else
                {
                    DataTable recipe;
                    string query = "SELECT id \"Id\", nazwa \"Nazwa\", kod \"Kod\", miasto \"Miasto\", adres \"Adres\", nip \"Nip\" FROM nabywca";
                    recipe = db.GetDataTable(query);
                    dataGridViewOdbiorcy.Update();
                    dataGridViewOdbiorcy.Refresh();
                    dataGridViewOdbiorcy.DataSource = recipe;
                    dataGridViewOdbiorcy.Columns[0].Width = 20;
                    dataGridViewOdbiorcy.Columns[1].Width = 160;
                    dataGridViewOdbiorcy.Columns[2].Width = 50;
                    dataGridViewOdbiorcy.Columns[3].Width = 50;
                    dataGridViewOdbiorcy.Columns[4].Width = 130;
                    dataGridViewOdbiorcy.Columns[5].Width = 100;
                }
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
            }
        }

        private void dataGridViewOdbiorcy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int wiersz = dataGridViewOdbiorcy.CurrentCell.RowIndex;
            buyer.id = int.Parse(dataGridViewOdbiorcy[0, wiersz].Value.ToString());
            textBoxNazwaNabywcy.Text = dataGridViewOdbiorcy[1, wiersz].Value.ToString();
            buyer.name = dataGridViewOdbiorcy[1, wiersz].Value.ToString();
            textBoxKodNabywcy.Text = dataGridViewOdbiorcy[2, wiersz].Value.ToString();
            textBoxMisatoNabywcy.Text = dataGridViewOdbiorcy[3, wiersz].Value.ToString();
            textBoxAdresNabywcy.Text = dataGridViewOdbiorcy[4, wiersz].Value.ToString();
            textBoxNipNabywcy.Text = dataGridViewOdbiorcy[5, wiersz].Value.ToString();
        }

        protected virtual void OnUpdateText(BuyerEventArgs e)
        {
            EventHandler<BuyerEventArgs> eh = UpdateText;
            if (eh != null)
                eh(this, e);
        }

        private void btnUsunOdbiorce_Click(object sender, EventArgs e)
        {
            if (buyer.id > 0)
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string checkQuery = "SELECT COUNT(*) FROM faktura WHERE id_nabywca = " + buyer.id;
                if (db.ExecuteScalar(checkQuery) == "0")
                {
                    string wher = "nabywca.id = " + buyer.id;
                    string delete = db.Delete("nabywca", wher);
                    if (delete.Equals("ok"))
                    {
                        MessageBox.Show("Pozycja usunięta");
                        textBoxNazwaNabywcy.Clear();
                        textBoxKodNabywcy.Clear();
                        textBoxMisatoNabywcy.Clear();
                        textBoxAdresNabywcy.Clear();
                        textBoxNipNabywcy.Clear();
                        fillDataGrid();
                        buyer = new Buyer();
                    }
                } else
                {
                    MessageBox.Show("Pozycja używana w fakturze, najpierw usuń fakturę");
                }
            } else
            {
                MessageBox.Show("Najpierw wybierz odbiorcę");
            }
        }

        private void btnEdytujOdbiorce_Click(object sender, EventArgs e)
        {
            if (buyer.id > 0)
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string checkQuery = "SELECT COUNT(*) FROM faktura WHERE id_nabywca = " + buyer.id;
                if (db.ExecuteScalar(checkQuery) == "0")
                {
                    Dictionary<string, string> dane = new Dictionary<string, string>();
                    dane.Add("nazwa", textBoxNazwaNabywcy.Text);
                    dane.Add("kod", textBoxKodNabywcy.Text);
                    dane.Add("miasto", textBoxMisatoNabywcy.Text);
                    dane.Add("adres", textBoxAdresNabywcy.Text);
                    dane.Add("nip", textBoxNipNabywcy.Text);
                    string wher = "nabywca.id=" + buyer.id;
                    bool update = db.Update("nabywca", dane, wher);
                    if (update)
                    {
                        MessageBox.Show("Uaktualniono");
                    }
                    else
                    {
                        MessageBox.Show("błąd..");
                    }
                }
                else
                {
                    MessageBox.Show("Pozycja używana w fakturze, najpierw usuń fakturę");
                }
            } else
            {
                MessageBox.Show("Najpierw wybierz odbiorcę");
            }

        }
    }   
}
