namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            if (head == null)
            {
                head = tail = new Node<T>(item);
            }
            else
            {
                Node<T> newNode = new Node<T>(item);

                var current = head;
                head = newNode;
                head.Next = current;
            }
            Count++;
        }

        public void AddLast(T item)
        {
            if (head == null)
            {
                head = tail = new Node<T>(item);
            }
            else
            {
                Node<T> newNode = new Node<T>(item);

                tail.Next = newNode;
                tail = newNode;
            }
            Count++;
        }

        public T GetFirst()
        {
            CheckIfEmpty();
            return head.Value;
        }

        public T GetLast()
        {
            CheckIfEmpty();
            return tail.Value;
        }

        public T RemoveFirst()
        {
            CheckIfEmpty();
            var removed = head;
            head = head.Next;
            Count--;
            return removed.Value;
        }

        public T RemoveLast()
        {
            CheckIfEmpty();

            if (Count == 1)
            {
                Node<T> result = head;
                head = null;
                Count--;
                return result.Value;
            }

            Node<T> current = head;

            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            Node<T> last = current.Next;
            current.Next = null;
            tail = current;
            Count--;
            return last.Value;
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
            => this.GetEnumerator();

        public void CheckIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Liked list is empty!");
            }
        }
    }
}