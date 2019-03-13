using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmLearning
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] array = /*CreateArray(100); */new int[] { 3,4,1,5,6,7,9,0,2,8};
            ToString(array);
            //InsertSortClass.InsertSort(array);
            //array = SortClass.BubbleSort(array);
            //SortClass.MergeSort(array);
            //SortClass.QuickSort(array);
            SortClass.SelectSort(array);
            ToString(array);
            Console.ReadLine();
        }

        static int[] CreateArray(int len)
        {
            int[] array = new int[len];
            var ran = new Random();
            for (var i = 0; i < len; i++)
            {
                array[i] = ran.Next(0, len);
            }
            return array;
        }

        public static void ToString(int[] array)
        {
            var sb = new StringBuilder();
            sb.Append("[");
            foreach (var i in array)
            {
                sb.Append(i);
                sb.Append(",");
            }
            sb.Append("]");
            Console.WriteLine(sb.ToString());
        }

    }
}
