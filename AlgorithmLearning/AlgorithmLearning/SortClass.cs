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
        /// 时间复制度O(n²)
        /// </summary>
        public static void InsertSort(int[] array)
        {
            //排序数组
            //array = new int[] { 5, 2, 4, 6, 1, 3, 7, 9, 8, 5, 6, 4, 3 };
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
        }

        /// <summary>
        /// 冒泡排序
        /// 原地排序，稳定排序
        /// 时间复杂度O(n²)
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
        /// 选择排序
        /// 原地排序
        /// 非稳定排序
        /// 时间复杂度O(n²)
        /// </summary>
        /// <param name="array"></param>
        public static void SelectSort(int[] array)
        {
            int minIndex = -1;
            int tmp = -1;
            for (var i=0;i<array.Length-1;i++)
            {
                minIndex = i;
                for (var j=i+1;j<array.Length;j++)
                {
                    if (array[minIndex]>array[j])
                    {
                        minIndex = j;
                    }
                }
                tmp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = tmp;
            }
        }

        /// <summary>
        /// 归并排序
        /// 非原地排序,稳定排序
        /// 时间复制度O(nlogn)
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static void MergeSort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
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
                array[p + i] = temp[i];
            }
        }

        /// <summary>
        /// 快速排序
        /// 原地排序
        /// 非稳定排序
        /// 平均时间复杂度O(nlogn),最坏平均时间复杂度O(n²)
        /// </summary>
        /// <param name="array"></param>
        public static void QuickSort(int[] array)
        {
            QuickSortInternally(array,0,array.Length-1);
        }

        /// <summary>
        /// 快排内部实现
        /// </summary>
        /// <param name="a">原始数据</param>
        /// <param name="p">起点</param>
        /// <param name="r">终点</param>
        static void QuickSortInternally(int[] a,int p, int r)
        {
            if (p>=r)
            {
                return;
            }
            int q = Partition(a,p,r);
            QuickSortInternally(a,p,q-1);
            QuickSortInternally(a,q+1,r);
        }        

        /// <summary>
        /// 分区点
        /// </summary>
        /// <param name="a">数组数据</param>
        /// <param name="p">起点</param>
        /// <param name="r">终点</param>
        /// <returns></returns>
        static int Partition(int[] a,int p,int r)
        {
            int pivot = a[r];
            int i = p;
            for (int j=p;j<r;j++)
            {
                if (a[j]<pivot)
                {
                    if (i==j)
                    {
                        i++;
                    }
                    else
                    {
                        int tmps = a[i];
                        a[i++] = a[j];
                        a[j] = tmps;
                    }
                }
            }
            int tmp = a[i];
            a[i] = a[r];
            a[r] = tmp;
            return i;
        }

    }
}

