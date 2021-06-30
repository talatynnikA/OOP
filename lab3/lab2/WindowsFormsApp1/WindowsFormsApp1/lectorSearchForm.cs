using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static WindowsFormsApp1.lectorSearchForm.Uch_otdel;

namespace WindowsFormsApp1
{
    public partial class lectorSearchForm : Form
    {

        [Serializable]
        public class Uch_otdel
        {
            
            public string nazva { get; set; }
            [Required(ErrorMessage = "Отсутствует название")]
            public int kurs { get; set; }
            [Required(ErrorMessage = "Отсутствует курс")]
            public int sem { get; set; }
            public string spec { get; set; }
            [Required(ErrorMessage = "Не указана специальность")]

            public bool POIT { get; set; }
            public bool POIMBS { get; set; }
            public bool ISIT { get; set; }
            public bool DAIVY { get; set; }

            public int kol_Lect { get; set; }
            [Required(ErrorMessage = "Отсутствует количество лекций")]
            public int kol_Lab { get; set; }
            public string control { get; set; }
            //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Отсутвует ID")]
            [RegularExpression(@"^[А-Я][[а-я]+$", ErrorMessage = "Неверный формат")]

            [familia]
            public string familia { get; set; }
            public string name { get; set; }
            public string otch { get; set; }
            public Uch_otdel()
            {
            }

            //[System.ComponentModel.Browsable(false)]
            //public bool IsValid { get; }

            //свой атрибут валидации
            public class familiaAttribute : Attribute
            {
                static Regex regex = new Regex(@"^[А-Я][[а-я]+$");
                public bool IsValid(object value, string ErrorMessage)
                {
                    string familia = value as string;
                    if (string.IsNullOrEmpty(familia))
                    {
                        ErrorMessage = "Отсутствует фамилия";
                        return false;
                    }

                    if (!regex.IsMatch(familia))
                    {
                        ErrorMessage = "Неверный формат";
                        return false;
                    }
                    else return true;
                }
                // public familiaAttribute() { }
            }

        }




        //private class UserNameAttribute : ValidationAttribute
        //{
        //    public override bool IsValid(object value)
        //    {
        //        if (value != null)
        //        {
        //            string userName = value.ToString();
        //            if (!userName.StartsWith(int.TryParse(LectorSurtextBox3.Text, out int number)))
        //                return true;
        //            else
        //                this.ErrorMessage = "Имя не должно начинаться с буквы T";
        //        }
        //        return false;
        //    }
        //}

        public lectorSearchForm()
        {
            InitializeComponent();
        }

        private void LectorSurtextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        string[] files;
        private void CommitButton_Click(object sender, EventArgs e)
        {

            if (LectorSurtextBox3.Text == "")
            {
                string ErrorMessage = "Отсутствует фамилия";
                string strWithError = ErrorMessage;
                MessageBox.Show(strWithError);
                return;
            }
            Regex newReg = new Regex(LectorSurtextBox3.Text);//  @"[A-ZА-Я]"

            string familiaSearch = LectorSurtextBox3.Text;
            Uch_otdel valid = new Uch_otdel();
            valid.familia = LectorSurtextBox3.Text;
            var results = new List<ValidationResult>();
            var context = new ValidationContext(valid);//применение
            if (!Validator.TryValidateObject(valid, context, results, true))
            {
                foreach (var error in results)
                {
                    string strWithError = error.ErrorMessage;
                    MessageBox.Show(strWithError);
                }
                return;
            }
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


                    if (newReg.Match(temp).Success    /*familiaSearch ==  otdel_restored.familia*/)
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

        private void lectorSearchForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            currentDate.Text = "Date and time: " + DateTime.Now.ToString();

        }

        private void vyvodAll_Click(object sender, EventArgs e)
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
