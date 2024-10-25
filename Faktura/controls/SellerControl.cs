using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Faktura
{
    public partial class SellerControl : UserControl
    {
        public event EventHandler<SellerEventArgs> UpdateText;
        public SellerControl()
        {
            InitializeComponent();
            fillDataGrid();
        }

        private void btnUaktualnijSprzed_Click(object sender, EventArgs e)
        {
            if (!texboxesAreFilled())
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione");
            }
            else
            {
                SQLiteDatabase db = new SQLiteDatabase();
                Seller seller = mapTextBoxes2Seller();
                if (!existInDBInvoices(seller, db))
                {
                    Dictionary<string, string> dane = prepareData(seller);
                    string wher = String.Format(" sprzedawca.id={} ",seller.id);
                    bool update = db.Update("sprzedawca", dane, wher);
                    if (update)
                    {
                        MessageBox.Show("Uaktualniono");
                        fillDataGrid();
                        if(seller.domyslny == 1)
                        {
                            OnUpdateText(new SellerEventArgs(seller));
                        }
                    }
                    else
                    {
                        MessageBox.Show("błąd..");
                    }
                }
                else
                {
                    MessageBox.Show("Odmowa... Aktualny sprzedawca jest wykorzystany w poprzednich fakturach.\n Proszę zmienić bazę");
                }
            }
        }

        private bool existInDBInvoices(Seller seller, SQLiteDatabase db)
        {
            string checkQuery = "SELECT COUNT (*) FROM faktura where id_sprzedawca =" + seller.id;
            if (db.ExecuteScalar(checkQuery) == "0")
            {
                return false;
            }
            return true;
        }

        private void btnDodajSprzedawce_Click(object sender, EventArgs e)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            Seller tmpSeller = mapTextBoxes2Seller();

            if (tmpSeller.name != "" & tmpSeller.address != "" & tmpSeller.city != "")
            {
                if (sellerExistInDB(tmpSeller,db))
                {
                    MessageBox.Show("Podana pozycja jest już w bazie");
                }
                else
                {
                    tmpSeller.domyslny = 0;
                    string insert = db.Insert("sprzedawca", prepareData(tmpSeller));
                    if (insert == "ok")
                    {
                        MessageBox.Show("Pozycja dodana");
                        clearTextBoxes();
                        fillDataGrid();
                    }
                    else
                    {
                        MessageBox.Show(insert);
                    }
                }
            }
            else
            {
                MessageBox.Show("Uzupełnij pola");
            }
        }

        private bool texboxesAreFilled()
        {
            if (textBoxSprzedNaz.Text == "" || textBoxSprzedAdres.Text == "" || textBoxSprzedMiasto.Text == "" ||
                textBoxSprzedKod.Text == "" || textBoxSprzedNip.Text == "" || textBoxSprzedNrRach.Text == "")
            {
                return false;
            }
            return true;
        }

        private Dictionary<string, string> prepareData(Seller seller)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("nazwa", seller.name);
            data.Add("kod", seller.postCode);
            data.Add("miasto", seller.city);
            data.Add("adres", seller.address);
            data.Add("nip", seller.nip);
            data.Add("rachunek", seller.rachunek);
            data.Add("domyslny", seller.domyslny.ToString());
            return data;
        }

        private bool sellerExistInDB(Seller seller, SQLiteDatabase db)
        {
            
            string sql = String.Format("SELECT COUNT(*) FROM {0} WHERE nazwa = '{1}' and kod = '{2}' and miasto = '{3}' and adres = '{4}' and nip = '{5}' and rachunek = '{6}' ",
                            "sprzedawca", seller.name, seller.postCode, seller.city, seller.address, seller.nip, seller.rachunek);
            if(db.ExecuteScalar(sql) == "0")
            {
                return false;
            }
            return true;
        }



        private Seller mapTextBoxes2Seller()
        {
            Seller seller = new Seller();
            if (textBoxId.Text.Length > 0)
            {
                seller.id = int.Parse(textBoxId.Text);
            }
            seller.name = textBoxSprzedNaz.Text;
            seller.postCode = textBoxSprzedKod.Text;
            seller.city = textBoxSprzedMiasto.Text;
            seller.address = textBoxSprzedAdres.Text;
            seller.nip = textBoxSprzedNip.Text;
            seller.rachunek = textBoxSprzedNrRach.Text;
            if (textBoxDomyslny.Text.Length > 0)
            {
                seller.domyslny = int.Parse(textBoxDomyslny.Text);
            }
            
            return seller;
        }

        private void btnUsunSprzedawce_Click(object sender, EventArgs e)
        {
            Seller seller = mapTextBoxes2Seller();
            if (seller.id == 0)
            {
                clearTextBoxes();
                return;
            }
            if(seller.domyslny == 1)
            {
                MessageBox.Show("Domyślny sprzedawca, proszę najpierw zmienić domyślnego sprzedawcę");
                return;
            }
            SQLiteDatabase db = new SQLiteDatabase();
            if(existInDBInvoices(seller,db))
            {
                MessageBox.Show("Odmowa... Aktualny sprzedawca jest wykorzystany w poprzednich fakturach.\n Proszę zmienić bazę");
                return;
            }

            string where = String.Format(" id = {0}", seller.id);
            string answer = db.Delete("sprzedawca", where);
            if (answer == "ok")
            {
                MessageBox.Show("Pozycja usunieta");
            }
            else
            {
                MessageBox.Show(answer);
            }
            clearTextBoxes();
            fillDataGrid();

        }

        private void fillDataGrid()
        {
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string sql = "SELECT COUNT(*) FROM sprzedawca";
                if (db.ExecuteScalar(sql) == "0")
                {
                    string resetQUery = "UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'nabywca'";
                    db.ExecuteScalar(resetQUery);
                    dataGridViewSprzedawca.DataSource = null;
                    dataGridViewSprzedawca.Update();
                    dataGridViewSprzedawca.Refresh();
                }
                else
                {
                    DataTable recipe;
                    string query = "SELECT * FROM sprzedawca ORDER BY id DESC";
                    recipe = db.GetDataTable(query);
                    dataGridViewSprzedawca.Update();
                    dataGridViewSprzedawca.Refresh();
                    dataGridViewSprzedawca.DataSource = recipe;
                    dataGridViewSprzedawca.Columns[0].Visible = false;
                    dataGridViewSprzedawca.Columns[1].Width = 180;
                    dataGridViewSprzedawca.Columns[2].Width = 50;
                    dataGridViewSprzedawca.Columns[3].Width = 50;
                    dataGridViewSprzedawca.Columns[4].Width = 150;
                    dataGridViewSprzedawca.Columns[5].Width = 100;
                }
            }
            catch (Exception fail)
            {
                MessageBox.Show(fail.Message);
            }
        }

        private void dataGridViewSprzedawca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clearTextBoxes();
            int wiersz = dataGridViewSprzedawca.CurrentCell.RowIndex;
            textBoxId.Text = dataGridViewSprzedawca[0, wiersz].Value.ToString();
            textBoxSprzedNaz.Text = dataGridViewSprzedawca[1, wiersz].Value.ToString();
            textBoxSprzedKod.Text = dataGridViewSprzedawca[2, wiersz].Value.ToString();
            textBoxSprzedMiasto.Text = dataGridViewSprzedawca[3, wiersz].Value.ToString();
            textBoxSprzedAdres.Text = dataGridViewSprzedawca[4, wiersz].Value.ToString();
            textBoxSprzedNip.Text = dataGridViewSprzedawca[5, wiersz].Value.ToString();
            textBoxSprzedNrRach.Text = dataGridViewSprzedawca[6, wiersz].Value.ToString();
            textBoxDomyslny.Text = dataGridViewSprzedawca[7, wiersz].Value.ToString();
        }

        private void btnDomyslny_Click(object sender, EventArgs e)
        {
            Seller seller = mapTextBoxes2Seller();
            if(seller.id >0)
            {
                SQLiteDatabase db = new SQLiteDatabase();
                Seller defaultSeller = db.GetDefaultSeller();
                if (db.ResetDafaultSeller(defaultSeller))
                {
                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add("domyslny", "1");
                    string where = String.Format("id = {0}", seller.id);
                    db.Update("sprzedawca", data, where);
                }

                OnUpdateText(new SellerEventArgs(seller));
                fillDataGrid();
                clearTextBoxes();
            }
            
        }

        private void clearTextBoxes()
        {
            textBoxId.Clear();
            textBoxSprzedNaz.Clear();
            textBoxSprzedKod.Clear();
            textBoxSprzedMiasto.Clear();
            textBoxSprzedAdres.Clear();
            textBoxSprzedNip.Clear();
            textBoxSprzedNrRach.Clear();
            textBoxDomyslny.Clear();
        }

        protected virtual void OnUpdateText(SellerEventArgs e)
        {
            EventHandler<SellerEventArgs> eh = UpdateText;
            if (eh != null)
                eh(this, e);
        }

        private void btnClearSeller_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }
    }
}
