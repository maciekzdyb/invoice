using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;

namespace Faktura
{
    class Printing
    {
        private void rysujBox(string text, int x, int y, int w, int h, Font font, StringFormat sf, string kolor, PrintPageEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(x, y, w, h);
            e.Graphics.DrawString(text, font, solidBrush, rect, sf);
            if (kolor == "w")
                e.Graphics.DrawRectangle(Pens.White, rect);
            else
                e.Graphics.DrawRectangle(Pens.Black, rect);

        }
        public void printContent(PrintPageEventArgs e, UserControl u, Invoice invoice, Seller seller, Buyer buyer, Order order)
        {

            Font arial12b = new Font("Arial", 12, FontStyle.Bold);
            Font arial17 = new Font("Arial", 17, FontStyle.Bold);
            Font Times9 = new Font("Times New Roman", 9);
            Font Arial9 = new Font("Arial", 8);
            Font Arial6 = new Font("Arial", 6);
            Font Arial8b = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point);

            SolidBrush solidBrush = new SolidBrush(Color.Black);                    //kolor pędzla
            Pen myPen = new Pen(Color.DarkGray);
            Graphics formGraphics = u.CreateGraphics();

            SizeF stringSize = new SizeF();

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            StringFormat stringFormatLeft = new StringFormat();
            stringFormatLeft.Alignment = StringAlignment.Near;
            stringFormatLeft.LineAlignment = StringAlignment.Near;

            rysujBox("Faktura VAT", 330, 50, 180, 30, arial12b, stringFormat, "w", e);
            rysujBox("Nr " + invoice.no, 330, 82, 180, 40, arial17, stringFormat, "w", e);
            rysujBox("Oryginał/Kopia", 340, 110, 160, 20, Arial9, stringFormat, "w", e);

            rysujBox("Data wystawienia: " + invoice.issue_date, 570, 50, 180, 20, Arial9, stringFormat, "w", e);
            rysujBox("Data sprzedaży: " + invoice.sell_date, 575, 70, 180, 20, Arial9, stringFormat, "w", e);
  
            //stringSize = e.Graphics.MeasureString(nr_faktury, arial17);
            //e.Graphics.DrawString(nr_faktury, arial17, solidBrush, new PointF(345, 80));
            string sprzedawca = "Sprzedawca";
            e.Graphics.DrawString(sprzedawca, arial12b, solidBrush, new PointF(60, 200));
            e.Graphics.DrawLine(myPen, 60, 200 + stringSize.Height, 350, 200 + stringSize.Height);
            rysujBox(seller.name, 60, 240, 310, 15, Arial9, stringFormatLeft, "w", e);
            rysujBox(seller.address, 60, 255, 310, 15, Arial9, stringFormatLeft, "w", e);
            rysujBox(seller.postCode, 60, 270, 40, 15, Arial9, stringFormat, "w", e);
            rysujBox(seller.city, 100, 270, 60, 15, Arial9, stringFormat, "w", e);
            rysujBox("NIP: " + seller.nip, 60, 285, 110, 15, Arial9, stringFormatLeft, "w", e);
            rysujBox("Nr rachunku: " + seller.rachunek, 60, 300, 300, 15, Arial8b, stringFormatLeft, "w", e);
            string nabywca = "Nabywca";
            e.Graphics.DrawString(nabywca, arial12b, solidBrush, new PointF(440, 200));
            e.Graphics.DrawLine(myPen, 440, 200 + stringSize.Height, 440 + 300, 200 + stringSize.Height);
            rysujBox(buyer.name, 440, 240, 310, 15, Arial9, stringFormatLeft, "w", e);
            rysujBox(buyer.address, 440, 255, 310, 15, Arial9, stringFormatLeft, "w", e);
            rysujBox(buyer.postCode, 440, 270, 40, 15, Arial9, stringFormat, "w", e);
            rysujBox(buyer.city, 480, 270, 60, 15, Arial9, stringFormat, "w", e);
            rysujBox("NIP: " + buyer.nip, 440, 285, 110, 15, Arial9, stringFormatLeft, "w", e);

            rysujBox("Lp.", 60, 350, 20, 30, Arial9, stringFormat, "b", e);
            rysujBox("Nazwa towaru lub usługi", 80, 350, 330, 30, Arial9, stringFormat, "b", e);
            rysujBox("ilość", 410, 350, 30, 30, Arial9, stringFormat, "b", e);
            rysujBox("jm", 440, 350, 20, 30, Arial9, stringFormat, "b", e);
            rysujBox("Cena netto", 460, 350, 60, 30, Arial9, stringFormat, "b", e);
            rysujBox("Wartość netto", 520, 350, 60, 30, Arial9, stringFormat, "b", e);
            rysujBox("Stawka VAT", 580, 350, 50, 30, Arial9, stringFormat, "b", e);
            rysujBox("Kwota   VAT", 630, 350, 60, 30, Arial9, stringFormat, "b", e);
            rysujBox("Wartość brutto", 690, 350, 60, 30, Arial9, stringFormat, "b", e);

            int y = 0;
            string text = order.parseName(invoice.sell_date);
            if (text.Length > 50)
            {
                if (text.Length > 90)
                    y = 40;
                else y = 20;
            }

            rysujBox("1", 60, 380, 20, 20 + y, Arial9, stringFormat, "b", e);
            rysujBox(text, 80, 380, 330, 20 + y, Arial9, stringFormat, "b", e);
            rysujBox("1", 410, 380, 30, 20 + y, Arial9, stringFormat, "b", e);
            rysujBox("szt", 440, 380, 20, 20 + y, Arial9, stringFormat, "b", e);
            rysujBox(invoice.net, 460, 380, 60, 20 + y, Arial9, stringFormat, "b", e);
            rysujBox(invoice.net, 520, 380, 60, 20 + y, Arial9, stringFormat, "b", e);
            rysujBox("23", 580, 380, 50, 20 + y, Arial9, stringFormat, "b", e);

