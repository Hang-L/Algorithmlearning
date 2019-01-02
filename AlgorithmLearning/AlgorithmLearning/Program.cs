using System;
using System.Collections.Generic;

namespace AlgorithmLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            InsertSort();
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        static void InsertSort()
        {
            //排序数组
            int[] array = new int[] { 5, 2, 4, 6, 1, 3, 7, 9, 8, 5, 6, 4, 3 };
            for (var j=0;j<array.Length;j++)
            {
                var key = array[j];
                
                var i = j - 1;
                //降序
                //while (i>=0&&array[i]<key)
                //升序
                while (i >= 0 && array[i] > key)
                {
                    array[i + 1] = array[i];
                    i--;
                }
                array[i+ 1] = key;
            }

            foreach (var item in array)
            {

            Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
