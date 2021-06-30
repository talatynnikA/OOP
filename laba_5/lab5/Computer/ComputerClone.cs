using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace lab2
{
    public interface IComputerClone
    {
        IComputerClone Clone();
    }

    [Serializable]
    [XmlInclude(typeof(WorkStationConfig))]
    [XmlInclude(typeof(WorkStationHardware))]
    public class ComputerClone : IComputerClone
    {
        public ComputerClone() { }

        public ComputerConfig config;
        public ComputerHardware hardware;

        public ComputerClone(IFactory factory)
        {
            config = factory.CreateConfig();
            hardware = factory.CreateHardware();
        }

        public IComputerClone Clone()
        {
            return this.MemberwiseClone() as IComputerClone;
        }

        public object DeepCopy()
        {
            object figure = null;
            using (MemoryStream tempStream = new MemoryStream())
            {
                BinaryFormatter binFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));

                binFormatter.Serialize(tempStream, this);
                tempStream.Seek(0, SeekOrigin.Begin);

                figure = binFormatter.Deserialize(tempStream);
            }
            return figure;
        }
    }
}
