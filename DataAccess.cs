using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows;

namespace SQLite_Homework
{
    class DataAccess
    {

        public static void IntitializeDatabase()
        {
            using (SqliteConnection db = new SqliteConnection("Filename=TestData.db"))
            {
                db.Open();
                //string tblcommand = "";
                SqliteCommand table = new SqliteCommand
                    ("CREATE TABLE IF NOT EXISTS kunetbl " +
                    "(uid INTEGER PRIMARY KEY ," +
                    "Firstname CHAR(20) NULL , " +
                    "Lastname CHAR (20) NULL , " +
                    "Email CHAR(20) NULL)", db);

                table.ExecuteReader();
            }
        }

        public static void AddData(string inputuid, string inputfirstname, string inputlastname, string inputemail)
        {
            using (SqliteConnection db = new SqliteConnection($"Filename=TestData.db"))
            {
                db.Open();

                SqliteCommand insert = new SqliteCommand();
                insert.Connection = db;
                insert.CommandText = ("INSERT INTO kunetbl VALUES(@uid , @firstname , @lastname , @email)");
                insert.Parameters.AddWithValue("@uid", inputuid);
                insert.Parameters.AddWithValue("@firstname", inputfirstname);
                insert.Parameters.AddWithValue("@lastname", inputlastname);
                insert.Parameters.AddWithValue("@email", inputemail);

                SqliteDataReader query = insert.ExecuteReader();
                if (insert.Parameters[0].Value.ToString()== inputuid)  
                {
                    MessageBox.Show("ALREADY ADD DATA");
                }
                db.Close();
            
            }
           
        }

        public static List<String> GetData()
        {
            List<string> entries = new List<string>();

            using (SqliteConnection db = new SqliteConnection("Filename=TestData.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT uid ,firstname ,lastname ,email from kunetbl" , db);

                SqliteDataReader query = selectCommand.ExecuteReader();
              
                while(query.Read())
                {
                    entries.Add("uid :"+query.GetString(0)+"\n");
                    entries.Add("name :"+query.GetString(1) + "\n ");
                    entries.Add("lastname :"+query.GetString(2) + "\n");
                    entries.Add("email :"+query.GetString(3) + "\n\n");
                }

                db.Close();
        
            }

            return entries;
        }

    }
}

