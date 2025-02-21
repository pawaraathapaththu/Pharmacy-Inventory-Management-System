using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Medicare_Management
{
    class dba
    {
        public MySqlConnection con;

        public dba()
        {
            initialize();

        }
        public void initialize()
        {
            try
            {
                string cstring = "server=localhost;database=medicare;username=root;password=Azone123";
                con = new MySqlConnection(cstring);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        bool openCon()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        bool closeCon()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("can't close");
                return false;
            }
        }
        public void cud(string sql)
        {
            try
            {
                if (openCon() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Succeed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.closeCon();
            }
        }
        public void staffTable(string sql)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, con);
            sda.Fill(E_MEd.st);

        }
        public void customerTable(string sql)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, con);
            sda.Fill(E_MEd.ct);
        }
        public void CategoryTable(string sql)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, con);
            sda.Fill(E_MEd.catt);
        }
        public void ProdctTable(string sql)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, con);
            sda.Fill(E_MEd.pt);
        }
        public void Populate(string sql)
        {
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, con);
            sda.Fill(E_MEd.tab);
        }


        public void retrive(string sql, string table)
        {
            try
            {
                if (openCon() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (table == "Category")
                    {
                        while (reader.Read())
                        {

                            E_MEd.CategoryName = reader["CategoryName"].ToString();
                            E_MEd.Cat.Add(E_MEd.CategoryName);

                        }
                    }
                    else if (table == "Staff")
                    {
                        while (reader.Read())
                        {

                            E_MEd.Role = reader["Role"].ToString();
                            E_MEd.stff.Add(E_MEd.Role);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.closeCon();
            }

        }
 
    

    }
}
