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
    public partial class Form3 : Form
    {
        Form1 refForm1;
        bool diret;

        public Form3(Form1 Form1)
        {                        
            refForm1 = Form1;
            InitializeComponent();
            label4.Text += " " + trackBar1.Value + " ГГц";
            label5.Text += " " + trackBar2.Value + " Гб";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = "Частота: " + trackBar1.Value + " ГГц";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label5.Text = "Объем памяти: " + trackBar2.Value + " Гб";
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
                    refForm1.graphicCard.Producer = textBox1.Text;
                    refForm1.graphicCard.Series = textBox2.Text;
                    refForm1.graphicCard.Model = textBox3.Text;
                    refForm1.graphicCard.Frequency = trackBar1.Value;
                    if (radioButton1.Checked) diret = true;
                    else diret = false;
                    refForm1.graphicCard.DiretX11 = diret;
                    refForm1.graphicCard.Memory = trackBar2.Value;

                    Close();
                    refForm1.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                
        }
    }
}
