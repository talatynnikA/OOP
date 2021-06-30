
namespace WindowsFormsApp1
{
    partial class KursSearchForm
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
            this.selectCourse = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CommitButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Clearbutton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.kolvoFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.VyvodAll = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectCourse
            // 
            this.selectCourse.AllowDrop = true;
            this.selectCourse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.selectCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectCourse.FormattingEnabled = true;
            this.selectCourse.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.selectCourse.Location = new System.Drawing.Point(79, 46);
            this.selectCourse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectCourse.Name = "selectCourse";
            this.selectCourse.Size = new System.Drawing.Size(108, 24);
            this.selectCourse.TabIndex = 9;
            this.selectCourse.SelectedIndexChanged += new System.EventHandler(this.controlBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(44, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Выберите курс";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // CommitButton
            // 
            this.CommitButton.Location = new System.Drawing.Point(79, 121);
            this.CommitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(132, 27);
            this.CommitButton.TabIndex = 31;
            this.CommitButton.Text = "Подтвердить";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(313, 30);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(347, 275);
            this.richTextBox1.TabIndex = 34;
            this.richTextBox1.Text = "";
            // 
            // Clearbutton
            // 
            this.Clearbutton.Location = new System.Drawing.Point(79, 181);
            this.Clearbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Clearbutton.Name = "Clearbutton";
            this.Clearbutton.Size = new System.Drawing.Size(132, 31);
            this.Clearbutton.TabIndex = 35;
            this.Clearbutton.Text = "Очистить";
            this.Clearbutton.UseVisualStyleBackColor = true;
            this.Clearbutton.Click += new System.EventHandler(this.Clearbutton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kolvoFiles,
            this.currentDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 305);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(688, 26);
            this.statusStrip1.TabIndex = 39;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // kolvoFiles
            // 
            this.kolvoFiles.Name = "kolvoFiles";
            this.kolvoFiles.Size = new System.Drawing.Size(114, 20);
            this.kolvoFiles.Text = "Кол-во файлов";
            // 
            // currentDate
            // 
            this.currentDate.Name = "currentDate";
            this.currentDate.Size = new System.Drawing.Size(87, 20);
            this.currentDate.Text = "currentDate";
            this.currentDate.Click += new System.EventHandler(this.currentDate_Click);
            // 
            // VyvodAll
            // 
            this.VyvodAll.Location = new System.Drawing.Point(79, 236);
            this.VyvodAll.Name = "VyvodAll";
            this.VyvodAll.Size = new System.Drawing.Size(132, 34);
            this.VyvodAll.TabIndex = 40;
            this.VyvodAll.Text = "Вывести все";
            this.VyvodAll.UseVisualStyleBackColor = true;
            this.VyvodAll.Click += new System.EventHandler(this.VyvodAll_Click);
            // 
            // KursSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 331);
            this.Controls.Add(this.VyvodAll);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Clearbutton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectCourse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KursSearchForm";
            this.Text = "KursSearchForm";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox selectCourse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Clearbutton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel kolvoFiles;
        private System.Windows.Forms.ToolStripStatusLabel currentDate;
        private System.Windows.Forms.Button VyvodAll;
    }
}