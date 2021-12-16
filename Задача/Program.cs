using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Задача
{ /*Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. 
     * Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом. 
     * Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
     * Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево. 
     * Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно.
     * Создать многопоточное приложение, моделирующее работу садовников.
   */
    class Program
    {
        private static int[,] land;
        private static int m;
        private static int n;

        static void Main()


        {
            Console.WriteLine("Задайте парметр n двумерного массива ");

            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Задайте парметр m двумерного массива ");

            m = Convert.ToInt32(Console.ReadLine());

            land = new int[n, m];

            ThreadStart threadStart1 = new ThreadStart(gardener1);

            Thread one = new Thread(threadStart1);

            ThreadStart threadStart2 = new ThreadStart(gardener2);

            Thread two = new Thread(threadStart2);

            Console.WriteLine("При параллельной работе первого и второго садовника сад имеет вид( где 1- участок, сделанный первым садовником , 2- участок, сделанный вторым садовником) : ");
            Console.WriteLine();

            one.Start();
            two.Start();

            one.Join();
            two.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(land[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void gardener1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (land[i, j] == 0)
                        land[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        private static void gardener2()
        {
            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (land[j, i] == 0)
                        land[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
