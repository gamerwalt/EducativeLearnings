using System;

namespace Fundamentals.Arrays
{
    /// <summary>
    /// Lookup - O(n)
    /// Insert - O(n)
    /// Delete - O(1) or O(n) (O(n) if you're not deleting at the end of the array)
    /// </summary>
    public class Arrays
    {
        public int[] Items;
        public int count;

        public Arrays(int capacity)
        {
            Items = new int[capacity];
        }

        public void Insert(int item)
        {
            if (count == Items.Length)
            {
                var newItems = new int[count * 2];
                Array.Copy(Items, newItems, count);
                Items = newItems;
            }

            Items[count] = item;

            count++;
        }
    }
}
