using System;
using System.Collections.Generic;

namespace GraphWorld
{
    public class Node<T> where T : IComparable
    {
        public T Data { get; set; }
        public List<Node<T>> Neighbors { get; set; }

        public Node(T data)
        {
            Data = data;
            Neighbors = new List<Node<T>>();
        }

        public Node(T data, List<Node<T>> neighbors)
        {
            Data = data;
            Neighbors = neighbors;
        }

        public void AddNeighbor(T data)
        {
            Neighbors.Add(new Node<T>(data));
        }

        public void AddNeighbor(Node<T> neighborNode)
        {
            Neighbors.Add(neighborNode);
        }

        public void AddNeighborWithWeight<Tw>(T data, Tw Weight)
            where Tw : IComparable
        {
            Neighbors.Add(new Node<T>(data));
        }

        public int CompareTo(object node)
        {
            var n = node as Node<T>;

            try
            {
                return Data.CompareTo(n.Data);
            }
            catch(Exception e)
            {
                throw new Exception("Type not supported yet" + e.Message);
            }
        }
    }
}
