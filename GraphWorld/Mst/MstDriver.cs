using System;

namespace GraphWorld.Mst
{
    public class MstDriver
    {
        public static void DriverForPrimsAndKruskal()
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
