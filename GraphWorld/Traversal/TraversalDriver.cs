using System;

namespace GraphWorld.Traversal
{
    public class TraversalDriver
    {
        public static void DriverForBfsAndDfs()
        {
            var node1 = new Node<int>(1);
            var node2 = new Node<int>(2);
            var node3 = new Node<int>(3);
            var node4 = new Node<int>(4);
            var node5 = new Node<int>(5);

            UnWeightedGraph<int> graph = new UnWeightedGraph<int>();

            graph.AddNode(node1, node2, node3, node4, node5);

            graph.AddEdge(node1, node3);
            graph.AddEdge(node1, node5);
            graph.AddEdge(node2, node4);
            graph.AddEdge(node3, node4);

            var bfsList = BFS.GraphTraverse(graph, node2);

            Console.WriteLine("BFS");
            for (int i = 0; i < bfsList.Count; i++)
            {
                Console.Write(bfsList[i].Data + " ");
            }

            Console.WriteLine("\nDFS");

            var dfsList = DFS.GraphTraverse(graph, node2);
            for (int i = 0; i < bfsList.Count; i++)
            {
                Console.Write(dfsList[i].Data + " ");
            }
        }
    }
}
