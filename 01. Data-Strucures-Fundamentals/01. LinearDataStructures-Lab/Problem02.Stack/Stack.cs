namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = top;
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

        public T Peek()
        {
            CheckIfStackIsEmpty();
            return top.Value;
        }

        public T Pop()
        {
            CheckIfStackIsEmpty();

            var currentNode = top;
            top = top.Next;
            Count--;
            return currentNode.Value;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = top;
            top = newNode;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = top;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
         => GetEnumerator();

        private void CheckIfStackIsEmpty()
        {
            if (top == null)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}