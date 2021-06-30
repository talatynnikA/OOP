
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.kurstextBox = new System.Windows.Forms.TextBox();
            this.disciplinetxtBox = new System.Windows.Forms.TextBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.controlBox1 = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.semgroupBox1 = new System.Windows.Forms.GroupBox();
            this.specgroupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LectorSurtextBox3 = new System.Windows.Forms.TextBox();
            this.LectNamtxtBox = new System.Windows.Forms.TextBox();
            this.lectKoltextBox5 = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LectPatrtxtBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.semgroupBox1.SuspendLayout();
            this.specgroupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "ПОИТ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 38);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(43, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // kurstextBox
            // 
            this.kurstextBox.Location = new System.Drawing.Point(21, 131);
            this.kurstextBox.Name = "kurstextBox";
            this.kurstextBox.Size = new System.Drawing.Size(100, 26);
            this.kurstextBox.TabIndex = 2;
            this.kurstextBox.TextChanged += new System.EventHandler(this.kurstextBox_TextChanged);
            // 
            // disciplinetxtBox
            // 
            this.disciplinetxtBox.Location = new System.Drawing.Point(21, 63);
            this.disciplinetxtBox.Name = "disciplinetxtBox";
            this.disciplinetxtBox.Size = new System.Drawing.Size(100, 26);
            this.disciplinetxtBox.TabIndex = 3;
            this.disciplinetxtBox.TextChanged += new System.EventHandler(this.disciplinetxtBox_TextChanged);
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(21, 593);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(90, 34);
            this.OpenButton.TabIndex = 4;
            this.OpenButton.Text = "Открыть";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Название дисциплины";
            // 
            // controlBox1
            // 
            this.controlBox1.AllowDrop = true;
            this.controlBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.controlBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.controlBox1.FormattingEnabled = true;
            this.controlBox1.Items.AddRange(new object[] {
            "Экзамен",
            "Зачет"});
            this.controlBox1.Location = new System.Drawing.Point(574, 185);
            this.controlBox1.Name = "controlBox1";
            this.controlBox1.Size = new System.Drawing.Size(121, 28);
            this.controlBox1.TabIndex = 8;
            this.controlBox1.SelectedIndexChanged += new System.EventHandler(this.controlBox1_SelectedIndexChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(604, 103);
            this.trackBar1.Maximum = 16;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(194, 69);
            this.trackBar1.TabIndex = 16;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(282, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Учебный отдел";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(282, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Количество лекций";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(16, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Курс";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(17, 68);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(43, 24);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // semgroupBox1
            // 
            this.semgroupBox1.Controls.Add(this.radioButton1);
            this.semgroupBox1.Controls.Add(this.radioButton2);
            this.semgroupBox1.Location = new System.Drawing.Point(21, 170);
            this.semgroupBox1.Name = "semgroupBox1";
            this.semgroupBox1.Size = new System.Drawing.Size(113, 124);
            this.semgroupBox1.TabIndex = 14;
            this.semgroupBox1.TabStop = false;
            this.semgroupBox1.Text = "Семестр";
            this.semgroupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // specgroupBox2
            // 
            this.specgroupBox2.Controls.Add(this.checkBox4);
            this.specgroupBox2.Controls.Add(this.checkBox3);
            this.specgroupBox2.Controls.Add(this.checkBox2);
            this.specgroupBox2.Controls.Add(this.checkBox1);
            this.specgroupBox2.Location = new System.Drawing.Point(21, 301);
            this.specgroupBox2.Name = "specgroupBox2";
            this.specgroupBox2.Size = new System.Drawing.Size(200, 163);
            this.specgroupBox2.TabIndex = 15;
            this.specgroupBox2.TabStop = false;
            this.specgroupBox2.Text = "Специальность";
            this.specgroupBox2.Enter += new System.EventHandler(this.specgroupBox2_Enter);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(17, 115);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(75, 24);
            this.checkBox4.TabIndex = 18;
            this.checkBox4.Text = "ИСиТ";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(17, 85);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(105, 24);
            this.checkBox3.TabIndex = 17;
            this.checkBox3.Text = "ПОИБМС";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(17, 55);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(81, 24);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "ДЭВИ";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(282, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(316, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Количество лабораторных(1-16)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(282, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Вид контроля(экз.\\зачет)";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(282, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "Лектор";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // LectorSurtextBox3
            // 
            this.LectorSurtextBox3.Location = new System.Drawing.Point(412, 227);
            this.LectorSurtextBox3.Name = "LectorSurtextBox3";
            this.LectorSurtextBox3.Size = new System.Drawing.Size(188, 26);
            this.LectorSurtextBox3.TabIndex = 19;
            this.LectorSurtextBox3.TextChanged += new System.EventHandler(this.LectorSurtextBox3_TextChanged);
            // 
            // LectNamtxtBox
            // 
            this.LectNamtxtBox.Location = new System.Drawing.Point(647, 227);
            this.LectNamtxtBox.Name = "LectNamtxtBox";
            this.LectNamtxtBox.Size = new System.Drawing.Size(155, 26);
            this.LectNamtxtBox.TabIndex = 20;
            this.LectNamtxtBox.TextChanged += new System.EventHandler(this.LectNamtxtBox_TextChanged);
            // 
            // lectKoltextBox5
            // 
            this.lectKoltextBox5.Location = new System.Drawing.Point(574, 61);
            this.lectKoltextBox5.Name = "lectKoltextBox5";
            this.lectKoltextBox5.Size = new System.Drawing.Size(100, 26);
            this.lectKoltextBox5.TabIndex = 21;
            this.lectKoltextBox5.TextChanged += new System.EventHandler(this.lectKoltextBox5_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 644);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1118, 32);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(453, 25);
            this.toolStripStatusLabel1.Text = "откройте файл или введите данные и создайте новый";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(140, 593);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(118, 34);
            this.SaveButton.TabIndex = 23;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.SaveButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloseButton_Click);
            // 
            // LectPatrtxtBox
            // 
            this.LectPatrtxtBox.Location = new System.Drawing.Point(842, 226);
            this.LectPatrtxtBox.Name = "LectPatrtxtBox";
            this.LectPatrtxtBox.Size = new System.Drawing.Size(199, 26);
            this.LectPatrtxtBox.TabIndex = 24;
            this.LectPatrtxtBox.TextChanged += new System.EventHandler(this.LectPatrtxtBox_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 676);
            this.Controls.Add(this.LectPatrtxtBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lectKoltextBox5);
            this.Controls.Add(this.LectNamtxtBox);
            this.Controls.Add(this.LectorSurtextBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.specgroupBox2);
            this.Controls.Add(this.semgroupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.controlBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.disciplinetxtBox);
            this.Controls.Add(this.kurstextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.semgroupBox1.ResumeLayout(false);
            this.semgroupBox1.PerformLayout();
            this.specgroupBox2.ResumeLayout(false);
            this.specgroupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox kurstextBox;
        private System.Windows.Forms.TextBox disciplinetxtBox;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox controlBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox semgroupBox1;
        private System.Windows.Forms.GroupBox specgroupBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox LectorSurtextBox3;
        private System.Windows.Forms.TextBox LectNamtxtBox;
        private System.Windows.Forms.TextBox lectKoltextBox5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox LectPatrtxtBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

