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
        public  MySqlConnection con;
        public  MySqlCommand cmd;
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

        bool chooseByRole(){
            cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@username", usetname.Text);
            cmd.Prepare();
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {

                return true;
               
            }
            else
            {

                return false;

            }

        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if(usetname.Text!="" && password.Text != "" && role.SelectedIndex!=-1)
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
                        rdr.Close();

                        if (role.Text == "teacher")
                        {
                            sql = "SELECT * FROM `teacher` where username= @username";
                            if (chooseByRole()) {

                                MessageBox.Show("how nice ^__^ !!");
                                rdr.Close();

                            }
                            else
                            {
                                MessageBox.Show("verify the role");
                                rdr.Close();

                            }
                        }
                        else if (role.Text == "student")
                        {
                            sql = "SELECT * FROM `student` where username= @username";
                            if (chooseByRole())
                            {

                                MessageBox.Show("how nice ^__^ !!");
                                rdr.Close();

                            }
                            else
                            {
                                MessageBox.Show("verify the role");
                                rdr.Close();

                            }

                        }
                        else if(role.Text == "admin")
                        {
                            sql = "SELECT * FROM `teacher` where username= @username";
                            bool t=chooseByRole();
                            rdr.Close();

                            sql = "SELECT * FROM `student` where username= @username";
                            bool s=chooseByRole();
                            rdr.Close();

                            if (s || t)
                            {
                                MessageBox.Show("verify the role");

                            }
                            else
                            {
                                DashboardAdmin d = new DashboardAdmin();
                                con.Close();

                                d.Show();
                                this.Hide();
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("verify your username and password,don't forget to choose role");
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
