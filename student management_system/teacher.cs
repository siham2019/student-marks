using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_management_system
{
    public partial class teacher : Form
    {
        DataTable dt = new DataTable();
        public MySqlDataReader rdr;
        int id;
        string dd;
        string sql, text;
        bool yes = true;

        void display()
        {

            dt = new DataTable();


            sql = "SELECT * FROM `teacher`";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, Form1.con);
            da.Fill(dt);
            dt.Columns.Add("picture", Type.GetType("System.Byte[]"));

            foreach (DataRow r in dt.Rows)
            {
                r["picture"] = File.ReadAllBytes(Application.StartupPath + "//image//" +r["image"].ToString());

            }
            


            dataGridView1.DataSource = dt;

            dataGridView1.Columns[2].MinimumWidth = 250;

            dataGridView1.Columns[7].MinimumWidth = 100;
            DataGridViewImageColumn i = (DataGridViewImageColumn)dataGridView1.Columns[8];
            i.ImageLayout = DataGridViewImageCellLayout.Stretch;


        }

        void combo_show()
        {

            sql = "SELECT username FROM `user` WHERE type='teacher'";
            Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Form1.con);
            rdr = Form1.cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    username.Items.Add(rdr["username"]);
                }
            }
            else
            {

                add.Enabled = false;
                label9.Text = "add new user";
                label9.ForeColor = Color.Red;


            }

            rdr.Close();
        }

        private void teacher_Load(object sender, EventArgs e)
        {

            display();
            combo_show();

        }

        private void upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
       

            if (f.ShowDialog() == DialogResult.OK)
            {
                   
                 image1.Image= new Bitmap(f.FileName);
                image1.ImageLocation = f.FileName;
            }


        }

        private void add_Click(object sender, EventArgs e)
        {

            try
            {
                text = Application.StartupPath + "\\image\\" + Path.GetFileName(image1.ImageLocation);
                if (File.Exists(text))
                {
                    MessageBox.Show("the image is already exists");
                }
                else
                {
                    File.Copy(image1.ImageLocation, text);
                    sql = "INSERT INTO `teacher` (`id`, `full_name`, `adress`, `email`, `image`, `n_tel`, `username`, `sex`) VALUES (NULL, '"+full_name.Text+ "', '"+adress.Text+"', '"+ email.Text + "', '" + Path.GetFileName(image1.ImageLocation) + "', '" + phone.Text + "', '" + username.Text + "', '" + sex.Text + "')";

                    Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Form1.con);
                    Form1.cmd.ExecuteNonQuery();
                    MessageBox.Show("success");
                   
                }
                display();
            }
              catch (MySqlException ex)
            {
                if (ex.ErrorCode ==-2147467259)
                {
                    MessageBox.Show("this user is already affect try another one");
                    File.Delete(text);
                }
            }
          
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            update.Enabled = true;
            delete.Enabled = true;
            add.Enabled = false;

            id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            full_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            adress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            email.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            phone.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            sex.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            username.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();



            dd = Application.StartupPath + "\\image\\" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

           

            image1.Load(dd);

        }


        void clear()
        {
            full_name.Text = "";
            email.Text = "";
            adress.Text = "";
            phone.Text = "";
            image1.Image = null;
        }


        private void update_Click(object sender, EventArgs e)
        {
            if (full_name.Text != "" && email.Text != "" && adress.Text != "" && phone.Text != "" && image1.Image != null)
            {

                try
                {
                    text = Application.StartupPath + "\\image\\" + Path.GetFileName(image1.ImageLocation);


                    if (File.Exists(text) == true)
                    {
                        text = image1.ImageLocation;
                    }
                    else
                    {
                        yes = true;
                        File.Copy(image1.ImageLocation, text);
                       

                    }

                    sql = "UPDATE `teacher` SET `full_name` = '" + full_name.Text + "', `adress` = '" + adress.Text + "', `email` = '" + email.Text + "', `image` = '" + Path.GetFileName(text) + "', `n_tel` = '" + phone.Text + "', `username` = '" + username.Text + "' WHERE `teacher`.`id` = " + id;

                    Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Form1.con);
                    Form1.cmd.ExecuteNonQuery();
                    MessageBox.Show("success");

                    add.Enabled = true;
                    update.Enabled = false;
                    delete.Enabled = false;

                    display();
                }
                catch (MySqlException ex)
                {
                    if (ex.ErrorCode == -2147467259)
                    {
                        MessageBox.Show("this user is already affect try another one");
                        if (yes)
                        {
                            File.Delete(text);
                            yes = false;
                        }
                    }
                }
                clear();
                /*if (yes) {
                    
                    File.Delete(dd);
                }
                */
                yes = false;

            }
            else
            {
                MessageBox.Show("you miss to fill an input");
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {

                sql = "DELETE FROM `teacher` WHERE `teacher`.`id` = " + id;

                Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Form1.con);
                Form1.cmd.ExecuteNonQuery();
                MessageBox.Show("success");
                display();
                clear();
                //File.Delete(dd);
                add.Enabled = true;
                update.Enabled = false;
                delete.Enabled = false;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public teacher()
        {
            InitializeComponent();

            
           
        }
    }
}
