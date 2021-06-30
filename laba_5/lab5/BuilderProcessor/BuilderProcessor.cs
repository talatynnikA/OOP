using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public abstract class BuilderProcessor
    {
        public Processor Processor { get; private set; }

        public BuilderProcessor()
        {
            Processor = new Processor();
        }

        public abstract void SetProducer(Producer producer);
        public abstract void SetSeries(Series series);
        public abstract void SetModel(Model model);
        public abstract void SetCountOfCores(CountOfCores cores);
        public abstract void SetFrequency(Frequency freq);
        public abstract void SetMaxFrequency(MaxFrequency maxFreq);
        public abstract void SetBitArchitecture(BitArchitecture bitArch);
        public abstract void SetCache1(Cache1 l1);
        public abstract void SetCache2(Cache2 l2);
        public abstract void SetCache3(Cache3 l3);
    }
}
