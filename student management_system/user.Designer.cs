namespace student_management_system
{
    partial class user
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.username_t = new System.Windows.Forms.TextBox();
            this.type_t = new System.Windows.Forms.ComboBox();
            this.add = new System.Windows.Forms.Button();
            this.password_t = new System.Windows.Forms.TextBox();
            this.update = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(773, 262);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // username_t
            // 
            this.username_t.Location = new System.Drawing.Point(72, 372);
            this.username_t.Multiline = true;
            this.username_t.Name = "username_t";
            this.username_t.Size = new System.Drawing.Size(218, 26);
            this.username_t.TabIndex = 1;
            // 
            // type_t
            // 
            this.type_t.FormattingEnabled = true;
            this.type_t.Items.AddRange(new object[] {
            "student",
            "teacher",
            "admin"});
            this.type_t.Location = new System.Drawing.Point(72, 427);
            this.type_t.Name = "type_t";
            this.type_t.Size = new System.Drawing.Size(218, 21);
            this.type_t.TabIndex = 2;
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.Teal;
            this.add.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.add.Location = new System.Drawing.Point(6, 33);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(205, 39);
            this.add.TabIndex = 4;
            this.add.Text = "add";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // password_t
            // 
            this.password_t.Location = new System.Drawing.Point(329, 376);
            this.password_t.Multiline = true;
            this.password_t.Name = "password_t";
            this.password_t.Size = new System.Drawing.Size(218, 25);
            this.password_t.TabIndex = 5;
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.Color.Teal;
            this.update.Enabled = false;
            this.update.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.update.Location = new System.Drawing.Point(6, 85);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(205, 37);
            this.update.TabIndex = 6;
            this.update.Text = "update";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Teal;
            this.delete.Enabled = false;
            this.delete.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.delete.Location = new System.Drawing.Point(6, 134);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(205, 39);
            this.delete.TabIndex = 7;
            this.delete.Text = "delete";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.update);
            this.groupBox1.Controls.Add(this.add);
            this.groupBox1.Controls.Add(this.delete);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(572, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 181);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "operations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 349);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(325, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(68, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(310, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 29);
            this.label5.TabIndex = 13;
            this.label5.Text = "User management";
            // 
            // user
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(816, 510);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.password_t);
            this.Controls.Add(this.type_t);
            this.Controls.Add(this.username_t);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "user";
            this.Text = "user";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox username_t;
        private System.Windows.Forms.ComboBox type_t;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox password_t;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}