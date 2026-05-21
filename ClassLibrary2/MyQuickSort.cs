using System;

namespace MyQuickSortProject
{
    public class MyQuickSort<T> where T : IComparable<T>
    {
        public void Sort(T[] items)
        {
            if (items == null || items.Length <= 1)
                return;

            QuickSort(items, 0, items.Length - 1);
        }

        private void QuickSort(T[] items, int left, int right)
        {
            if (left >= right)
                return;

            int pivotIndex = Partition(items, left, right);

            QuickSort(items, left, pivotIndex - 1);
            QuickSort(items, pivotIndex + 1, right);
        }

        private int Partition(T[] items, int left, int right)
        {
            T pivot = items[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (items[j].CompareTo(pivot) < 0)
                {
                    i++;
                    Swap(items, i, j);
                }
            }

            Swap(items, i + 1, right);
            return i + 1;
        }

        private void Swap(T[] items, int i, int j)
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
    }
}