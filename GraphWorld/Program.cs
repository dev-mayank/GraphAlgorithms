using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new Node<int>(1);
            var node2 = new Node<int>(2);
            var node3 = new Node<int>(3);
            var node4 = new Node<int>(4);
            var node5 = new Node<int>(5);

            Connect(node1, node3);
            Connect(node1, node5);
            Connect(node2, node4);
            Connect(node3, node4);

            Graph<int> graph = new Graph<int>
            {
                Nodes = new List<Node<int>>
                {
                    node1, node2, node3, node4, node5
                }
            };

            BFS.GraphTraverse(graph, node2);
            Console.ReadKey();
        }

        public static void Connect<T>(Node<T> nodeA, Node<T> nodeB)
        {
            nodeA.AddNeighbor(nodeB);
            nodeB.AddNeighbor(nodeA);
        }
    }
}