using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searh
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = Convert.ToInt32(Console.ReadLine());
            var i = 0;
            int[] mass = new int[count];
            for (i = 0; i < count; i++)
            {
                mass[i] = Convert.ToInt32(Console.ReadLine());
            }
            var a = Convert.ToInt32(Console.ReadLine());
            int low, high, middle;
            low = 0;
            high = count - 1;
            while (low <= high)
            {
                middle = (low + high) / 2;
                if (a < mass[middle])
                    high = middle - 1;
                else if (a > mass[middle])
                    low = middle + 1;
                else
                {
                    Console.WriteLine("Двоичный поиск. Ваше число на позиции");
                    Console.WriteLine(middle+1);
                    low = high + 1;
                }
            }
            var v = 0;
            for (i = 0; i < count; i++)
            {
                if (a == mass[i])
                {
                    v = i;
                    Console.WriteLine("Поиск перебором. Ваше число на позиции");
                    Console.WriteLine(v+1);
                }
            }







                Console.ReadKey();
        }
    }
}
