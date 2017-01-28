using System;

namespace GraphWorld
{
    public class Edge<T>
    {
        public T NodeOne { get; set; }
        public T NodeTwo { get; set; }

        public Edge(T first, T second)
        {
            NodeOne = first;
            NodeTwo = second;
        }
    }

    public class WeightedEdge<T, Tw> : Edge<T>, IComparable
        where Tw : IComparable
    {
        public Tw Weight { get; private set; }

        public WeightedEdge(T first, T second, Tw weight) : base(first, second)
        {
            Weight = weight;
        }

        public int CompareTo(object edge)
        {
            var e = edge as WeightedEdge<T, Tw>;
            return Weight.CompareTo(e.Weight);
        }
    }
}
