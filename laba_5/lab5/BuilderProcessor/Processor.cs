using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    [Serializable]
    public class Processor
    {
        public Processor()
        {

        }

        public Processor(string producer, string series, string model, int cores, int freq, int maxFreq,
            int bitArch, int l1, int l2, int l3)
        {
            this.Producer = producer;
            this.Series = series;
            this.Model =model;
            this.CountOfCores = cores;
            this.Frequency =freq;
            this.MaxFrequency = maxFreq;
            this.BitArchitecture = bitArch;
            this.Cache1 = l1;
            this.Cache2 = l2;
            this.Cache3 = l3;
        }
        public string Producer { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public int CountOfCores { get; set; }
        public int Frequency { get; set; }
        public int MaxFrequency { get; set; }
        public int BitArchitecture { get; set; }
        public int Cache1 { get; set; }
        public int Cache2 { get; set; }
        public int Cache3 { get; set; }
    }

    public class Producer
    {
        public string producer
        {
            get; set;
        }
    }

    public class Series
    {
        public string series
        {
            get; set;
        }
    }

    public class Model
    {
        public string model
        {
            get; set;
        }
    }

    public class CountOfCores
    {
        public int cores
        {
            get; set;
        }
    }

    public class Frequency
    {
        public int freq
        {
            get; set;
        }
    }

    public class MaxFrequency
    {
        public int maxFreq
        {
            get; set;
        }
    }

    public class BitArchitecture
    {
        public int bitArch
        {
            get; set;
        }
    }

    public class Cache1
    {
        public int l1
        {
            get; set;
        }
    }

    public class Cache2
    {
        public int l2
        {
            get; set;
        }
    }

    public class Cache3
    {
        public int l3
        {
            get; set;
        }
    }
}
