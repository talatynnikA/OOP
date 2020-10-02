using System;
using System.Dynamic;
using System.Text;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int intval;
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("Добро пожаловать в C#!");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            Console.WriteLine("введите значение типа bool(true или false): ");
            bool boolean = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("                                                                                           ");
            Console.WriteLine("введите значение типа byte(0 to 255): ");
            byte bytevalue = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("                                                                                           ");
            Console.WriteLine("введите значение типа sbyte(-128 to 127): ");
            sbyte sbytevalue = Convert.ToSByte(Console.ReadLine());
            Console.WriteLine("                                                                                           ");
            Console.WriteLine("введите значение типа char(1 символ): ");
            char charvalue = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("                                                                                           ");
            Console.WriteLine("введите значение типа decimal(±1.0 x 10^(-28) to ±7.9228 x 10^(28)(например 21)): ");
            decimal decimalvalue = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("                                                                                           ");
            Console.WriteLine("введите значение типа double(±5.0 × 10^(−324) to ±1.7 × 10^(308)(например 45,76)):");
            double doublevalue = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("                                                                                           ");
            Console.WriteLine("введите значение типа float(±1.5 x 10^(−45) to ±3.4 x 10^(38)(например 30,6)):");
            float floatvalue = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("                                                                                           ");
            Console.WriteLine("введите значение типа int((например 30)):");
            int intvalue = Convert.ToInt32(Console.ReadLine());
            int intvalue2 = 136;
            Console.WriteLine("                                                                                           ");
            Console.WriteLine("введите значение типа uint(0 to 4,294,967,295(например 8398)):");
            uint uintvalue = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("                                                                                           ");
            Console.WriteLine("введите значение типа long (например 2000000):");
            long longvalue = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("                                                                                           ");
            Console.WriteLine("введите значение типа ulong (например 30000000):");
            ulong ulongvalue = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("                                                                                           ");
            Console.WriteLine("введите значение типа short (например 32767):");

            short shortvalue = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("                                                                                           ");
            Console.WriteLine("введите значение типа ushort (например 65535):");

            ushort ushortvalue = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("Значения введены. вывод на экран того что было введено:");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("значение переменной boolean = {0}", boolean);
            Console.WriteLine("значение переменной bytevalue = {0}", bytevalue);
            Console.WriteLine("значение переменной sbytevalue = {0}", sbytevalue);
            Console.WriteLine("значение переменной charvalue = {0}", charvalue);
            Console.WriteLine("значение переменной decimalvalue = {0}", decimalvalue);
            Console.WriteLine("значение переменной doublevalue = {0}", doublevalue);
            Console.WriteLine("значение переменной floatvalue = {0}", floatvalue);
            Console.WriteLine("значение переменной intvalue = {0}", intvalue);
            Console.WriteLine("значение переменной uintvalue = {0}", uintvalue);
            Console.WriteLine("значение переменной longvalue = {0}", longvalue);
            Console.WriteLine("значение переменной ulongvalue = {0}", ulongvalue);
            Console.WriteLine("значение переменной shortvalue = {0}", shortvalue);
            Console.WriteLine("значение переменной ushortvalue = {0}", ushortvalue);
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("выполнить преобразования");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("1) неявные");

            Int32 i32 = 5;
            Console.WriteLine("имеем переменную  (Int32 i32 = {0})", i32);
            Console.WriteLine("");
            //преобразования
            //1) неявные
            Int64 i64 = i32;    // Неявное приведение Int32 к Int64 
            Console.WriteLine("после преобразования Int32 к Int64 новая переменная Int64 i64 = i32 = {0}", i64);

            Single s = i32;     // Неявное приведение Int32 к Single
            Console.WriteLine("после преобразования Int32 к Single новая переменная Single s = i32 = {0}", s);

            long longvalue2 = intvalue;         // implicit(неявный) conversion from int to long    
            Console.WriteLine("после преобразования  int to long  новая переменная  long longvalue2 = intvalue = {0}", longvalue2);

            short shortvalue1 = bytevalue; //Неявное приведение  short k byte
            Console.WriteLine("после преобразования  short k byte новая переменная  short shortvalue1 = bytevalue = {0}", shortvalue1);

            double doublevalue1 = floatvalue;
            Console.WriteLine("после преобразования  float к double новая переменная  doublevalue1 = floatvalue = {0}", doublevalue1);


            //2) явные
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("2) явные");

            int c = (int)longvalue2;    // explicit conversion from long to int
            Console.WriteLine("после преобразования long to int новая переменная int c = (int)longvalue2 = {0}", c);


            Byte b = (Byte)i32; // Явное приведение Int32 к Byte 
            Console.WriteLine("после преобразования Int32 к Byte новая переменная Byte b = (Byte)i32 = {0}", b);

            Int16 v = (Int16)s; // Явное приведение Single к Int16
            Console.WriteLine("после преобразования Single к Int16 новая переменная Int16 v = (Int16)s = {0}", v);

            long longvalue1 = Convert.ToUInt32(longvalue);
            Console.WriteLine("после преобразования long to int32 новая переменная long longvalue1 = Convert.ToUInt32(longvalue) = {0}", longvalue1);

            string charvalue1 = Convert.ToString(charvalue);
            Console.WriteLine("после преобразования char k string новая переменная string charvalue1 = Convert.ToString(charvalue) = {0}", charvalue1);

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("упаковка и распаковка значимых типов");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            i32 = 5;
            Object obj = i32;   // Упаковка x; o ссылается на упакованный объект
            //byte m = (byte)obj; // Генерируется InvalidCastException
            byte m = (byte)(int)obj; // Распаковка, а затем приведение типа

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("  работа с неявно типизированной переменной");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            var newvar = longvalue;
            Console.Write("тип newvar: ", newvar.GetType());
            Console.WriteLine("значение newvar = {0}", newvar);
            for (var x1 = 1; x1 < 10; x1++)
            {
                Console.WriteLine(newvar);
            }

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("  пример работы с Nullable переменной");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            int? nullablevalue = null;
            int? nullablevalue2 = 5;
            Console.WriteLine(" int? nullablevalue = {0}", nullablevalue);
            Console.WriteLine(" int? nullablevalue2 = {0}", nullablevalue2);

            Console.WriteLine("  проверка на равенство : ", nullablevalue.Equals(nullablevalue2));
            //System.Console.Write(nullablevalue == nullablevalue2);
            //System.Console.Write(nullablevalue.Equals(nullablevalue2));

            Console.WriteLine("         Извлекаем хэш-код объекта, возвращаемого свойством Value:   {0}", nullablevalue.GetHashCode());
            //System.Console.Write(nullablevalue.GetHashCode());

            Console.WriteLine("      Извлекает значение текущего объекта Nullable <T> или значение по умолчанию для базового типа:  {0}", nullablevalue.GetValueOrDefault());
            System.Console.Write(nullablevalue.GetValueOrDefault());


            //Console.WriteLine("      Извлекает значение текущего объекта Nullable <T> или заданное значение по умолчанию.");
            //System.Console.Write(nullablevalue.GetValueOrDefault(nullablevalue));

            Console.WriteLine("     Возвращает текстовое представление значения текущего объекта: {0}", nullablevalue.ToString());
            //System.Console.Write(nullablevalue.ToString());

            if (nullablevalue.HasValue)
            {
                int x2 = (int)nullablevalue;//явное 
                Console.WriteLine("явное преобразование: ");
                Console.WriteLine(x2);

                int? x3 = x2; //неявное к T? 
                Console.WriteLine("неявное преобразование: ");
                Console.WriteLine(x3);

                long? x4 = x2; //неявное расширяющее
                Console.WriteLine("неявное расширяющее преобразование: ");

                Console.WriteLine(x4);
            }
            //null объединения:
            int y = nullablevalue ?? 1;  //  1
            int? z = 2;
            int t = z ?? 1; // 2

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("  работа с переменной типа var");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            var variable1 = 5;
            //variable1 = "text";

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("  работа со строками");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            string string1 = "hello world";
            Console.WriteLine(string1);
            string string2 = "hell word";
            Console.WriteLine(string2);

            Console.WriteLine(String.Compare(string1, string2));
            string string3 = "privet";
            Console.WriteLine(string3);

            Console.WriteLine(String.Concat(string3, string1, string2));
            string string4 = String.Copy(string2);
            Console.WriteLine(string4);
            
            string3 = string1.Substring(2, 5);
            Console.WriteLine(string3);

            string4 = "hello world it is me";
            string string5 = string4.Insert(5, string1);
            Console.WriteLine(string5);

            string[] words = string4.Split(" ");
            
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine("\nМассив: {0}", String.Join(" ", words[i]));

            }
            //Console.WriteLine("\nМассив: {0}", String.Join(" ", a));
            Console.WriteLine("выполнение программы завершено");
            string2 = string4.Remove(3, 7);
            Console.WriteLine(string2);
            string s1 = "";
            Console.WriteLine(string.IsNullOrEmpty(s1));

            StringBuilder sb = new StringBuilder("ABC hello world it is me", 50);
            sb.Append(new char[] { 'D', 'E', 'F' });
            sb.Append("!");
            sb.Insert(7, "компьютерный ");
            Console.WriteLine(sb);

            // заменяем слово
            sb.Replace("мир", "world");
            Console.WriteLine(sb);

            // удаляем 13 символов, начиная с 7-го
            sb.Remove(7, 13);
            Console.WriteLine(sb);

            // получаем строку из объекта StringBuilder
            string sss = sb.ToString();
            Console.WriteLine(sss);

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("  работа с массивами");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            

            // Объявляем двумерный массив
            int[,] myArr = new int[4, 5];

            Random ran = new Random();

            // Инициализируем данный массив
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    myArr[i, j] = ran.Next(1, 15);
                    Console.Write("{0}\t", myArr[i, j]);
                }
                Console.WriteLine();
            }

            string[] z1 = { string1, string2, string3, string4 };
            Console.WriteLine(z);
            for (int i = 0; i < z1.Length; i++)
                Console.WriteLine("z[{0}] = {1}", i, z1[i]);

            Console.WriteLine(z1.Length);
            Console.WriteLine("поменять произв элемент");
            Console.WriteLine("выберите позицию(0-3): ");
            int y1;
            y1=Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < z1.Length; i++)
            {
                if (y1 == i)
                {
                    Console.WriteLine("введите значение: ");
                    string newstr = Console.ReadLine();
                    z1[i] = newstr;
                }
                else
                    Console.WriteLine("некорректный ввод ");
            }

            Console.WriteLine("новый массив: ");

            for (int i = 0; i < z1.Length; i++)
                Console.WriteLine("z[{0}] = {1}", i, z1[i]);

            // Объявляем ступенчатый массив
            int[][] myArr1 = new int[3][];
            myArr1[0] = new int[2];
            myArr1[1] = new int[3];
            myArr1[2] = new int[4];

            // Инициализируем ступенчатый массив
            for (int i=0; i < 2; i++)
            {
                myArr1[0][i] = i;
                Console.Write("{0}\t", myArr1[0][i]);
            }

            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                myArr1[1][i] = i;
                Console.Write("{0}\t", myArr1[1][i]);
            }

            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                myArr1[2][i] = i;
                Console.Write("{0}\t", myArr1[2][i]);
            }

            Console.ReadLine();

            var array = new object[0];
            var str = "";

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("  кортежи");
            Console.WriteLine("-------------------------------------------------------------------------------------------");


            var tuple = (i32, string1, charvalue, string3, ulongvalue);
            Console.WriteLine("Вывод целиком: ");
            Console.WriteLine("Tuple: " + tuple);
            //Console.WriteLine(tuple.Item1); // 5
            //Console.WriteLine(tuple.Item2); // 10
            //Console.WriteLine(tuple.Item3); // 5
            //Console.WriteLine(tuple.Item4); // 10
            //Console.WriteLine(tuple.Item5); // 5
            Console.WriteLine("Вывод выборочно: ");
            Console.WriteLine("Вывод 3: {0}", tuple.Item3);
            Console.WriteLine("Вывод 1: {0}", tuple.Item1);
            Console.WriteLine("Вывод 4: {0}", tuple.Item4);
            char raspakovka = tuple.Item3;
            string raspakovka1 = tuple.Item4;
            (int, string, char, string, ulong) tup2 = (1337, "Mihail", 'Z', "Mafioznik", 88005553535);
            Console.WriteLine("Tuple 2: " + tup2);
            Console.WriteLine("Comparison of 2 tuples: " +
                ((tuple.Item1 > tup2.Item1) ? "Item from first tuple is bigger" : "Item from second tuple is bigger") + ", " +
                (String.Compare(tuple.Item2, tup2.Item2)) + ", " +
                (tuple.Item3.CompareTo(tup2.Item3)) + ", " +
                (String.Compare(tuple.Item4, tup2.Item4)) + ", " +
                ((tuple.Item5 > tup2.Item5) ? "Item from first tuple is bigger" : "Item from second tuple is bigger"));

            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("  локальная функция");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            // LOCAL FUNCTION

            Console.WriteLine();
            Console.Write("Array: ");
            int[] funcArr = new int[7];
            for (int i = 0; i < funcArr.Length; i++)
                Console.Write((funcArr[i] = ran.Next(1, 20)) + " ");
            Console.WriteLine();
            Console.WriteLine("String is 'lorem'");
            var funcRes = GetResult(funcArr, "lorem");
            Console.WriteLine("Elements of local function in tuple: " + funcRes.Item1 + ", " + funcRes.Item2 + ", " + funcRes.Item3 + ", " + funcRes.Item4);


            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("  работа с CHECKED/UNCHECKED");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            // CHECKED/UNCHECKED

            checked
            {
                Console.WriteLine();
                Console.Write("Checked max value: ");
                int val = int.MaxValue;
                Console.WriteLine(val);
            }

            unchecked
            {
                Console.WriteLine();
                Console.Write("Unchecked max value: ");
                int val = int.MaxValue;
                Console.WriteLine(val + val + 2 + val);
            }
        }

        static Tuple<int, int, int, char> GetResult(int[] numbers, string str)
        {
            int max = numbers[0];
            int min = numbers[0];
            int sum = 0;
            char let;

            foreach (int s in numbers)
            {
                if (max < s)
                    max = s;
                if (min > s)
                    min = s;
                sum += s;
            }

            let = str[0];

            return new Tuple<int, int, int, char>(max, min, sum, let);


        }


    }
    //struct State
    //{
    //    public string Name { get; set; }
    //}
}
