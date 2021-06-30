using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    [Serializable]
    public class Comp
    {
        public static string[] listOZY = new string[3]
        {
            "SIMM", "DDR2","DDR3"
        };
        public static string[] listHD = new string[2]
        {
            "HDD", "SSD"
        };
        public string TypeComp { get; set; }
        public Processor Processor { get; set; }
        public GraphicCard GraphicCard { get; set; }
        public int SizeOZY { get; set; }
        public string TypeOZY { get; set; }
        public int SizeHD { get; set; }
        public string TypeHD { get; set; }
        public string PDate { get; set; }
        public int Cost { get; set; }
        public Comp() { }
        public Comp(string type, Processor proc, GraphicCard gc, int sizeOZY, string typeOZY, int sizeHD, string typeHD, string date)
        {
            TypeComp = type;
            Processor = proc;
            GraphicCard = gc;
            SizeOZY = sizeOZY;
            TypeOZY = typeOZY;
            SizeHD = sizeHD;
            TypeHD = typeHD;
            PDate = date;
            Cost = cost();
        }

        public string ShowAllInformation()
        {
            Cost = cost();
            return "\rТип компьютера: " + this.TypeComp +
                "\r\nПроцессор: " +
                "\r\n\tПроизводитель: " + this.Processor.Producer +
                "\r\n\tСерия: " + this.Processor.Series +
                "\r\n\tМодель: " + this.Processor.Model +
                "\r\n\tКоличество ядер: " + this.Processor.CountOfCores +
                "\r\n\tЧастота и максимальная частота: " + this.Processor.Frequency + " ГГц, " + this.Processor.MaxFrequency + " ГГц" +
                "\r\n\tРазрядность архитектуры: х" + this.Processor.BitArchitecture +
                "\r\n\tРазмер кэша L1-L3: " + this.Processor.Cache1 + " Кб, " + this.Processor.Cache2 + " Мб, " + this.Processor.Cache3 + " Мб" +
                "\r\nВидеокарта: " +
                "\r\n\tПроизводитель: " + this.GraphicCard.Producer +
                "\r\n\tСерия: " + this.GraphicCard.Series +
                "\r\n\tМодель: " + this.GraphicCard.Model +
                "\r\n\tЧастота: " + this.GraphicCard.Frequency + " ГГц" +
                "\r\n\tПоддержка DiretX11: " + this.GraphicCard.DiretX11 +
                "\r\n\tОбъем памяти: " + this.GraphicCard.Memory + " Гб" +
                "\r\nРазмер и тип ОЗУ: " + this.SizeOZY + " Гб, " + this.TypeOZY +
                "\r\nРазмер и тип жесткого диска: " + this.SizeHD + " Тб, " + this.TypeHD +
                "\r\nДата приобретения: " + this.PDate +
                "\r\n\nСтоимость компьютера: " + this.Cost + "$\r\n\r\n";
        }
        public string ShowShortInfo()
        {
            Cost = cost();
            return "\rТип компьютера: " + this.TypeComp +
                "\r\nПроцессор: " + this.Processor.Producer + ", " + this.Processor.Series + ", " + this.Processor.Model +
                "\r\nЧастота процессора: " + this.Processor.Frequency + " ГГц" +                
                "\r\nРазмер и тип ОЗУ: " + this.SizeOZY + " Гб, " + this.TypeOZY +
                "\r\nСтоимость компьютера: " + this.Cost + "$\r\n\r\n\r\n";
        }
        public int cost()
        {
            int result = 0;
            switch (TypeComp)
            {
                case "Сервер":
                    result += 450;
                    break;
                case "Рабочая станция":
                    result += 300;
                    break;
                case "Ноутбук":
                    result += 250;
                    break;
            }
            if (SizeOZY >= 16) result += 100;
            else result += 55;
            switch (TypeOZY)
            {
                case "DDR2":
                    result += 45;
                    break;
                case "DDR3":
                    result += 60;
                    break;
                case "SIMM":
                    result += 70;
                    break;
            }
            if (SizeHD >= 3) result += 90;
            else result += 45;
            switch (TypeHD)
            {
                case "HDD":
                    result += 40;
                    break;
                case "SSD":
                    result += 80;
                    break;
            }
            if (Convert.ToInt32(Processor.BitArchitecture) == 64) result += 30;
            if (Convert.ToInt32(Processor.CountOfCores) >= 4) result += 20;
            if (GraphicCard.Memory >= 4) result += 60;
            if (GraphicCard.DiretX11) result += 35;
            return result;
        }
    }

    [Serializable]
    public abstract class ComputerConfig
    {
        public ComputerConfig() { }
        public abstract void Comp(string type, string typeOZY, string typeHD);

        public string TypeComp { get; set; }
        public string TypeOZY { get; set; }
        public string TypeHD { get; set; }
    }

    [Serializable]
    public abstract class ComputerHardware
    {
        public ComputerHardware() { }
        public abstract void Comp(Processor proc, GraphicCard gc, int sizeHD);
        public virtual int SizeHD { get; set; }
        public Processor Processor { get; set; }
        public GraphicCard GraphicCard { get; set; }
        public abstract void SetPDate(string date);
        public virtual string PDate { get; set; }
    }

    public interface IFactory
    {
        ComputerConfig CreateConfig();
        ComputerHardware CreateHardware();
    }
}
