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
    public partial class user : Form
    {
        DataTable dt = new DataTable();
        public MySqlDataReader rdr;

        string sql,usern;
        public user()
        {
            InitializeComponent();
            display();
        }
        void display()
        {
            sql = "SELECT * FROM `user`";
            dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, Form1.con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            DataGridViewColumn column = dataGridView1.Columns[0];
            column.MinimumWidth = 250;

            column = dataGridView1.Columns[2];
            column.MinimumWidth = 240;

            column = dataGridView1.Columns[1];
            column.MinimumWidth = 240;

        }


        private void add_Click(object sender, EventArgs e)
        {
            update.Enabled = false;
            delete.Enabled = false;
            // INSERT INTO `user` (`username`, `password`, `type`) VALUES ('', '', '')
            try
            {
                if (username_t.Text !="" && password_t.Text!="")
                {
                    sql = "INSERT INTO `user` (`username`, `password`, `type`) VALUES ('" + username_t.Text + "', '" + password_t.Text + "', '" + type_t.Text + "')";

                    Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Form1.con);
                    Form1.cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("you should enter the username and the password ");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.ErrorCode ==1062)
                {
                    MessageBox.Show("username exists" );

                }

            }
            display();
            clear();
        }
        void clear()
        {

            username_t.Text = "";
            password_t.Text = "";


        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            update.Enabled = true;
            delete.Enabled = true;
            add.Enabled = false;

            usern = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            username_t.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            password_t.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            type_t.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void delete_Click(object sender, EventArgs e)
        {


            try
            {

                sql = " DELETE FROM `user` WHERE `user`.`username` = '" + usern + "' ";

                Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Form1.con);
                Form1.cmd.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {

                if (ex.Number == 1451)
                {
                    MessageBox.Show("you can't delete it !! try first to delete the person you affect to it");
                }


            }

            add.Enabled = true;
            update.Enabled = false;
            delete.Enabled = false;
            clear();
            display();
        }

        private void update_Click(object sender, EventArgs e)
        {
            
            try
            {
              
                sql = "UPDATE `user` SET `username` = '"+username_t.Text+"', `password` = '"+password_t.Text+"', `type` = '"+type_t.Text+"' WHERE `user`.`username` = '"+usern+"' ";

                Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Form1.con);
                Form1.cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {

                if (ex.ErrorCode == 1062)
                {
                    MessageBox.Show("username exists  ");

                }


            }
            add.Enabled = true;
            update.Enabled = false;
            delete.Enabled = false;
            clear();
            display();
        }
    }
}
