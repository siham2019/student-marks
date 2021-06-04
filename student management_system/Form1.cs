using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class Form1 : Form
    {
        public static MySqlConnection con;
        public static MySqlCommand cmd;
        public  MySqlDataReader rdr;
        public  string sql;
        public Form1()
        {
            InitializeComponent();

            try
            {
                string cs = @"server=localhost;userid=root;password=;database=marks_students";
                con = new MySqlConnection(cs);
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if(usetname.Text!="" && password.Text != "" )
            {
                try
                {
                    sql = "SELECT * FROM `user` where username= @username and password= @password";
                      cmd = new MySqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@username",usetname.Text);
                    cmd.Parameters.AddWithValue("@password",password.Text);
                    cmd.Prepare();

                    rdr=cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        string type = rdr["type"].ToString();
                        if (type == "teacher")
                        {
                            rdr.Close();

                            //do somthing
                        }
                        else if (type == "student")
                        {
                            rdr.Close();

                            //do somthing

                        }
                        else if(type == "admin")
                        {
                            rdr.Close();

                            DashboardAdmin d = new DashboardAdmin();
                             

                                d.Show();
                                this.Hide();
                 
                        }

                    }
                    else
                    {
                        rdr.Close();

                        MessageBox.Show("verify your username and password");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("you should enter username and password ,don't forget to choose role");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Close();
            Environment.Exit(0);
        }
    }
}
