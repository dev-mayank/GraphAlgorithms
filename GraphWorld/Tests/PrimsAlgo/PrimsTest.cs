using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWorld.Tests.PrimsAlgo
{
    [TestClass]
    public class PrimsTest
    {
        [TestMethod]
        public void GetPrimMST()
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

            Prims<string, int> prim = new Prims<string, int>();

            prim.GetMST(graph);
        }
    }
}
