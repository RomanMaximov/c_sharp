using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting
{
    class Sort
    {
        private int NumPos(int number)                              // define a count of positions of integer
        {
            int count = 0;
            if (number < 0)
                number = -number;

            while (true)
            {
                number /= 10;
                ++count;
                if (number == 0) break;
            }

            return count;
        }

        private int MinNum(ref List<int> v)                   // define min negative integer in array
        {
            int min_number = 0;
            foreach (var x in v)
            {
                if (x < min_number)
                    min_number = x;
            }
            return min_number;
        }

        private int MaxNum(ref List<int> v)                   // define max positive integer in array
        {
            int max_number = 0;
            foreach (var x in v)
            {
                if (x > max_number)
                    max_number = x;
            }
            return max_number;
        }

        public void arrPrint(ref List<int> v, int x)
        {
            for (int i = 0; i < v.Count(); i += x)
                Console.Write(v[i] + " ");
        }

        public void QuickSort(ref List<int> arr, int low, int high)
        {
            int i = low;
            int j = high - 1;
            int temp;
            do
            {
                while (j > i)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        ++i;
                        break;
                    }
                    --j;
                }
                while (i < j)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        --j;
                        break;
                    }
                    ++i;
                }
            } while (i < j);

            if (i < high - 1)
                QuickSort(ref arr, i + 1, high);
            if (low < j - 1)
                QuickSort(ref arr, low, j);

        }

        public void BubbleSort(ref List<int> v)                   // bubble sort
        {
            int i, j, temp;
            for (i = 0; i < v.Count(); i++)
            {
                for (j = 0; j < (v.Count() - i - 1); j++)
                {
                    if (v[j] > v[j + 1])
                    {
                        temp = v[j];
                        v[j] = v[j + 1];
                        v[j + 1] = temp;
                    }
                }
            }
        }

        public void BucketSort(ref List<int> v)     // bucketsort - only for INTEGERS!!!
        {
            // create 2 arrays for negative and positive integers of origin array
            List<int> pos = new List<int>();
            List<int> neg = new List<int>();
            foreach (var x in v)
            {
                if (x < 0)
                    neg.Add(x);
                else
                    pos.Add(x);
            }

            // ======================= sorting negative numbers ================================
            // create two-dimentional array
            List<List<int>> neg_nums = new List<List<int>>();
            for (int i = 0; i < 10; ++i)
            {
                neg_nums.Add(new List<int>(neg));
                for (int k = 0; k < neg.Count(); ++k)
                    neg_nums[i][k] = 0;
            }

            // define min nagative integer
            int min_number = MinNum(ref neg);

            // define a count of positions of negative integer
            int number_position = NumPos(min_number);

            int num;
            int sum;
            int div_step = 0;
            int step = 1;
            int decade;
            int index;
            int j;

            // bucket sort of negative numbers
            for (decade = 1; decade <= number_position; ++decade)
            {
                j = 0;
                num = 0;
                for (int i = 0; i < neg.Count(); ++i)
                {
                    sum = (int)Math.Pow(10, step);
                    index = (int)(Math.Abs(neg[i]) % sum / Math.Pow(10, div_step));
                    neg_nums[index][j++] = neg[i];
                }
                ++step;
                ++div_step;

                for (int i = 0; i < 10; i++)
                {
                    for (j = 0; j < neg.Count(); j++)
                    {
                        if (neg_nums[i][j] < 0)
                        {
                            neg[num++] = neg_nums[i][j];
                            neg_nums[i][j] = 0;
                        }
                    }
                }
            }

            //================================= sorting positive numbers ==============================================
            // create two-dimentional array
            List<List<int>> pos_nums = new List<List<int>>();
            for (int i = 0; i < 10; ++i)
            {
                pos_nums.Add(new List<int>(pos));
                for (int k = 0; k < pos.Count(); ++k)
                    pos_nums[i][k] = -1;
            }

            // define max positive integer
            int max_number = MaxNum(ref pos);

            // define a count of position of positive integer
            number_position = NumPos(max_number);

            div_step = 0;
            step = 1;

            // block sort of positive numbers
            for (decade = 1; decade <= number_position; ++decade)
            {
                j = 0;
                num = 0;
                for (int i = 0; i < pos.Count(); i++)
                {
                    sum = (int)Math.Pow(10, step);
                    index = (int)(pos[i] % sum / Math.Pow(10, div_step));
                    pos_nums[index][j++] = pos[i];
                }
                ++step;
                ++div_step;

                for (int i = 0; i < 10; i++)
                {
                    for (j = 0; j < pos.Count(); j++)
                    {
                        if (pos_nums[i][j] != -1)
                        {
                            pos[num++] = pos_nums[i][j];
                            pos_nums[i][j] = -1;
                        }
                    }
                }
            }

            // join sorted negative and sorted positive integers in origin array 
            num = 0;
            for (int i = neg.Count() - 1; i >= 0; i--)
            {
                v[num++] = neg[i];
            }
            for (int i = 0; i < pos.Count(); i++)
            {
                v[num++] = pos[i];
            }
        }
    }
}
