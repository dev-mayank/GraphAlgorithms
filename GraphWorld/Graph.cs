using System.Collections.Generic;

namespace GraphWorld
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes { get; set; }

        public Graph()
        {
            Nodes = new List<Node<T>>();
        }
    }
}
