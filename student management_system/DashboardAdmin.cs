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
  
      
        public string sql;
        public  string count()
        {

             Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(this.sql, Form1.con);
             var rdr = Form1.cmd.ExecuteScalar();
           
             return Convert.ToInt32(rdr).ToString();
        }


        public DashboardAdmin()
        {
            try
            {
                InitializeComponent();
               

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
                MessageBox.Show(ex.Message);
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
            user u = new user();
            show(u);
        }

        public void show(Form f)
        {
            panel1.Controls.Clear();

            f.TopLevel = false;
            panel1.Controls.Add(f);
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            teacher t = new teacher();
            show(t);
        }
    }
}
 