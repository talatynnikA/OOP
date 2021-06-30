using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Comp comp = new Comp();
        public Processor processor = new Processor();
        public GraphicCard graphicCard = new GraphicCard();
        public List<Comp> computers = new List<Comp>();
        public List<Comp> search = new List<Comp>();
        public List<Comp> sortProc = new List<Comp>();
        public List<Comp> sortOZY = new List<Comp>();

        public Form1()
        {
            InitializeComponent();

            this.FontHeight = Singleton.GetInstance().config.FontSize;
            this.Font = Singleton.GetInstance().config.FontType;
            this.FontHeight = Singleton.GetInstance().config.FontSize;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(@"C:\Users\Artyom\Documents\учебные штуки\2 курс\2 семестр\ооп\мои работы\laba_5\lab5\server.jpg");

            comboBox1.Items.AddRange(Comp.listOZY);
            comboBox2.Items.AddRange(Comp.listHD);
            label5.Text += " " + trackBar1.Value + " ГБ";
            label7.Text += " " + trackBar2.Value + " ТБ";
            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox2.Text = comboBox2.Items[0].ToString();
            comp.TypeComp = radioButton1.Text;
            comp.SizeOZY = trackBar1.Value;
            comp.SizeHD = trackBar2.Value;
            comp.TypeOZY = comboBox1.Text;
            comp.TypeHD = comboBox2.Text;
            comp.PDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            timer1.Start();
        }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {            
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
                comp.TypeComp = radioButton.Text;            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
                comp.TypeComp = radioButton.Text;
            pictureBox1.Image = Image.FromFile(@"C:\Users\Artyom\Documents\учебные штуки\2 курс\2 семестр\ооп\мои работы\laba_5\lab5\station.jpg");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
                comp.TypeComp = radioButton.Text;
            pictureBox1.Image = Image.FromFile(@"C:\Users\Artyom\Documents\учебные штуки\2 курс\2 семестр\ооп\мои работы\laba_5\lab5\leptop.jpg");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label5.Text = "Размер ОЗУ: " + trackBar1.Value + " ГБ";
            comp.SizeOZY = trackBar1.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            comp.TypeOZY = comboBox.Text;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label7.Text = "Размер жесткого диска: " + trackBar2.Value + " ТБ";
            comp.SizeHD = trackBar2.Value;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            comp.TypeHD = comboBox.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 proc = new Form2(this);
                proc.ShowDialog();
                comp.Processor = processor;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 gc = new Form3(this);
                gc.ShowDialog();
                comp.GraphicCard = graphicCard;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = comp.ShowAllInformation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nНеправильно введена информация!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                computers.Add(comp);
                XmlSerializer formatter = new XmlSerializer(typeof(List<Comp>));
                using (FileStream fs = new FileStream("computers.xml", FileMode.Create))
                {
                    formatter.Serialize(fs, computers);
                }
                richTextBox1.Text = "";
                comp = new Comp();
                label5.Text = "Размер: " + trackBar1.Value + " Гб";
                label7.Text = "Размер: " + trackBar2.Value + " Тб";
                comboBox1.Text = comboBox1.Items[0].ToString();
                comboBox2.Text = comboBox2.Items[0].ToString();
                comp.TypeComp = radioButton1.Text;
                comp.SizeOZY = trackBar1.Value;
                comp.SizeHD = trackBar2.Value;
                comp.TypeOZY = comboBox1.Text;
                comp.TypeHD = comboBox2.Text;
                comp.PDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nОшибка сериализации!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Comp>));
                using (FileStream fs = new FileStream("computers.xml", FileMode.OpenOrCreate))
                {
                    computers = (List<Comp>)formatter.Deserialize(fs);
                }
                richTextBox1.Text = "";
                foreach (var comp in computers)
                    richTextBox1.Text += comp.ShowAllInformation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nОшибка десериализации!");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            comp.PDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
        }        

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 formfour = new Form4(this);
            formfour.ShowDialog();
            if (formfour.result != null)
            {
                search = formfour.result;
            }
        }

        private void поЧастотеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortProc.Clear();
            richTextBox1.Text = "";
            var result = computers
                .OrderBy(p => p.Processor.Frequency)
                .Select(p => p);
            int i = 1;
            foreach (Comp comp in result)
            {
                richTextBox1.Text += i + ") ";
                sortProc.Add(comp);
                richTextBox1.Text += comp.ShowShortInfo();
                i++;
            }
        }

        private void поРазмеруОЗУToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortOZY.Clear();
            richTextBox1.Text = "";
            var result = computers
                .OrderBy(p => p.SizeOZY)
                .Select(p => p);
            int i = 1;
            foreach (Comp comp in result)
            {
                richTextBox1.Text += i + ") ";
                sortOZY.Add(comp);
                richTextBox1.Text += comp.ShowShortInfo();
                i++;
            }
        }

        private void результатПоискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (search.Count == 0)
                {
                    throw new Exception("Возможно, результатов поиска не обнаружено!");
                }
                else
                {
                    using (FileStream fs = new FileStream("search.xml", FileMode.Create))
                    {
                        XmlSerializer formatter = new XmlSerializer(typeof(List<Comp>));
                        formatter.Serialize(fs, search);
                    }
                    MessageBox.Show("Результаты поиска сохранены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nОшибка сериализации!");
            }
        }

        private void результатСортировокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (sortProc.Count != 0)
                {
                    using (FileStream fs = new FileStream("sortProc.xml", FileMode.Create))
                    {
                        XmlSerializer formatter = new XmlSerializer(typeof(List<Comp>));
                        formatter.Serialize(fs, sortProc);
                    }
                }
                else
                {
                    throw new Exception("Возможно, результатов сортировки по частоте процессора не обнаружено!");
                }
                if (sortOZY.Count != 0)
                {
                    using (FileStream fs = new FileStream("sortOZY.xml", FileMode.Create))
                    {
                        XmlSerializer formatter = new XmlSerializer(typeof(List<Comp>));
                        formatter.Serialize(fs, sortOZY);
                    }
                }
                else
                {
                    throw new Exception("Возможно, результатов сортировки по объему ОЗУ не обнаружено!");
                }
                MessageBox.Show("Результаты сортировки сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nОшибка сериализации!");
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия: 2.0 \nРазработчик: Талатынник Артём", "О программе");
        }
        
        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Вывод текущего объекта";
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Очистить окно вывода";
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Сохранить текущий объект"; 
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Вывод информации из файла";
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ввод информации о процессоре";
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Ввод информации о видеокарте";
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Форма для ввода информации";
        }

        private void поискToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Поиск по устройствам";
        }

        private void сортировкаToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Поиск по частоте работы процессора и по размеру ОЗУ";
        }

        private void сохранитьToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Сохранить результат поиска и сортировок";
        }

        private void оПрограммеToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Информация о программе";
        }        

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToLongDateString() + " "+ DateTime.Now.ToLongTimeString();
        }

        public IFactory GetFactory()
        {         
            if (radioButton1.Checked) { return new ServerFactory(); }
            else if (radioButton2.Checked) { return new WorkStationFactory(); }
            else return new LaptopFactory();           
        }
    }
}
