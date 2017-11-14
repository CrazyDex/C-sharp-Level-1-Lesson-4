using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HwT2
{
    //Evdokhin Denis

    //2. а) Дописать класс для работы с одномерным массивом.
    //Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального
    //значения с заданным шагом.
    //Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse,
    //меняющий знаки у всех элементов массива, Метод Multi,
    //умножающий каждый элемент массива на определенное число,
    //свойство MaxCount, возвращающее количество максимальных элементов.
    //В Main продемонстрировать работу класса.


    //б)* Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.

    class Mas1Mer
    {
        private int[] arr;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="length">Длина массива</param>
        /// <param name="start">Значение 1 элемента массива</param>
        /// <param name="shag">Шаг</param>
        public Mas1Mer(int length = 1, int start = 0, int shag = 0)
        {
            arr = new int[length];
            arr[0] = start;
            if (length > 1)
            {
                for (int i = 1; i < length; i++)
                {
                    arr[i] = arr[i-1] + shag;
                }
            }           
        }

        public Mas1Mer(string path)
        {
            string[] s = File.ReadAllLines(path);
            arr = new int[s.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Int32.Parse(s[i]);
            }
        }


        private int sum;
        /// <summary>
        /// Возвращает сумму всех элементов массива
        /// </summary>
        public int Sum 
        {
            get
            {
                sum = arr.Sum();
                return sum;
            }
        }

        /// <summary>
        /// Позволяет обращаться к элементу массива по индексу
        /// </summary>
        /// <param name="i">индекс</param>
        /// <returns></returns>
        public int this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        /// <summary>
        /// Возвращает длину массива
        /// </summary>
        public int Length
        {
            get { return arr.Length; }
        }

        /// <summary>
        /// Меняет знак каждого элемента массива
        /// </summary>
        public void Inverse()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = -arr[i];
            }
        }

        /// <summary>
        /// Умножает каждый элемент массива на N
        /// </summary>
        /// <param name="mnogitel"></param>
        public void Multi(int mnogitel = 1)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= mnogitel;
            }
        }

        private int maxCount = 1;
        /// <summary>
        /// Возвращает количество элементов с максимальным значением
        /// </summary>
        public int MaxCount
        {
            get
            {
                int[] temp = arr;
                Array.Sort(temp);
                int n = temp.Length - 1;
                int max = temp[n];
                try
                {
                    while (true)
                    {
                        if (temp[n - 1] == max)
                        {
                            maxCount++;
                            n--;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (Exception) {}
                return maxCount;
            }
        }

        public void MasFileWrite(string path)
        {
            string[] str = new string[arr.Length];
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = Convert.ToString(arr[i]);
            }
            File.WriteAllLines(path, str);
        }

        public void MasFileRead(string path)
        {
            string[] s = File.ReadAllLines(path);
            Array.Resize(ref arr, s.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Int32.Parse(s[i]);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Mas1Mer mas = new Mas1Mer(10,7);
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(mas[i]);
            }
            Console.WriteLine(mas.Sum);
            mas.Inverse();
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(mas[i]);
            }
            mas.Multi(-2);
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(mas[i]);
            }
            Console.WriteLine(mas.MaxCount);

            Console.WriteLine("\n\n\n\n\n");

            Mas1Mer mas2 = new Mas1Mer(@"C:\Users\Denis\source\repos\mas.txt");
            for (int i = 0; i < mas2.Length; i++)
            {
                Console.WriteLine(mas2[i]);
            }

            mas.MasFileWrite(@"C:\Users\Denis\source\repos\mas2tofile.txt");
            Console.ReadLine();
            mas.MasFileRead(@"C:\Users\Denis\source\repos\mas2tofile.txt");
            Console.WriteLine("\n\n");
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(mas[i]);
            }
        }
    }
}
