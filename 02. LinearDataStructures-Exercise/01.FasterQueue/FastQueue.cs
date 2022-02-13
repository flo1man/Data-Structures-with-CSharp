namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.Item.Equals(item))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            EnsureNotEmpty();
            var currentHead = head;
            head = head.Next;
            Count--;
            return currentHead.Item;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (head == null)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = tail.Next;
            }
            Count++;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return this.head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = head;

            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}