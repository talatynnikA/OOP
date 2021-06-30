using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Text.Json;

using System.IO;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        [Serializable]
        public class Uch_otdel {
            public string nazva { get; set; }
            [Required(ErrorMessage = "Отсутствует название предмета")]
            public int kurs { get; set; }
            [Required(ErrorMessage = "Отсутствует курс")]
            public int sem { get; set; }
            [Required(ErrorMessage = "Отсутствует семестр")]
            public string spec { get; set; }
            [Required(ErrorMessage = "Отсутствует специальность")]

            public bool POIT { get; set; }
            public bool POIMBS { get; set; }
            public bool ISIT { get; set; }
            public bool DAIVY { get; set; }

            public int kol_Lect { get; set; }
            [Required(ErrorMessage = "Отсутствует количество лекций")]
            public int kol_Lab { get; set; }
            [Required(ErrorMessage = "Отсутствует количество лабораторных")]
            public string control { get; set; }
            [Required(ErrorMessage = "Отсутвует вид контроля")]
            public string familia { get; set; }
            [Required(ErrorMessage = "Отсутствует фамилия")]
            public string name { get; set; }
            [Required(ErrorMessage = "Отсутствует имя")]
            public string Otch { get; set; }

            public  Uch_otdel(){
}
        }
        //с 99 строки сериал в json а потом десериализуюты

        IOrderedEnumerable<Uch_otdel> _result;
        Uch_otdel otdel = new Uch_otdel();
        string json;
        public Form1()
        {
            InitializeComponent();

 //           OpenButton.Click += button1_Click;
 //           SaveButton.Click += CloseButton_Click;
            openFileDialog1.Filter = "Json files(*.json)|*.json|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Json files(*.json)|*.json|All files(*.*)|*.*";

            //оПрограммеToolStripMenuItem.Click += оПрограммеToolStripMenuItem_Click;
            //toolStripMenuItem1.DropDownItems.Add(Form2_Load);
            //ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");

            //fileItem.DropDownItems.Add("Создать");
            //fileItem.DropDownItems.Add(new ToolStripMenuItem("Сохранить"));

            //menuStrip1.Items.Add(fileItem);

            //ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");
            //aboutItem.Click += aboutItem_Click;
            //menuStrip1.Items.Add(aboutItem);
        }


        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form2.Show();
            //MessageBox.Show("произошло нажатие");
            Form ifrm = new Form2();
            ifrm.Show(); // отображаем Form2
            this.Hide(); // скрываем Form1 (this - текущая форма)
        }

        private void информацияToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("произошло нажатие");

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                otdel.sem = 1;
            }
            else 
            {
                otdel.sem = 2;
            }
 
            //textBox1.Text = rbText;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is opening file";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            json = fileText;
            MessageBox.Show("Файл открыт");

            Uch_otdel otdel_restored = JsonSerializer.Deserialize<Uch_otdel>(json);
            disciplinetxtBox.Text = otdel_restored.nazva;
            kurstextBox.Text = otdel_restored.kurs.ToString();
            if (radioButton1.Checked == true)
            {
                radioButton1.Checked = false;
            }
            else if(radioButton2.Checked == true)
            {
                radioButton2.Checked = false;

                otdel.sem = 2;
            }

            if(otdel_restored.sem == 1)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }

            if (otdel_restored.POIT  == true)
            {
                checkBox1.Checked = true;
            }
            if (otdel_restored.DAIVY  == true)
            {
                checkBox2.Checked = true;
            }
            if (otdel_restored.POIMBS  == true)
            {
                checkBox3.Checked = true;
            }
            if (otdel_restored.ISIT  == true)
            {
                checkBox4.Checked = true;
            }

            lectKoltextBox5.Text = otdel_restored.kol_Lect.ToString();
            try
            {
                trackBar1.Value = otdel_restored.kol_Lab;
            }
            catch
            {
                trackBar1.Value = 1;
            }

            controlBox1.Text  = otdel_restored.control;

            LectorSurtextBox3.Text  = otdel_restored.familia;
            LectNamtxtBox.Text  = otdel_restored.name;
            LectPatrtxtBox.Text  = otdel_restored.Otch;


        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            otdel.kol_Lab = trackBar1.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is saving file";

            if (disciplinetxtBox.Text == "")
                {
                    toolStripStatusLabel1.Text = "ошибка в поле Дисциплина";
                    return;


                }
                else if (kurstextBox.Text == "")
                {
                    toolStripStatusLabel1.Text = "ошибка в поле курс";
                    return;


                }
                else if (lectKoltextBox5.Text == "")
                {
                    toolStripStatusLabel1.Text = "ошибка в поле количество лекций";
                    return;


                }
                else if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    toolStripStatusLabel1.Text = "неправильно выбран семестр";
                    return;


                }
                else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false)
                {
                    toolStripStatusLabel1.Text = "выберите специальность";
                    return;


                }
                else if (trackBar1.Value == 0)
                {
                    toolStripStatusLabel1.Text = "выберите количество лабораторных";
                    return;


                }
                else if (controlBox1.Text == "")
                {
                    toolStripStatusLabel1.Text = "выберите вариант контроля";
                    return;


                }
                else if (LectorSurtextBox3.Text == "")
                {
                    toolStripStatusLabel1.Text = "не указана фамилия преподавателя";
                    return;


                }
                else if (LectNamtxtBox.Text == "")
                {
                    toolStripStatusLabel1.Text = "не указано имя преподавателя";
                    return;


                }
                else if (LectPatrtxtBox.Text == "")
                {
                    toolStripStatusLabel1.Text = "не указано отчество преподавателя";
                    return;


                }
            //else
            //{
            //    toolStripStatusLabel1.Text = "файл сохранен";
            //    return;

            //}





            json = JsonSerializer.Serialize<Uch_otdel>(otdel);
            //MessageBox.Show(json);
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;

            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, json);
            MessageBox.Show("Файл сохранен");
            toolStripStatusLabel1.Text = "";
            return;
        }

        private void disciplinetxtBox_TextChanged(object sender, EventArgs e)
        {
            otdel.nazva = disciplinetxtBox.Text;
        }

        private void kurstextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                otdel.kurs = int.Parse(kurstextBox.Text);
                if(otdel.kurs >4 )
                {
                    kurstextBox.Text = "";
                    toolStripStatusLabel1.Text = "ошибка. Курс может быть от 1 до 4";
                }
                else if(otdel.kurs <1)
                {
                    kurstextBox.Text = "";
                    toolStripStatusLabel1.Text = "ошибка. Курс не может быть 0 или отрицательным";

                }
            }
            catch
            {
                kurstextBox.Text = "";
                toolStripStatusLabel1.Text = "ошибка. в поле Курс требуется число типа int";
            }
        }

        private void specgroupBox2_Enter(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                otdel.POIT = true;
            }
            if (checkBox2.Checked == true)
            {
                otdel.DAIVY = true;
            }
            if (checkBox3.Checked == true)
            {
                otdel.POIMBS = true;
            }
            if (checkBox4.Checked == true)
            {
                otdel.ISIT = true;
            }



        }

        private void lectKoltextBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                otdel.kol_Lect = int.Parse(lectKoltextBox5.Text);

                if (otdel.kol_Lect > 50)
                {
                    lectKoltextBox5.Text = "";
                    toolStripStatusLabel1.Text = "ошибка. Кол-во лекций не может быть > 50";
                }
                else if (otdel.kol_Lect < 1)
                {
                    lectKoltextBox5.Text = "";
                    toolStripStatusLabel1.Text = "ошибка. Кол-во лекций не может быть 0 или отрицательным";

                }
            }
            catch
            {
                lectKoltextBox5.Text = "";
                toolStripStatusLabel1.Text = "ошибка. в поле Кол-во лекций требуется число типа int";
            }

        }

        private void controlBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                otdel.control = controlBox1.Text;
                //if (controlBox1.Text != "Экзамен" || controlBox1.Text != "Зачет")
                //{
                //    toolStripStatusLabel1.Text = "ошибка. проверьте поле Вид контроля";
                //}
                
            }
            catch
            {
                toolStripStatusLabel1.Text = "ошибка. проверьте поле Вид контроля";
            }
        }

        private void LectorSurtextBox3_TextChanged(object sender, EventArgs e)
        {
            otdel.familia = LectorSurtextBox3.Text;
        }

        private void LectNamtxtBox_TextChanged(object sender, EventArgs e)
        {
            otdel.name = LectNamtxtBox.Text;
        }

        private void LectPatrtxtBox_TextChanged(object sender, EventArgs e)
        {
            otdel.Otch = LectPatrtxtBox.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "откройте файл или введите данные и создайте новый";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "show info about labs";

            Form ifrm = new Form2();
            ifrm.Show(); // отображаем Form2

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is saving sort";

            if (_result == null)
            {

                MessageBox.Show("Выполните сортировку перед сохранением", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //   json = JsonSerializer.Serialize<Uch_otdel>(_result);
                //MessageBox.Show(json);
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;

                // сохраняем текст в файл
                //System.IO.File.WriteAllText(filename, json);
                //string[] jsona = new string[_result.Count()];
                System.IO.File.WriteAllText(filename, "");

                foreach (var item in _result)
                {
                    json = JsonSerializer.Serialize<Uch_otdel>(item);
                    System.IO.File.AppendAllText(filename, json + "\n");
                }
                MessageBox.Show("Файл сохранен");
                toolStripStatusLabel1.Text = "";
                return;
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is opening search form";

            Form ifrm1 = new lectorSearchForm();
            ifrm1.Show(); // отображаем Form2

        }

        private void семеструToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is opening search form";

            Form ifrm2 = new SemSearchForm();
            ifrm2.Show(); // отображаем Form2

        }

        private void курсуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is opening search form";

            Form ifrm3 = new KursSearchForm();
            ifrm3.Show(); // отображаем Form2

        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }

        public void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void количествуЛекцийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is sort by kol. lect.";

            List<Uch_otdel> Otdel = new List<Uch_otdel>();
            //string temp = "";
            string dirName = @"C:\data";                  //\\Users\\Artyom\\Documents\\учебные штуки\\2 курс\\2 семестр\\ооп\\мои работы\\lab2\\data
            string[] files = Directory.GetFiles(dirName);
            foreach (string s in files)
            {
                string fileText = System.IO.File.ReadAllText(s);
                string json = fileText;
                Uch_otdel otdel_restored = JsonSerializer.Deserialize<Uch_otdel>(json);
                Otdel.Add(otdel_restored);

            }
            
            if (Otdel.Count < 1)
                MessageBox.Show($"Вы не сохранили ни одного файла");
            else
            {
                //List<Uch_otdel> sortedLect = (List<Uch_otdel>)Otdel.OrderBy(otdel_restored => otdel_restored.kol_Lect);//from item in Otdel

                var result = from user in Otdel
                             orderby user.kol_Lect
                             select user;
                _result = result;

                foreach (var item in result)
                {

                    //orderby item.kol_Lect
                    //select item;
                    //richTextBox1.Text = string.Empty;
                    //countSortedLects = 0;
                   
                        StringBuilder outputLine = new StringBuilder();

                        outputLine.AppendLine($"название предмета [ {item.nazva.ToString()} ]");
                    outputLine.AppendLine("курс :" + item.kurs.ToString() + ";");
                    //outputLine.AppendLine(richTextBox1.Text + ":" + otdel_restored.AmountOfRooms.ToString() + ";");
                    outputLine.AppendLine("семестр: " + item.sem + ";");
                    if (item.POIT == true)
                    {
                        item.spec = "ПОИТ";
                    }
                    if (item.DAIVY == true)
                    {
                        item.spec = "ДЭИВИ";
                    }
                    if (item.POIMBS == true)
                    {
                        item.spec = "ПОИМБС";
                    }
                    if (item.ISIT == true)
                    {
                        item.spec = "ИСИТ";
                    }
                    outputLine.AppendLine("специальность: " + item.spec + ";");
                    outputLine.AppendLine("кол-во лекций: " + item.kol_Lect + ";");
                    outputLine.AppendLine("кол-во лаб: " + item.kol_Lab + ";");
                    outputLine.AppendLine("вид контроля: " + item.control + ";");
                    outputLine.AppendLine("лектор: " + item.familia + " " + item.name + " " + item.Otch + ";");
                    outputLine.AppendLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");



                    richTextBox1.Text += outputLine.ToString();
                    if (richTextBox1.Text != "")
                    {
                        kolvoFiles.Text = files.Length.ToString();
                    }


                    //printSortedInfo(item);




                }
                //Enumerable<Uch_otdel> sortedLect = Otdel.OrderBy(otdel_restored => otdel_restored.kol_Lect);//from item in Otdel
                //                 orderby item.kol_Lect
                //                 select item;
                //richTextBox1.Text = string.Empty;
                //countSortedLects = 0;
                //foreach (var item in sortedLect)
                //{

                //}
                //    //printSortedInfo(item);
            }
            toolStripStatusLabel1.Text = "Сортировка по кол-ву лекций завершена";

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Clearbutton2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            toolStripStatusLabel1.Text = "";
            kolvoFiles.Text = "";
        }

        private void видуКонтроляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is sort by control type";

            List<Uch_otdel> Otdel = new List<Uch_otdel>();
            //string temp = "";
            string dirName = @"C:\data";                  //\\Users\\Artyom\\Documents\\учебные штуки\\2 курс\\2 семестр\\ооп\\мои работы\\lab2\\data
            string[] files = Directory.GetFiles(dirName);
            foreach (string s in files)
            {
                string fileText = System.IO.File.ReadAllText(s);
                string json = fileText;
                Uch_otdel otdel_restored = JsonSerializer.Deserialize<Uch_otdel>(json);
                Otdel.Add(otdel_restored);

            }

            if (Otdel.Count < 1)
                MessageBox.Show($"Вы не сохранили ни одного файла");
            else
            {
                //List<Uch_otdel> sortedLect = (List<Uch_otdel>)Otdel.OrderBy(otdel_restored => otdel_restored.kol_Lect);//from item in Otdel

                var result = from user in Otdel
                             orderby user.control
                             select user;
                _result = result;

                foreach (var item in result)
                {

                    //orderby item.kol_Lect
                    //select item;
                    //richTextBox1.Text = string.Empty;
                    //countSortedLects = 0;

                    StringBuilder outputLine = new StringBuilder();

                    outputLine.AppendLine($"название предмета [ {item.nazva.ToString()} ]");
                    outputLine.AppendLine("курс :" + item.kurs.ToString() + ";");
                    //outputLine.AppendLine(richTextBox1.Text + ":" + otdel_restored.AmountOfRooms.ToString() + ";");
                    outputLine.AppendLine("семестр: " + item.sem + ";");
                    if (item.POIT == true)
                    {
                        item.spec = "ПОИТ";
                    }
                    if (item.DAIVY == true)
                    {
                        item.spec = "ДЭИВИ";
                    }
                    if (item.POIMBS == true)
                    {
                        item.spec = "ПОИМБС";
                    }
                    if (item.ISIT == true)
                    {
                        item.spec = "ИСИТ";
                    }
                    outputLine.AppendLine("специальность: " + item.spec + ";");
                    outputLine.AppendLine("кол-во лекций: " + item.kol_Lect + ";");
                    outputLine.AppendLine("кол-во лаб: " + item.kol_Lab + ";");
                    outputLine.AppendLine("вид контроля: " + item.control + ";");
                    outputLine.AppendLine("лектор: " + item.familia + " " + item.name + " " + item.Otch + ";");
                    outputLine.AppendLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");



                    richTextBox1.Text += outputLine.ToString();
                    if (richTextBox1.Text != "")
                    {
                        kolvoFiles.Text = files.Length.ToString();
                    }



                    //printSortedInfo(item);




                }
                //Enumerable<Uch_otdel> sortedLect = Otdel.OrderBy(otdel_restored => otdel_restored.kol_Lect);//from item in Otdel
                //                 orderby item.kol_Lect
                //                 select item;
                //richTextBox1.Text = string.Empty;
                //countSortedLects = 0;
                //foreach (var item in sortedLect)
                //{

                //}
                //    //printSortedInfo(item);
            }
            toolStripStatusLabel1.Text = "Сортировка по виду контроля завершена";
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            toolStrip2.Visible = false;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            toolStrip2.Visible = true;
        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            Form ifrm1 = new lectorSearchForm();
            ifrm1.Show(); // отображаем Form2


        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is opening search form";

            Form ifrm1 = new lectorSearchForm();
            ifrm1.Show(); // отображаем Form2


        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is opening search form";

            Form ifrm2 = new SemSearchForm();
            ifrm2.Show(); // отображаем Form2


        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is opening search form";

            Form ifrm3 = new KursSearchForm();
            ifrm3.Show(); // отображаем Form2

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is sort by kol. lect.";

            List<Uch_otdel> Otdel = new List<Uch_otdel>();
            //string temp = "";
            string dirName = @"C:\data";                  //\\Users\\Artyom\\Documents\\учебные штуки\\2 курс\\2 семестр\\ооп\\мои работы\\lab2\\data
            string[] files = Directory.GetFiles(dirName);
            foreach (string s in files)
            {
                string fileText = System.IO.File.ReadAllText(s);
                string json = fileText;
                Uch_otdel otdel_restored = JsonSerializer.Deserialize<Uch_otdel>(json);
                Otdel.Add(otdel_restored);

            }

            if (Otdel.Count < 1)
                MessageBox.Show($"Вы не сохранили ни одного файла");
            else
            {
                //List<Uch_otdel> sortedLect = (List<Uch_otdel>)Otdel.OrderBy(otdel_restored => otdel_restored.kol_Lect);//from item in Otdel

                var result = from user in Otdel
                             orderby user.kol_Lect
                             select user;
                _result = result;

                foreach (var item in result)
                {

                    //orderby item.kol_Lect
                    //select item;
                    //richTextBox1.Text = string.Empty;
                    //countSortedLects = 0;

                    StringBuilder outputLine = new StringBuilder();

                    outputLine.AppendLine($"название предмета [ {item.nazva.ToString()} ]");
                    outputLine.AppendLine("курс :" + item.kurs.ToString() + ";");
                    //outputLine.AppendLine(richTextBox1.Text + ":" + otdel_restored.AmountOfRooms.ToString() + ";");
                    outputLine.AppendLine("семестр: " + item.sem + ";");
                    if (item.POIT == true)
                    {
                        item.spec = "ПОИТ";
                    }
                    if (item.DAIVY == true)
                    {
                        item.spec = "ДЭИВИ";
                    }
                    if (item.POIMBS == true)
                    {
                        item.spec = "ПОИМБС";
                    }
                    if (item.ISIT == true)
                    {
                        item.spec = "ИСИТ";
                    }
                    outputLine.AppendLine("специальность: " + item.spec + ";");
                    outputLine.AppendLine("кол-во лекций: " + item.kol_Lect + ";");
                    outputLine.AppendLine("кол-во лаб: " + item.kol_Lab + ";");
                    outputLine.AppendLine("вид контроля: " + item.control + ";");
                    outputLine.AppendLine("лектор: " + item.familia + " " + item.name + " " + item.Otch + ";");
                    outputLine.AppendLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");



                    richTextBox1.Text += outputLine.ToString();
                    if (richTextBox1.Text != "")
                    {
                        kolvoFiles.Text = files.Length.ToString();
                    }



                    //printSortedInfo(item);




                }
                //Enumerable<Uch_otdel> sortedLect = Otdel.OrderBy(otdel_restored => otdel_restored.kol_Lect);//from item in Otdel
                //                 orderby item.kol_Lect
                //                 select item;
                //richTextBox1.Text = string.Empty;
                //countSortedLects = 0;
                //foreach (var item in sortedLect)
                //{

                //}
                //    //printSortedInfo(item);
            }
            toolStripStatusLabel1.Text = "Сортировка по кол-ву лекций завершена";
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is sort by control type";

            List<Uch_otdel> Otdel = new List<Uch_otdel>();
            //string temp = "";
            string dirName = @"C:\data";                  //\\Users\\Artyom\\Documents\\учебные штуки\\2 курс\\2 семестр\\ооп\\мои работы\\lab2\\data
            string[] files = Directory.GetFiles(dirName);
            foreach (string s in files)
            {
                string fileText = System.IO.File.ReadAllText(s);
                string json = fileText;
                Uch_otdel otdel_restored = JsonSerializer.Deserialize<Uch_otdel>(json);
                Otdel.Add(otdel_restored);

            }

            if (Otdel.Count < 1)
                MessageBox.Show($"Вы не сохранили ни одного файла");
            else
            {
                //List<Uch_otdel> sortedLect = (List<Uch_otdel>)Otdel.OrderBy(otdel_restored => otdel_restored.kol_Lect);//from item in Otdel

                var result = from user in Otdel
                             orderby user.control
                             select user;
                _result = result;

                foreach (var item in result)
                {

                    //orderby item.kol_Lect
                    //select item;
                    //richTextBox1.Text = string.Empty;
                    //countSortedLects = 0;

                    StringBuilder outputLine = new StringBuilder();

                    outputLine.AppendLine($"название предмета [ {item.nazva.ToString()} ]");
                    outputLine.AppendLine("курс :" + item.kurs.ToString() + ";");
                    //outputLine.AppendLine(richTextBox1.Text + ":" + otdel_restored.AmountOfRooms.ToString() + ";");
                    outputLine.AppendLine("семестр: " + item.sem + ";");
                    if (item.POIT == true)
                    {
                        item.spec = "ПОИТ";
                    }
                    if (item.DAIVY == true)
                    {
                        item.spec = "ДЭИВИ";
                    }
                    if (item.POIMBS == true)
                    {
                        item.spec = "ПОИМБС";
                    }
                    if (item.ISIT == true)
                    {
                        item.spec = "ИСИТ";
                    }
                    outputLine.AppendLine("специальность: " + item.spec + ";");
                    outputLine.AppendLine("кол-во лекций: " + item.kol_Lect + ";");
                    outputLine.AppendLine("кол-во лаб: " + item.kol_Lab + ";");
                    outputLine.AppendLine("вид контроля: " + item.control + ";");
                    outputLine.AppendLine("лектор: " + item.familia + " " + item.name + " " + item.Otch + ";");
                    outputLine.AppendLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");



                    richTextBox1.Text += outputLine.ToString();
                    if (richTextBox1.Text != "")
                    {
                        kolvoFiles.Text = files.Length.ToString();
                    }



                    //printSortedInfo(item);




                }
                //Enumerable<Uch_otdel> sortedLect = Otdel.OrderBy(otdel_restored => otdel_restored.kol_Lect);//from item in Otdel
                //                 orderby item.kol_Lect
                //                 select item;
                //richTextBox1.Text = string.Empty;
                //countSortedLects = 0;
                //foreach (var item in sortedLect)
                //{

                //}
                //    //printSortedInfo(item);
            }
            toolStripStatusLabel1.Text = "Сортировка по виду контроля завершена";

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is saving sort";

            if (_result == null)
            {
                MessageBox.Show("Выполните сортировку перед сохранением", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //   json = JsonSerializer.Serialize<Uch_otdel>(_result);
                //MessageBox.Show(json);
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;

                // сохраняем текст в файл
                //System.IO.File.WriteAllText(filename, json);
                //string[] jsona = new string[_result.Count()];
                System.IO.File.WriteAllText(filename, "");

                foreach (var item in _result)
                {
                    json = JsonSerializer.Serialize<Uch_otdel>(item);
                    System.IO.File.AppendAllText(filename, json + "\n");
                }
                MessageBox.Show("Файл сохранен");
                toolStripStatusLabel1.Text = "";
                return;
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is show info about program";

            Form ifrm = new Form2();
            ifrm.Show(); // отображаем Form2


        }

        private void ochititPolya_Click(object sender, EventArgs e)
        {
            toolStripStatusLastAction.Text = "The last action is clear all ";

            disciplinetxtBox.Text = "";
            kurstextBox.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            lectKoltextBox5.Text = "";
            trackBar1.Value = 1;
            controlBox1.Text = "";
            LectorSurtextBox3.Text = "";
            LectNamtxtBox.Text = "";
            LectPatrtxtBox.Text = "";
            richTextBox1.Text = "";


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton4_Click(object sender, EventArgs e)
        {

        }

        private void Vpered_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            else if (radioButton2.Checked == true)
            {
                radioButton2.Checked = false;
                radioButton1.Checked = true;
            }

        }

        private void Navad_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton2.Checked = false;
                radioButton1.Checked = true;
            }
            else 
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

        }
    }

}
