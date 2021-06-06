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

        string sql, text;
        void display()
        {
            dt = new DataTable();


            sql = "SELECT * FROM `teacher`";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, Form1.con);
            da.Fill(dt);
            dt.Columns.Add("picture", Type.GetType("System.Byte[]"));

            foreach (DataRow r in dt.Rows)
            {
                r["picture"] = File.ReadAllBytes("//image//"+r["image"].ToString());

            }
            dt.Columns.Remove("image");


            dataGridView1.DataSource = dt;

            dataGridView1.Columns[2].MinimumWidth = 250;

            dataGridView1.Columns[7].MinimumWidth = 100;
            DataGridViewImageColumn i = (DataGridViewImageColumn)dataGridView1.Columns[7];
            i.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void teacher_Load(object sender, EventArgs e)
        {

            display();
            sql = "SELECT user.username FROM `user` INNER JOIN teacher on user.username!=teacher.username WHERE user.type='teacher'";
            Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Form1.con);
            rdr=Form1.cmd.ExecuteReader();
            while (rdr.Read())
            {
                username.Items.Add(rdr["username"]);
            }
            rdr.Close();
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
                MessageBox.Show(text);
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
            }
            catch (Exception ex)
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
