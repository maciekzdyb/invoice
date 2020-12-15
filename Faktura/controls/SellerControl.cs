using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faktura
{
    public partial class SellerControl : UserControl
    {
        public SellerControl()
        {
            InitializeComponent();
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                DataTable tablica;
                //query += "from sprzedawca;";
                string query = "SELECT nazwa \"Nazwa\", kod \"Kod\", miasto \"Miasto\", adres \"Adres\", nip \"Nip\", rachunek \"Rachunek\" FROM sprzedawca WHERE id = 9;";
                tablica = db.GetDataTable(query);

                foreach (DataRow r in tablica.Rows)
                {
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
    }
}
