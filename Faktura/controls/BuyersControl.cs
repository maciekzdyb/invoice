using System;
using System.Data;
using System.Windows.Forms;

namespace Faktura
{
    public partial class BuyersControl : UserControl
    {
        public event EventHandler<BuyerEventArgs> UpdateText;

        public BuyersControl()
        {
            InitializeComponent();
            fillDataGrid();

        }

        private void btnDodajOdbiorce_Click(object sender, EventArgs e)
        {
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
            //idOdbiorcy = int.Parse(dataGridViewOdbiorcy[0, wiersz].Value.ToString());
            textBoxNazwaNabywcy.Text = dataGridViewOdbiorcy[1, wiersz].Value.ToString();
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
    }
}
