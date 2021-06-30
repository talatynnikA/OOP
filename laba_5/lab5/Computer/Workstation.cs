using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    [Serializable]

    public class WorkStationConfig : ComputerConfig
    {
        public override void Comp(string type, string typeOZY, string typeHD)
        {
            this.TypeComp = type;
            this.TypeHD = typeHD;
            this.TypeOZY = typeOZY;
        }
    }
    [Serializable]

    public class WorkStationHardware : ComputerHardware
    {
        public override void Comp(Processor proc, GraphicCard gc, int sizeHD)
        {
            this.Processor = proc;
            this.GraphicCard = gc;
            this.SizeHD = sizeHD;
        }

        public override void SetPDate(string date)
        {
            this.PDate = date;
        }
    }
}
