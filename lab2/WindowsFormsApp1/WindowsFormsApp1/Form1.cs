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

using System.Text.Json;

using System.IO;




namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        [Serializable]
        public class Uch_otdel {
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
            public  Uch_otdel(){
}
        }
        //с 99 строки сериал в json а потом десериализуюты


        Uch_otdel otdel = new Uch_otdel();
        string json;
        public Form1()
        {
            InitializeComponent();

 //           OpenButton.Click += button1_Click;
 //           SaveButton.Click += CloseButton_Click;
            openFileDialog1.Filter = "Json files(*.json)|*.json|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Json files(*.json)|*.json|All files(*.*)|*.*";
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
            LectPatrtxtBox.Text  = otdel_restored.otch;


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
            otdel.otch = LectPatrtxtBox.Text;
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
    }

}
