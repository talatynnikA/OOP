using System;//организ. управл и объед.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab2
{//Состояние (State) - шаблон проектирования, 
    //который позволяет объекту изменять свое поведение в зависимости от внутреннего состояния.
    public interface IUserConfig
    {
         Color Background { get; }
         Font FontType { get; }
         int FontSize { get; }
    }
}
