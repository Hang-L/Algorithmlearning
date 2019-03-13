using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmLearning
{
    /// <summary>
    /// 插入排序
    /// </summary>
    public class SortClass
    {
        /// <summary>
        /// 插入排序 
        /// 原地排序,稳定排序
        /// 时间复制度log(n²)
        /// </summary>
        public static void InsertSort(int[] array)
        {
            //排序数组
            array = new int[] { 5, 2, 4, 6, 1, 3, 7, 9, 8, 5, 6, 4, 3 };
            for (var j = 0; j < array.Length; j++)
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
                array[i + 1] = key;
            }
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// 冒泡排序
        /// 原地排序，稳定排序
        /// 时间复杂度log(n²)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] BubbleSort(int[] array)
        {
            int m = -1;
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        m = array[i];
                        array[i] = array[j];
                        array[j] = m;
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// 归并排序
        /// 非原地排序,稳定排序
        /// 时间复制度(nlogn)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static void MergeSort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// 快速排序
        /// 原地排序
        /// </summary>
        /// <param name="array"></param>
        public static void QuickSort(int[] array)
        {

        }

        /// <summary>
        /// 分治
        /// </summary>
        /// <param name="array">数据数组</param>
        /// <param name="p">起点</param>
        /// <param name="r">终点</param>
        private static void Sort(int[] array, int p, int r)
        {
            if (p >= r) return;
            int q = p + (r - p) / 2;
            Sort(array, p, q);
            Sort(array, q + 1, r);
            Merge(array, p, q, r);
        }

        /// <summary>
        /// 归并
        /// </summary>
        /// <param name="array">原始数组</param>
        /// <param name="p">起点</param>
        /// <param name="q">中点</param>
        /// <param name="r">终点</param>
        private static void Merge(int[] array, int p, int q, int r)
        {
            int[] temp = new int[r - p + 1];
            int i = p;
            int j = q + 1;
            int k = 0;
            while (i <= q && j <= r)
            {
                if (array[i] <= array[j])
                {
                    temp[k++] = array[i++];
                }
                else
                {
                    temp[k++] = array[j++];
                }
            }
            int start = i;
            int end = q;
            if (j <= r)
            {
                start = j;
                end = r;
            }
            while (start <= end)
            {
                temp[k++] = array[start++];
            }
            for (i = 0; i <= r - p; i++)
            {
                array[p+i] = temp[i];
            }
        }


    }
}

