using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    [Serializable]
    public class GraphicCard
    {
        public string Producer { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int Frequency { get; set; }
        public bool DiretX11 { get; set; }
        public int Memory { get; set; }

        public GraphicCard() { }
        public GraphicCard(string producer, string series, string model, int freq, bool diretX11, int memory)
        {
            Producer = producer;
            Series = series;
            Model = model;
            Frequency = freq;
            DiretX11 = diretX11;
            Memory = memory;
        }
    }
}
