using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            seller = new Seller();
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                DataTable tablica;
                //query += "from sprzedawca;";
                string query = "SELECT id \"Id\", nazwa \"Nazwa\", kod \"Kod\", miasto \"Miasto\", adres \"Adres\", nip \"Nip\", rachunek \"Rachunek\" FROM sprzedawca WHERE id = 9;";
                tablica = db.GetDataTable(query);

                foreach (DataRow r in tablica.Rows)
                {
                    seller.id = int.Parse(r["Id"].ToString());
                    textBoxSprzedNaz.Text = r["Nazwa"].ToString();
                    textBoxSprzedKod.Text = r["Kod"].ToString();
                    textBoxSprzedMiasto.Text = r["Miasto"].ToString();
                    textBoxSprzedAdres.Text = r["Adres"].ToString();
                    textBoxSprzedNip.Text = r["Nip"].ToString();
                    textBoxSprzedNrRach.Text = r["Rachunek"].ToString();
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
            }
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
    }
}
