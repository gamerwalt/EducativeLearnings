using System;

namespace Fundamentals
{
    /// <summary>
    /// Lookup - O(n) or O(1)
    /// Insert - O(n)
    /// Delete - O(1) or O(n) (O(n) if you're not deleting at the end of the array)
    /// </summary>
    public class Arrays
    {
        private int[] Items;
        private int count;

        public Arrays(int capacity)
        {
            Items = new int[capacity];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException();

            if (index == count - 1)
            {
                Items[index] = 0;
                count--;
            }
            else
            {
                for(int i = index; i<Items.Length-1; i++)
                {
                    Items[i] = Items[i + 1];
                }

                count--;
            }
                
        }

        public int IndexOf(int item)
        {
            for(int i = 0; i<count; i++)
            {
                if (Items[i] == item) return i;
            }

            return -1;
        }

        public void Print()
        {
            for(int i = 0; i<count; i++)
            {
                Console.WriteLine(Items[i]);
            }
        }

        public void Insert(int item)
        {
            if (count == Items.Length)
            {
                var newItems = new int[count * 2];
                for(int i = 0; i<count; i++)
                {
                    newItems[i] = Items[i];
                }
                Items = newItems;
            }

            Items[count] = item;

            count++;
        }
    }
}
