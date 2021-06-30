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
    public partial class KursSearchForm : Form
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

        class JsonData
        {
            public string User { get; }
            public int Steps { get; }
            public int Day { get; private set; }
            public void SetDay(int day) => Day = day;

            public JsonData(string user, int steps)
                => (User, Steps) = (user, steps);
        }

        public KursSearchForm()
        {
            InitializeComponent();
        }

        private void controlBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            //Uch_otdel otdel = new Uch_otdel();
            //string json;
            Regex newReg = new Regex(selectCourse.Text,
            RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);


            string familiaSearch = selectCourse.Text;
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
                    string temp = otdel_restored.kurs.ToString();
                    if (newReg.Match(temp).Success /*familiaSearch == otdel_restored.kurs.ToString()*/)
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
                        if (richTextBox1.Text != "")
                        {
                            kolvoFiles.Text = files.Length.ToString();
                        }


                    }

                }
            }
        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void currentDate_Click(object sender, EventArgs e)
        {
            currentDate.Text = "Date and time: " + DateTime.Now.ToString();

        }

        private void VyvodAll_Click(object sender, EventArgs e)
        {
            string dirName = @"C:\data";                  //\\Users\\Artyom\\Documents\\учебные штуки\\2 курс\\2 семестр\\ооп\\мои работы\\lab2\\data
            //DirectoryInfo info = new DirectoryInfo("PATH_TO_DIRECTORY_HERE");
            if (Directory.Exists(dirName))
            {
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    string fileText = System.IO.File.ReadAllText(s);
                    string json = fileText;
                    Uch_otdel otdel_restored = JsonSerializer.Deserialize<Uch_otdel>(json);
                    string temp = otdel_restored.familia;


                    if (1 == 1  /*familiaSearch ==  otdel_restored.familia*/)
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
                        if (richTextBox1.Text != "")
                        {
                            kolvoFiles.Text = files.Length.ToString();
                        }


                    }
                }
            }
        }
    }
}
