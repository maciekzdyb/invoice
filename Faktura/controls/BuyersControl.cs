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
                        textBoxNazwaNabywcy.TextChanged -= textBoxNazwaNabywcy_TextChanged;
                        textBoxKodNabywcy.Clear();
                        textBoxNazwaNabywcy.TextChanged += textBoxNazwaNabywcy_TextChanged;
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
                    string query = "SELECT id \"Id\", nazwa \"Nazwa\", kod \"Kod\", miasto \"Miasto\", adres \"Adres\", nip \"Nip\" FROM nabywca ORDER BY id DESC";
                    recipe = db.GetDataTable(query);
                    dataGridViewOdbiorcy.Update();
                    dataGridViewOdbiorcy.Refresh();
                    dataGridViewOdbiorcy.DataSource = recipe;
                    dataGridViewOdbiorcy.Columns[0].Visible = false;
                    dataGridViewOdbiorcy.Columns[1].Width = 180;
                    dataGridViewOdbiorcy.Columns[2].Width = 50;
                    dataGridViewOdbiorcy.Columns[3].Width = 50;
                    dataGridViewOdbiorcy.Columns[4].Width = 150;
                    dataGridViewOdbiorcy.Columns[5].Width = 100;
                }
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
            }
        }

        private void fillSuggestedDataGrid(string name)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            string sql = "SELECT COUNT(*) FROM nabywca";
            if (int.Parse(db.ExecuteScalar(sql)) > 20)
            {
                DataTable recipe;
                string query = "SELECT * FROM nabywca WHERE nazwa LIKE \"" + name + "%\"";
                recipe = db.GetDataTable(query);
                dataGridViewOdbiorcy.Update();
                dataGridViewOdbiorcy.Refresh();
                dataGridViewOdbiorcy.DataSource = recipe;
                dataGridViewOdbiorcy.Columns[0].Width = 20;
                dataGridViewOdbiorcy.Columns[1].Width = 250;
                dataGridViewOdbiorcy.Columns[2].Width = 50;
                dataGridViewOdbiorcy.Columns[3].Width = 150;
                dataGridViewOdbiorcy.Columns[4].Width = 200;
                dataGridViewOdbiorcy.Columns[5].Width = 100;
            }
        }

        private void dataGridViewOdbiorcy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int wiersz = dataGridViewOdbiorcy.CurrentCell.RowIndex;
            buyer.id = int.Parse(dataGridViewOdbiorcy[0, wiersz].Value.ToString());
            textBoxNazwaNabywcy.TextChanged -= textBoxNazwaNabywcy_TextChanged;
            textBoxNazwaNabywcy.Text = dataGridViewOdbiorcy[1, wiersz].Value.ToString();
            textBoxNazwaNabywcy.TextChanged += textBoxNazwaNabywcy_TextChanged;
            buyer.name = dataGridViewOdbiorcy[1, wiersz].Value.ToString();
            textBoxKodNabywcy.Text = dataGridViewOdbiorcy[2, wiersz].Value.ToString();
            buyer.postCode = dataGridViewOdbiorcy[2, wiersz].Value.ToString();
            textBoxMisatoNabywcy.Text = dataGridViewOdbiorcy[3, wiersz].Value.ToString();
            buyer.city = dataGridViewOdbiorcy[3, wiersz].Value.ToString();
            textBoxAdresNabywcy.Text = dataGridViewOdbiorcy[4, wiersz].Value.ToString();
            buyer.address = dataGridViewOdbiorcy[4, wiersz].Value.ToString();
            textBoxNipNabywcy.Text = dataGridViewOdbiorcy[5, wiersz].Value.ToString();
            buyer.nip = dataGridViewOdbiorcy[5, wiersz].Value.ToString();
        }

//        public void dataGridViewOdbiorcy_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (e.KeyChar == (char)Keys.F1)
//            {
//                var selectedCell = dataGridViewOdbiorcy.SelectedCells[0];
//        
//           }
//        }

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
                        textBoxNazwaNabywcy.TextChanged -= textBoxNazwaNabywcy_TextChanged;
                        textBoxNazwaNabywcy.Clear();
                        textBoxNazwaNabywcy.TextChanged += textBoxNazwaNabywcy_TextChanged;
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

        private void textBoxNazwaNabywcy_TextChanged(object sender, EventArgs e)
        {
            if(textBoxNazwaNabywcy.Text.Length > 2)
            {
                fillSuggestedDataGrid(textBoxNazwaNabywcy.Text);
            } else
            {
                fillDataGrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        private void clearTextBoxes()
        {
            textBoxNazwaNabywcy.Clear();
            textBoxAdresNabywcy.Clear();
            textBoxKodNabywcy.Clear();
            textBoxMisatoNabywcy.Clear();
            textBoxNipNabywcy.Clear();
        }

    }   
}
