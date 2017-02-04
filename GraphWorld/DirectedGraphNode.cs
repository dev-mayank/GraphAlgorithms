using System;
using System.Collections.Generic;

namespace GraphWorld
{
    public class DirectedGraphNode<T, Tw> : Node<T>, IComparable
        where T : IComparable
        where Tw : IComparable
    {
        public List<ConnectedWeightedEdge<DirectedGraphNode<T, Tw>, Tw>> ConnectedEdges { get; set; }

        public DirectedGraphNode(T data) : base(data)
        {
            ConnectedEdges = new List<ConnectedWeightedEdge<DirectedGraphNode<T, Tw>, Tw>>();
        }

        public void AddNeighbor(DirectedGraphNode<T, Tw> node, Tw weight)
        {
            AddNeighbor(node);
            ConnectedEdges.Add(new ConnectedWeightedEdge<DirectedGraphNode<T, Tw>, Tw>(node, weight));
        }

        public void AddNeighbor(T data, Tw weight)
        {
            var node = new DirectedGraphNode<T, Tw>(data);
            AddNeighbor(node, weight);
        }

        //public new int CompareTo(object obj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
