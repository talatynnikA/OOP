using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{//(Builder) - шаблон проектирования, который инкапсулирует создание объекта и позволяет разделить его на различные этапы. процессор на модели, серию, частоту, ядра
    public class ServerProcessorBuilder : BuilderProcessor   {
        public override void SetProducer(Producer producer)
        {
            this.Processor.Producer = Convert.ToString(producer);
        }
        public override void SetSeries(Series series)
        {
            this.Processor.Series = Convert.ToString(series);
        }
        public override void SetModel(Model model)
        {
            this.Processor.Model = Convert.ToString(model);
        }
        public override void SetCountOfCores(CountOfCores cores)
        {
            this.Processor.CountOfCores = Convert.ToInt32(cores);
        }
        public override void SetFrequency(Frequency freq)
        {
            this.Processor.Frequency = Convert.ToInt32(freq);
        }
        public override void SetMaxFrequency(MaxFrequency maxFreq)
        {
            this.Processor.MaxFrequency = Convert.ToInt32(maxFreq);
        }
        public override void SetBitArchitecture(BitArchitecture bitArch)
        {
            this.Processor.BitArchitecture = Convert.ToInt32(bitArch);
        }
        public override void SetCache1(Cache1 l1)
        {
            this.Processor.Cache1 = Convert.ToInt32(l1);
        }
        public override void SetCache2(Cache2 l2)
        {
            this.Processor.Cache2 = Convert.ToInt32(l2);
        }
        public override void SetCache3(Cache3 l3)
        {
            this.Processor.Cache3 = Convert.ToInt32(l3);
        }
    }
    //сложный объект, требующий  пошаговой инициализации множества полей и вложенных объектов. 
    public class LaptopProcessorBuilder : BuilderProcessor
    {
        public override void SetProducer(Producer producer)
        {
            this.Processor.Producer = Convert.ToString(producer);
        }
        public override void SetSeries(Series series)
        {
            this.Processor.Series = Convert.ToString(series);
        }
        public override void SetModel(Model model)
        {
            this.Processor.Model = Convert.ToString(model);
        }
        public override void SetCountOfCores(CountOfCores cores)
        {
            this.Processor.CountOfCores = Convert.ToInt32(cores);
        }
        public override void SetFrequency(Frequency freq)
        {
            this.Processor.Frequency = Convert.ToInt32(freq);
        }
        public override void SetMaxFrequency(MaxFrequency maxFreq)
        {
            this.Processor.MaxFrequency = Convert.ToInt32(maxFreq);
        }
        public override void SetBitArchitecture(BitArchitecture bitArch)
        {
            this.Processor.BitArchitecture = Convert.ToInt32(bitArch);
        }
        public override void SetCache1(Cache1 l1)
        {
            this.Processor.Cache1 = Convert.ToInt32(l1);
        }
        public override void SetCache2(Cache2 l2)
        {
            this.Processor.Cache2 = Convert.ToInt32(l2);
        }
        public override void SetCache3(Cache3 l3)
        {
            this.Processor.Cache3 = Convert.ToInt32(l3);
        }
    }

    public class WorkStationProcessorBuilder : BuilderProcessor
    {
        public override void SetProducer(Producer producer)
        {
            this.Processor.Producer = Convert.ToString(producer);
        }
        public override void SetSeries(Series series)
        {
            this.Processor.Series = Convert.ToString(series);
        }
        public override void SetModel(Model model)
        {
            this.Processor.Model = Convert.ToString(model);
        }
        public override void SetCountOfCores(CountOfCores cores)
        {
            this.Processor.CountOfCores = Convert.ToInt32(cores);
        }
        public override void SetFrequency(Frequency freq)
        {
            this.Processor.Frequency = Convert.ToInt32(freq);
        }
        public override void SetMaxFrequency(MaxFrequency maxFreq)
        {
            this.Processor.MaxFrequency = Convert.ToInt32(maxFreq);
        }
        public override void SetBitArchitecture(BitArchitecture bitArch)
        {
            this.Processor.BitArchitecture = Convert.ToInt32(bitArch);
        }
        public override void SetCache1(Cache1 l1)
        {
            this.Processor.Cache1 = Convert.ToInt32(l1);
        }
        public override void SetCache2(Cache2 l2)
        {
            this.Processor.Cache2 = Convert.ToInt32(l2);
        }
        public override void SetCache3(Cache3 l3)
        {
            this.Processor.Cache3 = Convert.ToInt32(l3);
        }
    }
}
