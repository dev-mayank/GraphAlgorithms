using System.Collections.Generic;

namespace GraphWorld
{
    public class Node<T>
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
    }
}
