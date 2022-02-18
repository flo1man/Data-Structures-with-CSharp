using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public interface IAbstractTree<T>
    {
        T Value { get; }
        Tree<T> Parent { get; }
        IReadOnlyCollection<Tree<T>> Children { get; }

        ICollection<T> OrderBfs();

        ICollection<T> OrderDfs();

        void AddChild(T parentKey, Tree<T> child);

        void RemoveNode(T nodeKey);

        void Swap(T firstKey, T secondKey);
    }
}
