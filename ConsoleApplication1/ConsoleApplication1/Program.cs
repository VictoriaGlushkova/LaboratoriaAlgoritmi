using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
//пришло время принцессе выбирать себе жениха
//явились 1000 царевичей
//Их построили в очередь в случайном порядке и стали по одному приглашать к принцессе.
//принцесса, познакомившись с ними, может сказать, какой из них лучше.
//принцесса может либо принять предложение (и тогда выбор сделан навсегда), либо отвергнуть его(и тогда претендент потерян
//Какой стратегии должна придерживаться принцесса, чтобы с наибольшей вероятностью выбрать лучшего?
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int count; //явились 1000 царевичей. Принцев по условию задаём с консоли
            int C;
            C = 1;
            for (int j = 0; C!=0; j++)
            {
                Console.BufferHeight = 1000; // буфера консоли увеличен на 1000 
                Stack pretenders = new Stack(); //создан стек
                Random r = new Random(); //инициализация счётчика случайных чисел
                Console.WriteLine("Введите количество принцев");
                count = Convert.ToInt32(Console.ReadLine());
                int prince;
                for (int i = 0; i < count; i++)
                {
                rand:
                    prince = r.Next(1, count + 1);
                    if (!pretenders.Contains(prince))
                        pretenders.Push(prince);
                    else goto rand;
                }//стек заполнен СЛУЧАЙНО значениями оценок принцев:
                int max = 0;
                int test;
                int testCount = Convert.ToInt32(count / 2.718); //принцы в тестовой группе, количество делим на e
                Console.WriteLine("Всего соискателей" + count + ", Из них в тестовой группе: " + testCount);
                for (int i = 0; i < testCount; i++) //Проверка лучшего в тестовой группе
                {
                    test = (int)pretenders.Pop();
                    Console.Write((i + 1) + ". Оценка: " + test + "решение принцесы");
                    if (test > max)
                    {
                        max = test;
                        Console.Write(" Мммм, Хорошенький, но у меня есть ещё кандидаты");
                    }

                    else
                        Console.Write(" Не по масти, идём дальше");
                    Console.WriteLine();
                }
                for (int i = 0; i < count - testCount; i++) //Вторая группа
                {
                    test = (int)pretenders.Pop();
                    Console.Write((i + testCount + 1) + ". Оценка: " + test);
                    if (test > max)//Поиск лучшего, чем последний хорошенький
                    {
                        Console.Write(" Всё, выбор сделан!!!");
                        break;
                    }
                    else if (pretenders.Count == 0) //Последний принц, куда деваться!?
                        Console.Write(" Так и быть, пускай будет хоть хромой, хоть косой");
                    else Console.Write(" Не по масти");
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("Продолжаем? Да-1,Нет-0");
                C = Convert.ToInt32(Console.ReadLine());

            }

        }
    }
}
