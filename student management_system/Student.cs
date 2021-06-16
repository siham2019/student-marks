using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class Student : Form
    {
        int page = 0;
        int stop;
        int totalpage;
        public Student()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        public MySqlDataReader rdr;
        int id;
        string dd;
        string sql, text;


        void display()
        {

            if (button3.Enabled == false) button3.Enabled = true;
            if (button2.Enabled == false) button2.Enabled = true;

            sql = "select count(*) from student";

            Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Form1.con);
            var u=Form1.cmd.ExecuteScalar();


            stop = 3*page;
            sql = "SELECT student.*,level.name FROM `student` inner JOIN level on level.id = student.level_id ORDER BY `student`.`full_name` ASC limit " + page+",3";

            dt = new DataTable();

            MySqlDataAdapter da = new MySqlDataAdapter(sql, Form1.con);
            da.Fill(dt);
            dt.Columns.Add("picture", Type.GetType("System.Byte[]"));

            foreach (DataRow r in dt.Rows)
            {

                r["picture"] = File.ReadAllBytes(Application.StartupPath + "//image//" + r["image"].ToString());

            }

          //  dt.Columns.Remove("image");

            dataGridView2.DataSource = dt;

          
            DataGridViewImageColumn i = (DataGridViewImageColumn)dataGridView2.Columns[12];
            i.ImageLayout = DataGridViewImageCellLayout.Stretch;

            if (totalpage == 0)
            {
                totalpage = Convert.ToInt16(Math.Floor(Convert.ToDecimal(u) / 3))+ Convert.ToInt16(u) % 3;
            }
             
            current_page.Text = page + 1 + "/ " + totalpage;

        }

        void combo_show()
        {

            sql = "SELECT username FROM `user` WHERE type='student'";
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
                error.Text = "add new user";
                error.ForeColor = Color.Red;


            }

            rdr.Close();

            sql = "SELECT * FROM `level`";
            Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Form1.con);
            rdr = Form1.cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                Dictionary<int,string> comboSource = new Dictionary<int, string>();

                while (rdr.Read())
                {
                    comboSource.Add(Convert.ToInt16(rdr["id"]), rdr["name"].ToString());
                }

                level.DataSource = new BindingSource(comboSource, null);
                level.DisplayMember = "Value";
                level.ValueMember = "Key";
            }
            else
            {

                add.Enabled = false;
                error.Text = "add new level";
                error.ForeColor = Color.Red;


            }

            rdr.Close();

        }

        private void add_Click(object sender, EventArgs e)
        {
         
           text = Application.StartupPath + "\\image\\" + Path.GetFileName(image1.ImageLocation);
            if (File.Exists(text))
            {
                MessageBox.Show("the image is already exists");
            }
            else
            {
                File.Copy(image1.ImageLocation, text);
                int key = ((KeyValuePair<int, string>)level.SelectedItem).Key;

                sql = "INSERT INTO `student` (`id`,`num_ins`, `full_name`, `email`, `adress`, `n_tel`, `level_id`, `image`, `username`, `sex`, `birthday`) VALUES ('NULL','" + n_ins.Text + "', '" + full_name.Text + "', '" + email.Text + "', '" + adress.Text + "', '" + phone.Text + "', '" + key + "', '" + Path.GetFileName(text) + "', '" + username.SelectedItem + "', '" + sex.SelectedItem + "', '" + birthday.Value.ToString("yyyy-MM-dd") + "')";


                Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Form1.con);
                Form1.cmd.ExecuteNonQuery();
                MessageBox.Show("success");

            }       
    }

          




       

        private void upload_Click(object sender, EventArgs e)
        {
            teacher.upload_image(image1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            display();
        }

        private void print_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PDF Files|*.pdf";
            dlg.FilterIndex = 0;

            string fileName = string.Empty;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;

                Document myDocument = new Document(iTextSharp.text.PageSize.A4);
                PdfWriter.GetInstance(myDocument, new FileStream(fileName, FileMode.Create));
                myDocument.Open();

                myDocument.AddTitle("Student List");

                Paragraph p= new Paragraph("Students list");
                p.Alignment = Element.ALIGN_CENTER;
                p.Font.Size =24;

                PdfPTable table = new PdfPTable(6);
                table.SpacingBefore = 23;


                table.AddCell("N°");

                table.AddCell("full name");
               

                table.AddCell("sex");

                table.AddCell("birthday");


                table.AddCell("level");


                table.AddCell("image");

                 sql = "SELECT student.*,level.name FROM `student` inner JOIN level on level.id = student.level_id ";

                Form1.cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Form1.con);
                rdr=Form1.cmd.ExecuteReader();

                while (rdr.Read())
                {
                    table.AddCell(rdr["num_ins"].ToString());

                    PdfPCell full = new PdfPCell();
                    full.AddElement(new Phrase(rdr["full_name"].ToString()));
                    full.Padding =10;
                    table.AddCell(full);

                    table.AddCell(rdr["sex"].ToString());

                    DateTime r = Convert.ToDateTime(rdr["birthday"]);

                    table.AddCell(r.ToShortDateString());
                    table.AddCell(rdr["name"].ToString());

                    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Application.StartupPath + "\\image\\" + rdr["image"] ,true);
                    jpg.ScaleAbsolute(60, 55);

                    PdfPCell imgCell1 = new PdfPCell();
                    imgCell1.AddElement(new Chunk(jpg, 4, -37));

                    imgCell1.MinimumHeight = 63;

                    table.AddCell(imgCell1);
                    
                }


                myDocument.Add(p);
                myDocument.Add(table);
                myDocument.Close();
            }



        }

      

        private void button3_Click(object sender, EventArgs e)
        {

            page++;

            if (page+1 > totalpage)
            {
                button3.Enabled = false;

            }
            else
            {
               
                current_page.Text = page + 1 + "/ " + totalpage;

                display();
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            page--;

            if (page<0)
            {
                button2.Enabled = false;
                page = 0;
            }
            else
            {
                current_page.Text = page + 1 + "/ " + totalpage;

                display();
            }
          
        }

        private void Student_Load(object sender, EventArgs e)
        {

            display();
            combo_show();
        }
    }
}
