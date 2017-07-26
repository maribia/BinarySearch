using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            
            {
                Random rand = new Random((int)System.DateTime.Now.Ticks);
                int[] array = CreateArray();
                int searchIndex = rand.Next(0, array.Length);
                Console.WriteLine("search index = {0} and value = {1}", searchIndex, array[searchIndex]);
                int resultIndex = RecursiveBinarySearch<int>(array, array[searchIndex], 0, array.Length - 1);
                Console.WriteLine("result index = {0} and value = {1}", resultIndex, array[resultIndex]);
            }

            {
                Random rand = new Random((int)System.DateTime.Now.Ticks);
                int[] array = CreateArray();
                int searchIndex = rand.Next(0, array.Length);
                Console.WriteLine("search index = {0} and value = {1}", searchIndex, array[searchIndex]);
                int resultIndex = LoopBinarySearch<int>(array, array[searchIndex], 0, array.Length - 1);
                Console.WriteLine("result index = {0} and value = {1}", resultIndex, array[resultIndex]);
            }
        }

        /// <summary>
        /// int형 배열 생성
        /// 인덱스가 클수록 큰값이 들어가있는 형태
        /// </summary>
        /// <returns></returns>
        public static int[] CreateArray()
        {
            int maxLength = 1000;
            int[] array = new int[maxLength];
            Random rand = new Random();
            int value = 0;
            for (int i = 0; i < array.Length; i++)
            {
                value += rand.Next(0, 100);
                array[i] = value;
            }

            return array;
        }

        public static int RecursiveBinarySearch<T>(T[] array, T target, int min, int max) where T : IComparable<T>
        {
            
            int mid = (max - min) / 2 + min;
            int result = target.CompareTo(array[mid]);
            if(result != 0)
            {
                return result > 0 ? RecursiveBinarySearch(array, target, mid, max) : RecursiveBinarySearch(array, target, min, mid);
            }

            return mid;
        }

        public static int LoopBinarySearch<T>(T[] array, T target, int min, int max) where T : IComparable<T>
        {
            int? mid = null;
            int? result = null;
            do
            {
                mid = (max - min) / 2 + min;
                result = target.CompareTo(array[mid.Value]);
                max = result.Value < 0 ? mid.Value : max;
                min = result.Value > 0 ? mid.Value : min;
            } while (result != 0);



            return mid.Value;
        }
    }
}
