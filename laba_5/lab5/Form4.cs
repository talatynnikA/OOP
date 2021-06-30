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
    public partial class Form4 : Form
    {
        public List<Comp> result = new List<Comp>();
        public Form1 data;
        public string prod;
        public string model;
        public Form4(Form1 computers)
        {
            InitializeComponent();
            data = computers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox3.Checked)
            {
                prod = textBox1.Text;
                model = textBox2.Text;
                if (prod == "")
                    textBox1.BackColor = Color.Tomato;
                else
                    textBox1.BackColor = Color.White;
                if (model == "")
                    textBox2.BackColor = Color.Tomato;
                else
                {
                    textBox2.BackColor = Color.White;
                    Search(prod, model);
                }
            }
            else if (checkBox1.Checked)
            {
                textBox2.Text = "";
                prod = textBox1.Text;
                if (prod == "")
                    textBox1.BackColor = Color.Tomato;
                else
                {
                    textBox1.BackColor = Color.White;
                    Search(prod, null);
                }
            }
            else if (checkBox3.Checked)
            {
                textBox1.Text = "";
                model = textBox2.Text;
                if (model == "")
                    textBox2.BackColor = Color.Tomato;
                else
                {
                    textBox2.BackColor = Color.White;
                    Search(null, model);
                }
            }
            else
            {
                MessageBox.Show("Выберите категорию поиска!");
            }
        }

        private void Search(string prod, string model)
        {
            result.Clear();
            dataGridView1.Rows.Clear();
            if (prod == null)
            {
                char m = model[0];
                Regex regex = new Regex(@"" + m + @"\w*", RegexOptions.IgnoreCase);
                for (int i = 0; i < data.computers.Count(); i++)
                {
                    Match match = regex.Match(data.computers[i].Processor.Model);
                    if (match.Success)
                    {
                        result.Add(data.computers[i]);
                        Fill(data.computers[i]);
                    }
                }
            }
            else if (model == null)
            {
                char pr = prod[0];
                Regex regex = new Regex(@"" + pr + @"\w*", RegexOptions.IgnoreCase);
                for (int i = 0; i < data.computers.Count(); i++)
                {
                    Match match = regex.Match(data.computers[i].Processor.Producer);
                    if (match.Success)
                    {
                        result.Add(data.computers[i]);
                        Fill(data.computers[i]);
                    }
                }
            }
            else
            {
                char pr = prod[0];
                char m = model[0];
                Regex regexP = new Regex(@"" + pr + @"\w*", RegexOptions.IgnoreCase);
                Regex regexM = new Regex(@"" + m + @"\w*", RegexOptions.IgnoreCase);
                for (int i = 0; i < data.computers.Count(); i++)
                {
                    Match matchP = regexP.Match(data.computers[i].Processor.Producer);
                    Match matchM = regexM.Match(data.computers[i].Processor.Model);
                    if (matchP.Success && matchM.Success)
                    {
                        result.Add(data.computers[i]);
                        Fill(data.computers[i]);
                    }
                }
            }

        }

        private void Fill(Comp computer)
        {
            DataGridViewCell type = new DataGridViewTextBoxCell();
            DataGridViewCell prodProc = new DataGridViewTextBoxCell();
            DataGridViewCell modelProc = new DataGridViewTextBoxCell();
            DataGridViewCell freq = new DataGridViewTextBoxCell();
            DataGridViewCell cost = new DataGridViewTextBoxCell();

            type.Value = computer.TypeComp;
            prodProc.Value = computer.Processor.Producer;
            modelProc.Value = computer.Processor.Model;
            freq.Value = computer.Processor.Frequency;
            cost.Value = computer.Cost;

            DataGridViewRow row = new DataGridViewRow();
            row.Cells.AddRange(type, prodProc, modelProc, freq, cost);
            dataGridView1.Rows.Add(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            data.Show();
        }
    }
}
