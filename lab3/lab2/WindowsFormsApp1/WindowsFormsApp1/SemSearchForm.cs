using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SemSearchForm : Form
    {
        [Serializable]
        public class Uch_otdel
        {
            public string nazva { get; set; }
            public int kurs { get; set; }
            public int sem { get; set; }
            public string spec { get; set; }

            public bool POIT { get; set; }
            public bool POIMBS { get; set; }
            public bool ISIT { get; set; }
            public bool DAIVY { get; set; }

            public int kol_Lect { get; set; }
            public int kol_Lab { get; set; }
            public string control { get; set; }
            public string familia { get; set; }
            public string name { get; set; }
            public string otch { get; set; }
            public Uch_otdel()
            {
            }
        }
        //с 99 строки сериал в json а потом десериализуюты


        Uch_otdel otdel = new Uch_otdel();

        public int familiaSearch;
        public SemSearchForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                familiaSearch = 1;
            }
            else
            {
                familiaSearch = 2;
            }
            Regex newReg = new Regex(familiaSearch.ToString());

            //string familiaSearch = LectorSurtextBox3.Text;
            string dirName = @"C:\data";                  //\\Users\\Artyom\\Documents\\учебные штуки\\2 курс\\2 семестр\\ооп\\мои работы\\lab2\\data
            //DirectoryInfo info = new DirectoryInfo("PATH_TO_DIRECTORY_HERE");
            if (Directory.Exists(dirName))
            {
                string[] files = Directory.GetFiles(dirName);
                //int value = files.Length;
                //string s = value.ToString;
                foreach (string s in files)
                {
                    string fileText = System.IO.File.ReadAllText(s);
                    string json = fileText;
                    Uch_otdel otdel_restored = JsonSerializer.Deserialize<Uch_otdel>(json);
                    string temp = otdel_restored.sem.ToString();
                    if (newReg.Match(temp).Success /*familiaSearch == otdel_restored.sem*/)
                    {
                        //richTextBox1.Text += s;
                        StringBuilder outputLine = new StringBuilder();
                        outputLine.AppendLine($"название предмета [ {otdel_restored.nazva} ]");
                        outputLine.AppendLine("курс :" + otdel_restored.kurs.ToString() + ";");
                        //outputLine.AppendLine(richTextBox1.Text + ":" + otdel_restored.AmountOfRooms.ToString() + ";");
                        outputLine.AppendLine("семестр: " + otdel_restored.sem + ";");
                        if (otdel_restored.POIT == true)
                        {
                            otdel_restored.spec = "ПОИТ";
                        }
                        if (otdel_restored.DAIVY == true)
                        {
                            otdel_restored.spec = "ДЭИВИ";
                        }
                        if (otdel_restored.POIMBS == true)
                        {
                            otdel_restored.spec = "ПОИМБС";
                        }
                        if (otdel_restored.ISIT == true)
                        {
                            otdel_restored.spec = "ИСИТ";
                        }
                        outputLine.AppendLine("специальность: " + otdel_restored.spec + ";");
                        outputLine.AppendLine("кол-во лекций: " + otdel_restored.kol_Lect + ";");
                        outputLine.AppendLine("кол-во лаб: " + otdel_restored.kol_Lab + ";");
                        outputLine.AppendLine("вид контроля: " + otdel_restored.control + ";");
                        outputLine.AppendLine("лектор: " + otdel_restored.familia + " " + otdel_restored.name + " " + otdel_restored.otch + ";");
                        outputLine.AppendLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");



                        richTextBox1.Text += outputLine.ToString();

                    }

                }
            }
        }

        private void semgroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SemSearchForm_Load(object sender, EventArgs e)
        {

        }
    }
}
