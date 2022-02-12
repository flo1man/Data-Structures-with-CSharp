namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = head;
            while (current != null)
            {
                if (item.Equals(current.Value))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            CheckIfQueueIsEmpty();

            var current = head;
            head = head.Next;
            Count--;
            return current.Value;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                var current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }
            Count++;
        }

        public T Peek()
        {
            CheckIfQueueIsEmpty();
            return head.Value;
        }


        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void CheckIfQueueIsEmpty()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
    }
}