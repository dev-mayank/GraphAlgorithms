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
        public Tw Weight { get; set; }
        public T FromNode
        {
            get
            {
                return NodeOne;
            }
        }

        public T ToNode
        {
            get
            {
                return NodeTwo;
            }
        }

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

    public class ConnectedWeightedEdge<T, Tw>
        where Tw : IComparable
    {
        public T ConnectedNode { get; set; }
        public Tw Weight { get; set; }

        public ConnectedWeightedEdge(T connectedNode, Tw weight)
        {
            ConnectedNode = connectedNode;
            Weight = weight;
        }
    }

}
