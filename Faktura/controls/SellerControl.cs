using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Faktura
{
    public partial class SellerControl : UserControl
    {
        private Seller seller;
        public SellerControl()
        {
            InitializeComponent();
            fillDataGrid();
            seller = new Seller();
            //try
            //{
            //    SQLiteDatabase db = new SQLiteDatabase();
            //    DataTable tablica;
            //    //query += "from sprzedawca;";
            //    string query = "SELECT id \"Id\", nazwa \"Nazwa\", kod \"Kod\", miasto \"Miasto\", adres \"Adres\", nip \"Nip\", rachunek \"Rachunek\" FROM sprzedawca WHERE domyslny = 'true';";
            //    tablica = db.GetDataTable(query);

            //    foreach (DataRow r in tablica.Rows)
            //    {
            //        seller.id = int.Parse(r["Id"].ToString());
            //        textBoxSprzedNaz.Text = r["Nazwa"].ToString();
            //        textBoxSprzedKod.Text = r["Kod"].ToString();
            //        textBoxSprzedMiasto.Text = r["Miasto"].ToString();
            //        textBoxSprzedAdres.Text = r["Adres"].ToString();
            //        textBoxSprzedNip.Text = r["Nip"].ToString();
            //        textBoxSprzedNrRach.Text = r["Rachunek"].ToString();
            //    }
            //}
            //catch (Exception fail)
            //{
            //    String error = "The following error has occurred:\n\n";
            //    error += fail.Message.ToString() + "\n\n";
            //    MessageBox.Show(error);
            //}
        }

        private void btnUaktualnijSprzed_Click(object sender, EventArgs e)
        {
            if (textBoxSprzedNaz.Text == "" || textBoxSprzedKod.Text == "" || textBoxSprzedMiasto.Text == "" ||
                textBoxSprzedAdres.Text == "" || textBoxSprzedNip.Text == "" || textBoxSprzedNrRach.Text == "")
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione");
            }
            else
            {
                SQLiteDatabase db = new SQLiteDatabase();
                string checkQuery = "SELECT COUNT (*) FROM faktura where id_sprzedawca =" + seller.id;
                if (db.ExecuteScalar(checkQuery) == "0")
                {
                    Dictionary<string, string> dane = new Dictionary<string, string>();
                    dane.Add("nazwa", textBoxSprzedNaz.Text);
                    dane.Add("kod", textBoxSprzedKod.Text);
                    dane.Add("miasto", textBoxSprzedMiasto.Text);
                    dane.Add("adres", textBoxSprzedAdres.Text);
                    dane.Add("nip", textBoxSprzedNip.Text);
                    dane.Add("rachunek", textBoxSprzedNrRach.Text);
                    string wher = "sprzedawca.id=1";
                    bool update = db.Update("sprzedawca", dane, wher);
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
                    MessageBox.Show("Odmowa... Aktualny sprzedawca jest wykorzystany w poprzednich fakturach.\n Proszę zmienić bazę");
                }
            }
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

    }
}