            //decimal netto = Convert.ToDecimal(invoice.net, new CultureInfo("en-US"));
            //decimal vat = netto * 0.23m;
            //vat = Decimal.Round(vat, 2);
            rysujBox(invoice.vat, 630, 380, 60, 20 + y, Arial9, stringFormat, "b", e);
            //decimal cenabrutto = netto + vat;
            //cenabrutto = Decimal.Round(cenabrutto, 2);

            rysujBox(invoice.gross, 690, 380, 60, 20 + y, Arial9, stringFormat, "b", e);

            rysujBox("RAZEM", 460, 405 + y, 60, 20, Arial9, stringFormat, "b", e);
            rysujBox(invoice.net, 520, 405 + y, 60, 20, Arial9, stringFormat, "b", e);
            rysujBox("x", 580, 405 + y, 50, 20, Arial9, stringFormat, "b", e);
            rysujBox(invoice.vat, 630, 405 + y, 60, 20, Arial9, stringFormat, "b", e);
            rysujBox(invoice.gross, 690, 405 + y, 60, 20, Arial9, stringFormat, "b", e);

            rysujBox("W tym", 460, 425 + y, 60, 20, Arial9, stringFormat, "b", e);
            rysujBox(invoice.net, 520, 425 + y, 60, 20, Arial9, stringFormat, "b", e);
            rysujBox("23%", 580, 425 + y, 50, 20, Arial9, stringFormat, "b", e);
            rysujBox(invoice.vat, 630, 425 + y, 60, 20, Arial9, stringFormat, "b", e);
            rysujBox(invoice.gross, 690, 425 + y, 60, 20, Arial9, stringFormat, "b", e);

            string razemdozaplaty = "Razem do zapłaty: " + invoice.gross + " zł";
            Rectangle rect_razemdozaplaty = new Rectangle(60, 500 + y, 300, 20);
            e.Graphics.DrawString(razemdozaplaty, Arial8b, solidBrush, rect_razemdozaplaty, stringFormatLeft);
            e.Graphics.DrawRectangle(Pens.White, rect_razemdozaplaty);
            //-------------------------------------------------------------------------------------------------------------
            //TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

            string slownie = "Słownie: ";
            Rectangle rect_slownie = new Rectangle(60, 520 + y, 690, 20);
            CultureInfo cultureInfo;
            if (invoice.gross.Contains("."))
            {
                cultureInfo = new CultureInfo("en-US");
            } else
            {
                cultureInfo = new CultureInfo("pl-PL");
            }

            decimal kwota = Convert.ToDecimal(invoice.gross, cultureInfo);
            int zlote = (int)kwota;
            int grosze = (int)(100 * kwota) % 100;
            slownie += Formatowanie.LiczbaSlownie(zlote) + " " + Formatowanie.WalutaSlownie(zlote, "PLN") + " " + Formatowanie.LiczbaSlownie(grosze) + " " + Formatowanie.WalutaSlownie(grosze, "gr");
            //TextRenderer.DrawText(e.Graphics, slownie, Arial8, rect_slownie, Color.Black, flags);
            e.Graphics.DrawString(slownie, Arial9, solidBrush, rect_slownie, stringFormatLeft);
            //e.Graphics.DrawRectangle(Pens.Black, rect_slownie);

            rysujBox("Forma płatności: " + invoice.payment_method, 60, 550 + y, 160, 15, Arial9, stringFormatLeft, "w", e);

            string[] sellTab = invoice.sell_date.Split('.');
            DateTime sellDate = new DateTime(int.Parse(sellTab[2]), int.Parse(sellTab[1]), int.Parse(sellTab[0]));
            String days = "";
            String deadlineStr = "";
            if (invoice.payment_deadline.Contains("."))
            {
                string[] deadlineTab = invoice.payment_deadline.Split('.');
                DateTime deadlineDate = new DateTime(int.Parse(deadlineTab[2]), int.Parse(deadlineTab[1]), int.Parse(deadlineTab[0]));
                TimeSpan result = deadlineDate - sellDate;
                days = result.TotalDays.ToString();
                deadlineStr = invoice.payment_deadline;
            } else
            {
                days = invoice.payment_deadline;
                DateTime deadlineDate = sellDate.AddDays(Double.Parse(days));
                deadlineStr = deadlineDate.ToString("dd.MM.yyyy");
            }
            
            
            string paymentStr = "";
            if (days.Equals("1"))
            {
                paymentStr = " (1 dzień)";
            }
            else
            {
                paymentStr = " (" + days + " dni)";
            }
            rysujBox("Termin płatności: " + deadlineStr + paymentStr, 60, 565 + y, 240, 15, Arial8b, stringFormatLeft, "w", e);

            if (sellDate > new DateTime(2019, 11, 01) && kwota >15000)
            {
                rysujBox("Mechanizm podzielonej płatności", 60, 600 + y, 300, 15, Arial9, stringFormatLeft, "w", e);
            }
            

            e.Graphics.DrawString(seller.signature, Arial9, solidBrush, new PointF(130, 700 + y));

            rysujBox("imię, nazwisko i podpis osoby upoważnionej do wystawienia dokumentu", 90, 730 + y, 220, 30, Arial9, stringFormat, "w", e);
            rysujBox("imię, nazwisko i podpis osoby upoważnionej do odbioru dokumentu", 490, 730 + y, 200, 30, Arial9, stringFormat, "w", e);

            myPen.Dispose();
            formGraphics.Dispose();
        }
    }
}
