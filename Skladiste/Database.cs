using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Skladiste
{
    class Database
    {
        public static string infoMessage = "";
        private static int delay = 300;

        public static NpgsqlConnection GetConenction()
        {
            string server, username, password, database;
            int port;

            server = "127.0.1.1";
            port = 5432;
            username = "postgres";
            password = "admin";
            database = "postgres";

            string connString = String.Format("Server={0};Port={1};" +
                   "User Id={2};Password={3};Database={4};",
                   server, port, username, password, database);

            NpgsqlConnection connection = new NpgsqlConnection(connString);
            connection.Open();

            return connection;
        }


        public static void ExecuteSQL(string query, NpgsqlConnection con)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }

        public static void insertKupacRand(NpgsqlConnection con)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "INSERT INTO kupac(id, ime, artikl, kolicina) " +
                         "VALUES(default, '" + Data.getName() + "', '" + Data.getItem() + "', " + Data.getQuantity() + ")";

            Console.WriteLine(sql);
            infoMessage = sql; 
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static void insertKupac(NpgsqlConnection con, string ime, string artikl, int kolicina)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "INSERT INTO kupac(id, ime, artikl, kolicina) " +
                         "VALUES(default, '" + ime + "', '" + artikl+ "', " + kolicina + ")";

            Console.WriteLine(sql);
            infoMessage = sql;
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static void updateKupac(NpgsqlConnection con, string ime, string artikl, int kolicina, int id)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "UPDATE kupac set ime='" + ime + "', artikl='" + artikl + "', kolicina=" + kolicina + " where id=" + id;

            Console.WriteLine(sql);
            infoMessage = sql;
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static void deleteKupacAll(NpgsqlConnection con)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "DELETE FROM kupac";

            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static void deleteKupac(NpgsqlConnection con, int id)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "DELETE FROM kupac where id=" +id;
            infoMessage = sql;
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static DataTable selectKupacInProces()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            NpgsqlConnection con = Database.GetConenction();

            string sql = "SELECT * FROM kupac WHERE procesiranje=1";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);

            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);

            return dt;
        }

        public static DataTable selectKupacProcessed()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            NpgsqlConnection con = Database.GetConenction();

            string sql = "SELECT * FROM kupac WHERE procesiranje=2";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);

            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);

            return dt;
        }


        public static void insertSkladisteRand(NpgsqlConnection con)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "INSERT INTO skladiste(id, artikl, kolicina,  min_kolicina, max_kolicina, datum_dolaska, rok_trajanja) " +
                         "VALUES(default, '" + Data.getItem() + "', " + Data.getQuantity() + " , " +
                         Data.getMinimum() + " , " + Data.getMaximum() + " , '" + DateTime.Now + "', '"+
                         DateTime.Now.AddDays(Data.getExpiration()) + "')";

            Console.WriteLine(sql);
            infoMessage = sql;
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static void insertSkladiste(NpgsqlConnection con, string artikl, int kolicina, int min, int max, DateTime rok)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "INSERT INTO skladiste(id, artikl, kolicina,  min_kolicina, max_kolicina, datum_dolaska, rok_trajanja) " +
                         "VALUES(default, '" + artikl + "', " + kolicina + " , " +
                         min+ " , " + max + " , '" + DateTime.Now + "', '" +
                         rok + "')";

            Console.WriteLine(sql);
            infoMessage = sql;
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static void deleteSkladisteAll(NpgsqlConnection con)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "DELETE FROM skladiste";
            infoMessage = sql;
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static void deleteSkladiste(NpgsqlConnection con, int id)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "DELETE FROM skladiste where id=" + id;
            infoMessage = sql;
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static void updateSkladiste(NpgsqlConnection con, string artikl, int kolicina, int min, int max, int id, DateTime rok)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "UPDATE skladiste set artikl='" + artikl + "', kolicina=" + kolicina + " , min_kolicina=" +
                         min + " , max_kolicina=" + max + " , rok_trajanja=" + rok + " where id=" + id;

            Console.WriteLine(sql);
            infoMessage = sql;
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static void deleteNarudzba(NpgsqlConnection con, int id)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "DELETE FROM narudzba where id=" + id;
            infoMessage = sql;
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static void deleteNarudzbaAll(NpgsqlConnection con)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "DELETE FROM narudzba";
            infoMessage = sql;
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }
        public static void deleteVelenarudzba(NpgsqlConnection con, int id)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "DELETE FROM velenarudzba where id=" + id;
            infoMessage = sql;
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static void deleteVelenarudzbaAll(NpgsqlConnection con)
        {
            var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            string sql = "DELETE FROM velenarudzba";
            infoMessage = sql;
            try
            {
                Database.ExecuteSQL(sql, con);
            }
            catch (NpgsqlException npqe)
            {
                MessageBox.Show(npqe + "\nError on query:" + sql, "ERROR");
            }
            Thread.Sleep(delay);
        }

        public static void deleteAll()
        {
            NpgsqlConnection con = Database.GetConenction();
            deleteNarudzbaAll(con);
            deleteVelenarudzbaAll(con);
            deleteSkladisteAll(con);
            deleteKupacAll(con);            
            con.Close();
        }

    }
}
