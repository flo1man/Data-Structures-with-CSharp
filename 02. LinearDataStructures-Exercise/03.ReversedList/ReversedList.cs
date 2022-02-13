namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int capacity;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            this.Capacity = capacity;
            this.items = new T[Capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[Count - index - 1];
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
                if (capacity < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(capacity));
                }
                capacity = value;
            }
        }

        public void Add(T item)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = item;
            Count++;
        }


        public bool Contains(T item)
        {
            foreach (var value in items)
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return Count - i - 1;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            if (items.Length == Count)
            {
                Resize();
            }

            for (int i = Count; i >= Count - index; i--)
            {
                items[i] = items[i - 1];
            }

            items[Count - index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            var indexToRemoveAt = this.IndexOf(item);

            if (indexToRemoveAt == -1)
            {
                return false;
            }

            this.RemoveAt(indexToRemoveAt);

            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = Count - 1 - index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            this.items[this.Count - 1] = default;
            Count--;

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void Resize()
        {
            T[] newArray = new T[items.Length * 2];
            Array.Copy(items, newArray, items.Length);
            items = newArray;
        }
        private bool EnsureNotEmpty()
        {
            if (Count == 0)
            {
                return true;
            }

            return false;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}