using System;

using System.Collections.Generic;

using System.Linq;

namespace Graf.L5

{
    internal class Program
    {
        private static void Main()
        {
           int[,] matrix = new int[5, 5]; //матрица смежности
            Queue<int> q = new Queue<int>(); //очередь
            int[,] graf = { //перечень ребер


{ 8,4},
{ 6,3},
{ 4,2},
{ 4,1}
};
            add_edge(graf, matrix);
            displayMatrix(matrix);
            int u = matrix.GetLength(0) - 1;
            int[][] g = new int[u + 1][]; //массив массивов
            bool[] used = new bool[u + 1]; //массив посещенных вершин
            for (int i = 0; i < u + 1; i++)
           {
                g[i] = new int[u + 1];
                Console.Write("\n({0}) вершина -->[", i + 1);
                for (int j = 0; j < u + 1; j++)
                {
                   g[i][j] = matrix[i, j]; //добавляем строку из матрицы смежности в массив
                }
                foreach (var item in g[i])
                {
                    Console.Write(" {0}", item);
                }
               Console.Write("]\n");
            }
            used[u] = true; //массив, хранящий состояние вершины(посещали мы её или нет)
            q.Enqueue(u); //добавление в очередь
            Console.WriteLine("Начинаем обход с {0} вершины", u + 1);
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
                        }                    }

               }
            }

        }

        public static int[,] add_edge(int[,] graf, int[,] matrix) //заполнение матрицы смежности по перечню ребер
        {
            for (int i = 0; i < 8; i++)
            {
                matrix[graf[i, 0] - 1, graf[i, 1] - 1] = 1;
                matrix[graf[i, 1] - 1, graf[i, 0] - 1] = 1;
            }
            return matrix;
        }
        public static void displayMatrix(int[,] m) //метод вывода матрицы
        {
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(0); j++)
                {
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();

            }

        }

    }

}
