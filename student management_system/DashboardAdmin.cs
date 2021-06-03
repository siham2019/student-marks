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
    public partial class DashboardAdmin : Form
    {
        public MySqlConnection con;
        public MySqlCommand cmd;
        public MySqlDataReader rdr;
        public string sql;
        public  string count()
        {

             this.cmd = new MySql.Data.MySqlClient.MySqlCommand(this.sql, this.con);
             var rdr = this.cmd.ExecuteScalar();
             return Convert.ToInt32(rdr).ToString();
        }


        public DashboardAdmin()
        {
            try
            {
                InitializeComponent();
                string cs = @"server=localhost;userid=root;password=;database=marks_students";
                con = new MySqlConnection(cs);
                con.Open();
                  sql = "SELECT count(*) FROM `student`";
                 total_s.Text = count();
                
                 sql = "SELECT count(*) FROM `student` where sex='female'";
                 female_s.Text = count();

                 sql = "SELECT count(*) FROM `student` where sex='male'";
                 male_s.Text = count();




                 sql = "SELECT count(*) FROM `teacher`";
                 total_t.Text = count();


                 sql = "SELECT count(*) FROM `teacher` where sex='female'";
                 female_t.Text = count();

                 sql = "SELECT count(*) FROM `teacher` where sex='male'";
                 male_t.Text = count();






                 sql = "SELECT count(*) FROM `course`";
                 total_c.Text = count();

                 sql = "SELECT count(*) FROM `level`";
                 total_l.Text = count();
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            user u = new user();
            u.TopLevel = false;
            panel1.Controls.Add(u);
            u.Show();

        }
    }
}
