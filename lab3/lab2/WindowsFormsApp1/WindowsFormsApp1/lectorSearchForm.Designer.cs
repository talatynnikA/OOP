
namespace WindowsFormsApp1
{
    partial class lectorSearchForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.LectorSurtextBox3 = new System.Windows.Forms.TextBox();
            this.CommitButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Clearbutton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.kolvoFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.vyvodAll = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(45, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Введите Фамилию лектора";
            // 
            // LectorSurtextBox3
            // 
            this.LectorSurtextBox3.Location = new System.Drawing.Point(50, 68);
            this.LectorSurtextBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LectorSurtextBox3.Name = "LectorSurtextBox3";
            this.LectorSurtextBox3.Size = new System.Drawing.Size(168, 22);
            this.LectorSurtextBox3.TabIndex = 20;
            this.LectorSurtextBox3.TextChanged += new System.EventHandler(this.LectorSurtextBox3_TextChanged);
            // 
            // CommitButton
            // 
            this.CommitButton.Location = new System.Drawing.Point(50, 118);
            this.CommitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(132, 27);
            this.CommitButton.TabIndex = 32;
            this.CommitButton.Text = "Подтвердить";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(311, 25);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(347, 275);
            this.richTextBox1.TabIndex = 33;
            this.richTextBox1.Text = "";
            // 
            // Clearbutton
            // 
            this.Clearbutton.Location = new System.Drawing.Point(50, 179);
            this.Clearbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Clearbutton.Name = "Clearbutton";
            this.Clearbutton.Size = new System.Drawing.Size(132, 31);
            this.Clearbutton.TabIndex = 36;
            this.Clearbutton.Text = "Очистить";
            this.Clearbutton.UseVisualStyleBackColor = true;
            this.Clearbutton.Click += new System.EventHandler(this.Clearbutton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(684, 25);
            this.toolStrip1.TabIndex = 37;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kolvoFiles,
            this.currentDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 306);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 26);
            this.statusStrip1.TabIndex = 38;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // kolvoFiles
            // 
            this.kolvoFiles.Name = "kolvoFiles";
            this.kolvoFiles.Size = new System.Drawing.Size(114, 20);
            this.kolvoFiles.Text = "Кол-во файлов";
            this.kolvoFiles.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // currentDate
            // 
            this.currentDate.Name = "currentDate";
            this.currentDate.Size = new System.Drawing.Size(87, 20);
            this.currentDate.Text = "currentDate";
            this.currentDate.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // vyvodAll
            // 
            this.vyvodAll.Location = new System.Drawing.Point(50, 239);
            this.vyvodAll.Name = "vyvodAll";
            this.vyvodAll.Size = new System.Drawing.Size(132, 33);
            this.vyvodAll.TabIndex = 39;
            this.vyvodAll.Text = "Вывести все записи";
            this.vyvodAll.UseVisualStyleBackColor = true;
            this.vyvodAll.Click += new System.EventHandler(this.vyvodAll_Click);
            // 
            // lectorSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 332);
            this.Controls.Add(this.vyvodAll);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Clearbutton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.LectorSurtextBox3);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "lectorSearchForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "lectorSearchForm";
            this.Load += new System.EventHandler(this.lectorSearchForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LectorSurtextBox3;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Clearbutton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel kolvoFiles;
        private System.Windows.Forms.ToolStripStatusLabel currentDate;
        private System.Windows.Forms.Button vyvodAll;
    }
}