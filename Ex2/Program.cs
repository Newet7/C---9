// Задача 2**. Напишите программу, которая спирально заполнит числами от 1 до 16 двумерный массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

using System;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main starts here
            Console.Clear();
            var a = new Matrix();
            Console.WriteLine();
            a.PrintMatrix();

        }
    }
    class Matrix
    {
        public int Row { get; init; }
        public int Column { get; init; }
        public int[,] Data { get; init; }
        public Matrix()
        {
            Console.Write("input count of rows: ");
            this.Row = GetIntNumber();
            Console.Write("input count of columns: ");
            this.Column = GetIntNumber();
            this.Data = new int[this.Row, this.Column];
            SpiralFilling();
        }
        private void SpiralFilling()
        {
            int el = 0;
            int direction = 0;
            int i = 0, j = 0;
            while (el < this.Data.Length)
            {
                direction %= 4;
                el++;
                this.Data[i, j] = el;
                switch (direction)
                {
                    case 0:
                        if (j < this.Column-1 && this.Data[i,j+1]==0) j++;
                        else 
                        {
                            i++;
                            direction++;
                        }
                        break;
                    case 1:
                        if (i < this.Row-1 && this.Data[i+1,j]==0) i++;
                        else 
                        {
                            j--;
                            direction++;
                        }
                        break;
                    case 2:
                        if (j > 0 && this.Data[i,j-1]==0) j--;
                        else
                        {
                            i--;
                            direction++;
                        }
                        break;
                    case 3:
                        if (i > 0 && this.Data[i-1,j]==0) i--;
                        else
                        {
                            j++;
                            direction++;
                        }
                        break;
                }
            }
        }
        public void PrintMatrix()
        {
            for (int i = 0; i<this.Row;i++)
            {
                for (int j = 0; j < this.Column; j++)
                {
                    Console.Write("{0,4}",this.Data[i,j]);
                }
                Console.WriteLine();
            }
        }
        static int GetIntNumber() => Convert.ToInt32(Console.ReadLine());
    }
}

