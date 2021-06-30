using System;//показыв. как объекты и кл. объед
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{//Декоратор (Decorator) представляет структурный шаблон проектирования, 
    //который позволяет динамически подключать к объекту дополнительную функциональность.
    public abstract class ProcessorDecorator : Processor
    {
        protected Processor Processor;

        public ProcessorDecorator(Producer producer, Model model, Series series, Processor processor)
            : base(processor.Producer, processor.Series, processor.Model, processor.CountOfCores, processor.Frequency, processor.MaxFrequency,
            processor.BitArchitecture, processor.Cache1, processor.Cache2, processor.Cache3)
        {
            this.Processor = processor;           
        }
    }

    public class OC_Processor : ProcessorDecorator
    {
        public OC_Processor(Processor processor)
            : base(new Producer
            {
                producer = processor.Producer,

            }, new Model
            {
                model = processor.Model,
            }, new Series
            {
                series = processor.Series,
            }, 
                  processor)
        { }
    }

}//7 || 11
//Паттерн Хранитель (Memento) позволяет выносить внутреннее состояние объекта за его пределы 
//для последующего возможного восстановления объекта без нарушения принципа инкапсуляции.


//Паттерн Стратегия (Strategy) представляет шаблон проектирования, который определяет набор алгоритмов, 
//инкапсулирует каждый из них и обеспечивает их взаимозаменяемость.


//Паттерн "Наблюдатель" (Observer) представляет поведенческий шаблон проектирования, 
//который использует отношение "один ко многим"

//Паттерн "Команда" (Command) позволяет инкапсулировать запрос на выполнение определенного действия в виде отдельного объекта. 