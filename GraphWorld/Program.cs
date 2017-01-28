using System;

namespace GraphWorld
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var node1 = new Node<int>(1);
        //    var node2 = new Node<int>(2);
        //    var node3 = new Node<int>(3);
        //    var node4 = new Node<int>(4);
        //    var node5 = new Node<int>(5);

        //    Graph<int> graph = new Graph<int>();

        //    graph.AddNode(node1, node2, node3, node4, node5);

        //    graph.AddEdge(node1, node3);
        //    graph.AddEdge(node1, node5);
        //    graph.AddEdge(node2, node4);
        //    graph.AddEdge(node3, node4);

        //    var bfsList = BFS.GraphTraverse(graph, node2);

        //    Console.WriteLine("BFS");
        //    for (int i = 0; i < bfsList.Count; i++)
        //    {
        //        Console.Write(bfsList[i].Data + " ");
        //    }

        //    Console.WriteLine("\nDFS");

        //    var dfsList = DFS.GraphTraverse(graph, node2);
        //    for (int i = 0; i < bfsList.Count; i++)
        //    {
        //        Console.Write(dfsList[i].Data + " ");
        //    }
        //}

        //Prim's Algorithm
        public static void Main()
        {
            var node_A = new Node<string>("A");
            var node_B = new Node<string>("B");
            var node_C = new Node<string>("C");
            var node_D = new Node<string>("D");
            var node_T = new Node<string>("T");
            var node_S = new Node<string>("S");

            var graph = new WeightedGraph<string, int>();

            graph.AddNode(node_A, node_B, node_C, node_D, node_T, node_S);

            graph.AddWeightedEdge(node_A, node_S, 7);
            graph.AddWeightedEdge(node_A, node_B, 6);
            graph.AddWeightedEdge(node_A, node_C, 3);
            graph.AddWeightedEdge(node_C, node_S, 8);
            graph.AddWeightedEdge(node_C, node_D, 3);
            graph.AddWeightedEdge(node_C, node_B, 4);
            graph.AddWeightedEdge(node_D, node_T, 2);
            graph.AddWeightedEdge(node_D, node_B, 2);
            graph.AddWeightedEdge(node_B, node_T, 4);

            Console.WriteLine("\n Prims \n");

            Prims<string, int> prim = new Prims<string, int>();

            var mstEdges = prim.GetMST(graph);

            foreach (var item in mstEdges)
            {
                Console.WriteLine(item.NodeOne.Data + " ---- " + item.NodeTwo.Data + " --->  " + item.Weight);
            }

            Console.WriteLine("\n Kruskals \n");

            Kruskals<string, int> kruskal = new Kruskals<string, int>();

            mstEdges = kruskal.GetMST(graph);

            foreach (var item in mstEdges)
            {
                Console.WriteLine(item.NodeOne.Data + " ---- " + item.NodeTwo.Data + " --->  " + item.Weight);
            }

            Console.ReadKey();
        }
    }
}