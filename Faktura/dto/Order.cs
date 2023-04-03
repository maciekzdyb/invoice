
//using System.Globalization;

namespace Faktura
{
    public class Order
    {
        enum months
        {
            styczeń = 1,
            luty = 2,
            marzec = 3,
            kwiecień = 4,
            maj = 5,
            czerwiec = 6,
            lipiec = 7,
            sierpień = 8,
            wrzesień = 9,
            październik = 10,
            listopad = 11,
            grudzień = 12
        }

        public int id { get; set; }
        public string name { get; set; }


        private string parseDate(string date)
        {
            char comma;
            if (date.Contains("."))
                {
                comma = '.';
                }
            else
            {
                comma = ',';
            }
            string[] dateTab = date.Split(comma);
            //string monthName = new System.DateTime(int.Parse(dateTab[0]), 
            //                                       int.Parse(dateTab[1]), 
            //                                       int.Parse(dateTab[2])).ToString("MMMM", CultureInfo.CreateSpecificCulture("pl-PL"));
            var monthName = (months)int.Parse(dateTab[1]);
            return ("miesiąc " + monthName + " " + dateTab[2]);
        }

        public string parseName(string date)
        {
            string shortcut = ":mc";
            if (name.Contains(":mc"))
            {
                int pos = name.IndexOf(":mc");
                char c = name[pos + 2];
                string offsetS ="";
                if (c.Equals('+') || c.Equals('-')) 
                {
                    shortcut += c;
                    char firstD = name[pos + 3];
                    if (char.IsDigit(firstD))
                    {
                        offsetS += firstD;
                        shortcut += firstD;
                    }
                    
                    char secondD = name[pos + 4];
                    if (char.IsDigit(secondD))
                    {
                        offsetS += secondD;
                        shortcut += secondD;
                    }
                    int offset = int.Parse(offsetS);
                    //string monthName = parseDate(date, c, offset);
                }
                string monthName = parseDate(date);
                return name.Replace(shortcut, monthName);
            }
            return name;
        }
    }
}
