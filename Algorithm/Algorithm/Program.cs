using System;
using System.Collections.Generic;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> flow = new Queue<int>();
            int[,] stream = new int[2, 3];
            int k = 0;
            int x = 4;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 0)
                    {
                        k = k + 1;
                        stream[i, j] = k;
                    }
                    else
                    {
                        x = x - 1;
                        stream[i, j] = x;
                    }
                }
            }

            if (stream[0, 0] > stream[0, 1] && stream[0, 0] > stream[0, 2])
            {
                flow.Enqueue(1);
                if (stream[0, 1] > stream[0, 2])
                {
                    flow.Enqueue(2);
                    flow.Enqueue(3);
                }
                else
                {
                    flow.Enqueue(3);
                    flow.Enqueue(2);
                }
            }
            else if (stream[0, 1] > stream[0, 0] && stream[0, 1] > stream[0, 2])
            {
                flow.Enqueue(2);
                if (stream[0, 0] > stream[0, 2])
                {
                    flow.Enqueue(1);
                    flow.Enqueue(3);
                }
                else
                {
                    flow.Enqueue(3);
                    flow.Enqueue(1);
                }
            }
            else if (stream[0, 2] > stream[0, 0] && stream[0, 2] > stream[0, 1])
            {
                flow.Enqueue(3);
                if (stream[0, 0] > stream[0, 1])
                {
                    flow.Enqueue(1);
                    flow.Enqueue(2);
                }
                else
                {
                    flow.Enqueue(2);
                    flow.Enqueue(1);
                }
            }



            Console.WriteLine("Сейчас в очереди {0} потока", flow.Count);
            foreach (int p in flow)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine();
            int number = flow.Peek();
            Console.WriteLine("Поток " + number + " в критической секции");
            flow.Dequeue();
            number = flow.Peek();
            Console.WriteLine("Поток " + number + " в критической секции");
            flow.Dequeue();
            number = flow.Peek();
            Console.WriteLine("Поток " + number + " в критической секции");
            flow.Dequeue();

        }

    }
}
