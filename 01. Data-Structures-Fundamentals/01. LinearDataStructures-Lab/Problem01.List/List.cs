namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;
        private int capacity;

        public List()
            : this(DEFAULT_CAPACITY) 
        {
            items = new T[DEFAULT_CAPACITY];
        }

        public List(int capacity)
        {
            this.Capacity = capacity;
            items = new T[Capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity cannot be negative!");
                }
                capacity = value;
            }
        }

        public void Add(T item)
        {
            CheckIfArrayIsFull();

            items[Count] = item;
            Count++;
        }


        public bool Contains(T item)
        {
            foreach (var curr in items)
            {
                if (item.Equals(curr))
                {
                    return true;
                }
            }
            return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (item.Equals(items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            CheckIfArrayIsFull();

            for (int i = Count; i >= index; i--)
            {
                items[i] = items[i - 1];
            }
            items[index] = item;
            Count++;

        }

        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }

            for (int i = IndexOf(item); i < Count; i++)
            {
                items[i] = items[i + 1];
            }
            Count--;
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void CheckIfArrayIsFull()
        {
            if (Count == items.Length)
            {
                T[] newArr = new T[items.Length * 2];

                Array.Copy(items, newArr, items.Length);

                items = newArr;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }
        }
    }
}