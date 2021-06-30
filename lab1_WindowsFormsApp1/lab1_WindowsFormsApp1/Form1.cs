using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private float a,b;
        private int count;
        private bool znak = true;
        private object m;
        private string memory;

        private void calculate()
        {
            String str1 = textBox1.Text;

            if (str1.EndsWith("++") | str1.EndsWith("--") | str1.EndsWith("**") | str1.EndsWith("//"))
            {
                int lenght = textBox1.Text.Length - 1;
                string text = textBox1.Text;
                textBox1.Clear();
                for (int i = 0; i < lenght; i++)
                {
                    textBox1.Text = textBox1.Text + text[i];
                }
            };
            switch (count)
            {
                case 1:
                    if (str1.StartsWith("++"))
                    {
                        int lenght = textBox1.Text.Length - 1;
                        string text = textBox1.Text;
                        textBox1.Clear();
                        for (int i = 0; i < lenght; i++)
                        {
                            textBox1.Text = textBox1.Text + text[i];
                        }
                    };
                    b = a + float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 2:
                    b = a - float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 3:
                    b = a * float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 4:
                    float divider;
                    divider = float.Parse(textBox1.Text);
                    if (divider == 0.0)
                    {
                        MessageBox.Show("Внимание! Деление на ноль!");
                        textBox1.Text = "";
                    }
                    else
                    {
                        b = a / divider;
                        textBox1.Text = b.ToString();
                    }
                    //b = a / float.Parse(textBox1.Text);
                    //textBox1.Text = b.ToString();
                    break;

                default:
                    break;
            }

        }
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
                    
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }

        private void dotButton_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox1.Text + ",";
                
            }
            catch
            {
                textBox1.Text = "";
                label1.Text = "ошибка";
            }
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(textBox1.Text);
                textBox1.Clear();
            }
            catch
            {
                String str1 = label1.Text;

                if (str1.EndsWith("-"))                               
                {
                    textBox1.Text = "";                                                      
                }
                else
                {

                    a = 0;
                }

            }
            finally
            {

                count = 2;
                label1.Text = a.ToString() + "-";
                znak = true;
            }
        }

        private void ymnojButton_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(textBox1.Text);
                textBox1.Clear();
            }
            catch
            {
                String str1 = label1.Text;

                if (str1.EndsWith("*"))
                {
                    textBox1.Text = "";
                }
                else
                {

                    a = 0;
                }


            }
            finally
            {

                count = 3;
                label1.Text = a.ToString() + "*";
                znak = true;
            }
        }

        private void delenButton_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(textBox1.Text);
                textBox1.Clear();
            }
            catch
            {
                String str1 = label1.Text;

                if (str1.EndsWith("/"))
                {
                    textBox1.Text = "";
                }
                else
                {

                    a = 0;
                }


            }
            finally
            {
                count = 4;
                label1.Text = a.ToString() + "/";
                znak = true;
            }
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            try
            {
                calculate();
                label1.Text = "";
            }
            catch
            {
                label1.Text = "ошибка";

            }
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text = textBox1.Text + text[i];
            }
        }

        private void PlusMinusButton_Click(object sender, EventArgs e)
        {
            if (znak == true)
            {
                textBox1.Text = "-" + textBox1.Text;
                znak = false;
            }
            else if (znak == false)
            {
                textBox1.Text = textBox1.Text.Replace("-", "");
                znak = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = memory;
            }
            catch
            {
                textBox1.Text = "";
                label1.Text = "ошибка";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            memory = "";
        }
            catch
            {
                textBox1.Text = "";
                label1.Text = "ошибка";
            }

}

private void MPlusButton_Click(object sender, EventArgs e)
        {
            try { 
            memory = textBox1.Text;
            }
            catch
            {
                textBox1.Text = "";
                label1.Text = "ошибка";
            }


        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            try
            {
                a = float.Parse(textBox1.Text);
                textBox1.Clear();

            }
            catch
            {
                String str1 = label1.Text;

                if (str1.EndsWith("+"))                                
                {
                    textBox1.Text = "";                                                       
                }
                else
                {

                    a = 0;
                }
            }
            finally
            {
                count = 1;
                label1.Text = a.ToString() + "+";
                znak = true;
            }
            
        }
    }
}
