using System;
using System.Collections.Generic;

namespace GraphWorld
{
    public class Graph<T>
        where T : IComparable
    {
        public List<Node<T>> Nodes { get; set; }

        public Graph()
        {
            Nodes = new List<Node<T>>();
        }

        public void AddNode(params Node<T>[] nodes)
        {
            foreach (var item in nodes)
            {
                Nodes.Add(item);
            }
        }
    }

    public class UnWeightedGraph<T> : Graph<T>
        where T: IComparable
    {
        public List<Edge<T>> Edges { get; set; }

        public UnWeightedGraph()
        {
            Edges = new List<Edge<T>>();
        }

        public void AddEdge(Node<T> nodeA, Node<T> nodeB)
        {
            nodeA.AddNeighbor(nodeB);
            nodeB.AddNeighbor(nodeA);
        }
    }

    public class WeightedGraph<T, Tw> : Graph<T>
        where Tw : IComparable
        where T : IComparable
    {
        public List<WeightedEdge<Node<T>, Tw>> Edges { get; set; }

        public WeightedGraph()
        {
            Edges = new List<WeightedEdge<Node<T>, Tw>>();
        }

        public void AddWeightedEdge(Node<T> nodeA, Node<T> nodeB, Tw weight)
        {
            nodeA.AddNeighbor(nodeB);
            nodeB.AddNeighbor(nodeA);
            Edges.Add(new WeightedEdge<Node<T>, Tw>(nodeA, nodeB, weight));
        }
    }
}
