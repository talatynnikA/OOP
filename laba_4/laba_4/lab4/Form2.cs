using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace lab2
{
    public partial class Form2 : Form
    {
        Form1 refForm1;
        int bit;

        public Form2(Form1 Form1)
        {
            refForm1 = Form1;
            InitializeComponent();
            label5.Text += " " + trackBar1.Value + " ГГц";
            label6.Text += " " + trackBar2.Value + " ГГц";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                bool flag = true;
                Regex regP = new Regex(@"[A-ZА-Я]");
                Regex regS = new Regex(@"\w{4}");
                Regex regM = new Regex(@"\w{2}");
                if (!regP.IsMatch(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "Неверный формат, строка должна содержать только заглавные буквы");
                    flag = false;
                }
                else
                    errorProvider1.SetError(textBox1, null);
                if (!regS.IsMatch(textBox2.Text))
                {
                    errorProvider2.SetError(textBox2, "Неверный формат, строка должна содержать минимум 4 символа");
                    flag = false;
                }
                else
                    errorProvider2.SetError(textBox2, null);
                if (!regM.IsMatch(textBox3.Text))
                {
                    errorProvider3.SetError(textBox3, "Неверный формат, строка должна содержать минимум 2 символа");
                    flag = false;
                }
                else
                    errorProvider3.SetError(textBox3, null);
                if (flag)
                {
                    refForm1.processor.Producer = textBox1.Text;
                    refForm1.processor.Series = textBox2.Text;
                    refForm1.processor.Model = textBox3.Text;
                    refForm1.processor.CountOfCores = (int)numericUpDown1.Value;
                    refForm1.processor.Frequency = trackBar1.Value;
                    refForm1.processor.MaxFrequency = trackBar2.Value;
                    if (radioButton1.Checked) bit = int.Parse(radioButton1.Text);
                    else bit = int.Parse(radioButton2.Text);
                    refForm1.processor.BitArchitecture = bit;
                    refForm1.processor.Cache1 = (int)numericUpDown2.Value;
                    refForm1.processor.Cache2 = (int)numericUpDown3.Value;
                    refForm1.processor.Cache3 = (int)numericUpDown4.Value;

                    Close();
                    refForm1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = "Частота: " + trackBar1.Value + " ГГц";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label6.Text = "Максимальная частота: " + trackBar2.Value + " ГГц";
        }
    }
}
