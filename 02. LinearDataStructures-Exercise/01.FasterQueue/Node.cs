namespace Problem01.FasterQueue
{
    public class Node<T>
    {
        public Node(T item)
        {
            Item = item;
        }

        public T Item { get; set; }

        public Node<T> Next { get; set; }
    }
}