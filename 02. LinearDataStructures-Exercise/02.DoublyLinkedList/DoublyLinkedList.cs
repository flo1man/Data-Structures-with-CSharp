namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newHead = new Node<T>(item);

            if (head == null)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.Next = head;
                head.Previous = newHead;
                head = newHead;
            }
            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (head == null)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();

            return head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            return tail.Item;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            var currentHead = head;
            head = head.Next;
            Count--;
            return currentHead.Item;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            var currentTail = tail;
            tail = tail.Previous;
            Count--;
            return currentTail.Item;
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