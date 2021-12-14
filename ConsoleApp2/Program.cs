﻿using System;

using System.Collections.Generic;
namespace lec5

{
    class Program
    {
        static public void Main()
        {
            int verticesCount = 10;
            int[,] adjacency = new int[verticesCount, verticesCount];
            Random rnd = new Random();

            // Псевдослучайное заполнение матрицы смежности
            for (int row = 0; row < verticesCount - 1; row++)
                for (int col = row + 1; col < verticesCount; col++)
                    if (rnd.Next(3) < 1)
                    {
                        adjacency[row, col] = 1;
                        adjacency[col, row] = 1; Console.WriteLine(adjacency[row, col]);
                    }

           
            Console.WriteLine("Обход графа в ширину с печатью вершин.");
            PrintWidth(adjacency);
        }

        static bool IsVerifyGraf(int[,] adjacency)
        {
            int verticesCount = adjacency.GetLength(0);
            if (verticesCount != adjacency.GetLength(1))
            {
                Console.WriteLine("Ошибка! Матрица смежности неверной размерности!");
                return false;
            }
            bool error = false;
            for (int row = 0; row < verticesCount; row++)
            {
                if (adjacency[row, row] != 0)
                    error = true;
                for (int col = row + 1; col < verticesCount; col++)
                    if (adjacency[row, col] != adjacency[col, row])
                    {
                        error = true;
                        break;
                    }
                if (error)
                    break;
            }
            if (error)
            {
                Console.WriteLine("Ошибка! Матрица смежности ошибочна!");
                return false;
            }
            return true;
        }

        static void PrintVert(int Vert, int[,] adjacency)
        {
            if (!IsVerifyGraf(adjacency))
                return;
            Console.Write($"Вершина {Vert}. Смежна с вершинами:");
            int verticesCount = adjacency.GetLength(0);
            for (int col = 0; col < verticesCount; col++)
                if (adjacency[Vert, col] != 0)
                    Console.Write($"  {col}");
        }

        static void PrintDeep(int[,] adjacency)
        {
            if (!IsVerifyGraf(adjacency))
                return;

            int verticesCount = adjacency.GetLength(0);

            List<int> vertList = new List<int>();
            Stack<int> vertStack = new Stack<int>();

            for (int vert = 0; vert < verticesCount; vert++)
            {
                //if (vertList.IndexOf(vert) >= 0)
                //    continue;

                int vertCurr = vert;
                while (true)
                {
                    if (vertList.IndexOf(vertCurr) < 0)
                    {
                        PrintVert(vertCurr, adjacency);
                        Console.WriteLine();
                        vertList.Add(vertCurr);

                        for (int col = 0; col < verticesCount; col++)
                            if (adjacency[vertCurr, col] != 0 && vertList.IndexOf(col) < 0)
                                vertStack.Push(col);
                    }

                    if (vertStack.Count == 0)
                        break;

                    vertCurr = vertStack.Pop();
                }

            }

        }

        static void PrintWidth(int[,] adjacency)
        {
            if (!IsVerifyGraf(adjacency))
                return;

            int verticesCount = adjacency.GetLength(0);

            List<int> vertList = new List<int>();
            Queue<int> vertQueue = new Queue<int>();

            for (int vert = 0; vert < verticesCount; vert++)
            {
                //if (vertList.IndexOf(vert) >= 0)
                //    continue;

                int vertCurr = vert;
                while (true)
                {
                    if (vertList.IndexOf(vertCurr) < 0)
                    {
                        PrintVert(vertCurr, adjacency);
                        Console.WriteLine();
                        vertList.Add(vertCurr);

                        for (int col = 0; col < verticesCount; col++)
                            if (adjacency[vertCurr, col] != 0 && vertList.IndexOf(col) < 0)
                                vertQueue.Enqueue(col);
                    }

                    if (vertQueue.Count == 0)
                        break;

                    vertCurr = vertQueue.Dequeue();
                }

            }

        }
    }
}
