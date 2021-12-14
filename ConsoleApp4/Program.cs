using System;

using System.Collections.Generic;


class Program
{
	static void Main(string[] args)
	{
		// Кол-во вершин.
		const int n = 5;
		// Основаня матрица.
		int[][] matrix = new int[n][];
		for (int i = 0; i < n; i++)
			matrix[i] = new int[n];

		for (int i = 0; i < n; i++)
		{
			Console.Write($"\nВершина {i + 1}: ");
			for (int j = i; j < n; j++)
			{
				matrix[i][j] = new Random().Next(0, 2);
				matrix[j][i] = matrix[i][j];
			}

			matrix[i][i] = 0;
			foreach (var item in matrix[i])
				Console.Write(item + " ");
		}
        Random rand = new Random();
        Queue<int> q = new Queue<int>(); //Это очередь, хранящая номера вершин
        int u;
        u = rand.Next(3, 5);
        bool[] used = new bool[u + 1];  //массив отмечающий посещённые вершины
        int[][] g = new int[u + 1][];   //массив содержащий записи смежных вершин
        used[u] = true;     //массив, хранящий состояние вершины(посещали мы её или нет)
        q.Enqueue(u);
        Console.WriteLine("\nНачинаем обход с {0} вершины", u + 1);
        while (q.Count != 0)
        {
            u = q.Peek();
            q.Dequeue();
            Console.WriteLine("Перешли к узлу {0}", u + 1);

            for (int i = 0; i < g.Length; i++)
            {
                if (Convert.ToBoolean(g[u][i]))
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        q.Enqueue(i);
                        Console.WriteLine("Добавили в очередь узел {0}", i + 1);
                    }
                }
            }
        }
        Console.ReadKey();
    }
}


