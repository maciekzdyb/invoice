using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Faktura
{
    class SQLiteDatabase
    {
        String dbConnection;
        public SQLiteDatabase()
        {
            dbConnection = "Data Source=c:\\sqlite\\db\\itmz.db";
            //dbConnection = "Data Source=c:\\sqlite\\db\\faktura.db";
            //dbConnection = "Data Source=c:\\sqlite\\db\\faktura_test.db";
            //dbConnection = "Data Source=faktura.db";
            //dbConnection = "Data Source=c:\\sqlite\\kancelaria\\faktura.db";
            //dbConnection = "Data Source = F:\\faktura\\faktura.db";
        }

        public SQLiteDatabase(String inputFile)
        {
            dbConnection = String.Format("Data Source={0}", inputFile);
        }
        public SQLiteDatabase(Dictionary<String, String> connectionOpts)
        {
            String str = "";
            foreach (KeyValuePair<String, String> row in connectionOpts)
            {
                str += String.Format("{0}={1}; ", row.Key, row.Value);
            }
            str = str.Trim().Substring(0, str.Length - 1);
            dbConnection = str;
        }
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLiteConnection cnn = new SQLiteConnection(dbConnection);
                cnn.Open();
                SQLiteCommand mycommand = new SQLiteCommand(cnn);
                mycommand.CommandText = sql;
                SQLiteDataReader reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dt;
        }

        public int ExecuteNonQuery(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            int rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated;
        }

        public string ExecuteScalar(string sql)
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            object value = mycommand.ExecuteScalar();
            cnn.Close();
            if (value != null)
            {
                return value.ToString();
            }
            return "";
        }

        public bool Update(String tableName, Dictionary<String, String> data, String where)
        {
            String vals = "";
            Boolean returnCode = true;
            if (data.Count >= 1)
            {
                foreach (KeyValuePair<String, String> val in data)
                {
                    vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
                }
                vals = vals.Substring(0, vals.Length - 1);
            }
            try
            {
                this.ExecuteNonQuery(String.Format("update {0} set {1} where {2};", tableName, vals, where));
            }
            catch
            {
                returnCode = false;
            }
            return returnCode;
        }

        internal Invoice getInvoice(string invoiceNo)
        {
            string query = "SELECT * FROM faktura WHERE nr = '";
            query +=  invoiceNo + "'";
            DataTable dt = GetDataTable(query);
            Invoice invoice = new Invoice();
            foreach (DataRow dr in dt.Rows)
            {
                invoice.id = int.Parse(dr["id"].ToString());
                invoice.no = dr["nr"].ToString();
                invoice.seller_id = int.Parse(dr["id_sprzedawca"].ToString());
                invoice.buyer_id = int.Parse(dr["id_nabywca"].ToString());
                invoice.order_id = int.Parse(dr["id_usluga"].ToString());
                invoice.issue_date = dr["data_wyst"].ToString();
                invoice.sell_date = dr["data_sprzed"].ToString();
                invoice.payment_deadline = dr["termin_plat"].ToString();
                invoice.payment_method = dr["forma_plat"].ToString();
                invoice.net = dr["netto"].ToString();
                invoice.vat = dr["vat"].ToString();
                invoice.gross = dr["brutto"].ToString();
            }
            return invoice;
        }

        internal Buyer getBuyer(int id)
        {
            string query = "SELECT * FROM nabywca WHERE id = ";
            query += id;
            DataTable dt = GetDataTable(query);
            Buyer buyer = new Buyer();

            foreach (DataRow dr in dt.Rows)
            {
                buyer.id = int.Parse(dr["id"].ToString());
                buyer.name = dr["nazwa"].ToString();
                buyer.postCode = dr["kod"].ToString();
                buyer.city = dr["miasto"].ToString();
                buyer.address = dr["adres"].ToString();
                buyer.nip = dr["nip"].ToString();
            }
                return buyer;
        }

        internal Seller getSeller(int id)
        {
            string query = "SELECT * FROM sprzedawca WHERE id = ";
            query += id;
            DataTable dt = GetDataTable(query);
            Seller seller = new Seller();

            foreach (DataRow dr in dt.Rows)
            {
                seller.id = int.Parse(dr["id"].ToString());
                seller.name = dr["nazwa"].ToString();
                seller.postCode = dr["kod"].ToString();
                seller.city = dr["miasto"].ToString();
                seller.address = dr["adres"].ToString();
                seller.nip = dr["nip"].ToString();
                seller.rachunek = dr["rachunek"].ToString();
                seller.domyslny = int.Parse(dr["domyslny"].ToString());
                seller.signature = dr["podpis"].ToString();
            }
            return seller;
        }

        internal Order getOrder(int id)
        {
            string query = "SELECT * FROM usluga WHERE id = ";
            query += id;
            DataTable dt = GetDataTable(query);
            Order order = new Order();

            foreach(DataRow dr in dt.Rows)
            {
                order.id = int.Parse(dr["id"].ToString());
                order.name = dr["nazwa"].ToString();
            }
            return order;
        }

        internal Order getOrderByName(string name)
        {
            string query = string.Format("SELECT * FROM usluga WHERE nazwa = '{0}'", name);
            DataTable dt = GetDataTable(query);
            Order order = new Order();

            foreach (DataRow dr in dt.Rows)
            {
                order.id = int.Parse(dr["id"].ToString());
                order.name = dr["nazwa"].ToString();
            }
            return order;
        }

        internal string insertOrder(string order)
        {
            Dictionary<string, string> dane = new Dictionary<string, string>();
            dane.Add("nazwa", order);
            return Insert("usluga", dane);
        }

        internal string deleteOrderById( string id)
        {
            return Delete("usluga", "id=" + id);   
        }

        internal bool invoiceWithOrderExist(int orderId)
        {
            string query = string.Format("SELECT COUNT(*) FROM faktura WHERE id_usluga ={0}", orderId);
            int count =0;
            if (Int32.TryParse(ExecuteScalar(query), out count)){
                if(count >0)
                {
                    return true;
                }
            }
            return false;
        }

        public String Delete(String tableName, String where)
        {
            String answer = "ok";
            try
            {
                this.ExecuteNonQuery(String.Format("delete from {0} where {1};", tableName, where));
            }
            catch (Exception fail)
            {
                answer = fail.Message;
            }
            return answer;
        }

        public string InsertInvoice(Invoice invoice)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("nr", invoice.no);
            data.Add("id_sprzedawca", invoice.seller_id.ToString());
            data.Add("id_nabywca", invoice.buyer_id.ToString());
            data.Add("id_usluga", invoice.order_id.ToString());
            data.Add("data_wyst", invoice.issue_date);
            data.Add("data_sprzed", invoice.sell_date);
            data.Add("forma_plat", invoice.payment_method);
            data.Add("termin_plat", invoice.payment_deadline);
            data.Add("netto", invoice.net);
            data.Add("vat", invoice.vat);
            data.Add("brutto", invoice.gross);
            return Insert("faktura", data);
        }

        public String Insert(String tableName, Dictionary<String, String> data)
        {
            String columns = "";
            String values = "";
            String answer = "ok";
            foreach (KeyValuePair<String, String> val in data)
            {
                columns += String.Format(" {0},", val.Key.ToString());
                values += String.Format(" '{0}',", val.Value);
            }
            columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);
            try
            {
                this.ExecuteNonQuery(String.Format("insert into {0}({1}) values({2});", tableName, columns, values));
            }
            catch (Exception fail)
            {
                answer = fail.Message;
                
            }
            return answer;
        }
        /*
                public bool ClearDB()
                {
                    DataTable tables;
                    try
                    {
                        tables = this.GetDataTable("select NAME from faktura.db where type='table' order by NAME;");
                        foreach (DataRow table in tables.Rows)
                        {
                            this.ClearTable(table["NAME"].ToString());
                        }
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }

                public bool ClearTable(String table)
                {
                    try
                    {
                        this.ExecuteNonQuery(String.Format("delete from {0};", table));
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }      
        */
    }
}
