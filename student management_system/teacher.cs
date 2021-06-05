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
    public partial class teacher : Form
    {
        DataTable dt = new DataTable();
        public MySqlDataReader rdr;

        string sql, t;
        public teacher()
        {
            InitializeComponent();

            dt = new DataTable();
            dt.Columns.Add("image");

            var y=dt.NewRow();
            DataGridViewImageColumn u = new DataGridViewImageColumn();
            u.Image =(Image)new Bitmap("F:\\vv\\student management_system\\student management_system\\image\\banner-psy-735x550.jpg");
           
            y[0] = u.Image;
            dt.Rows.Add(y);

            /*  sql = "SELECT id,full_name,adress,sex,email,n_tel,username FROM `teacher`";

              MySqlDataAdapter da = new MySqlDataAdapter(sql, Form1.con);
              da.Fill(dt);
           */

            dataGridView1.DataSource = dt;

          
          
            /*
            DataGridViewColumn column = dataGridView1.Columns[2];
            column.MinimumWidth = 250;

            column = dataGridView1.Columns[4];
            column.MinimumWidth = 240;
            */
           
        }
    }
}
