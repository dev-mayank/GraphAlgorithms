using GraphWorld.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWorld.MaxFlow
{
    public class FordFulkersonDriver
    {
        public static void Drive()
        {
            var s = new DirectedGraphNode<string, int>("S");
            var a = new DirectedGraphNode<string, int>("A");
            var c = new DirectedGraphNode<string, int>("C");
            var d = new DirectedGraphNode<string, int>("D");
            var b = new DirectedGraphNode<string, int>("B");
            var t = new DirectedGraphNode<string, int>("T");

            DirectedGraph<string, int> graph = new DirectedGraph<string, int>()
            {
                Nodes = new List<DirectedGraphNode<string, int>>
                {
                    s, a, c, b, d, t
                }
            };

            graph.AddDirectedEdge(s, a, 10);
            graph.AddDirectedEdge(s, c, 10);
            graph.AddDirectedEdge(a, b, 4);
            graph.AddDirectedEdge(a, c, 2);
            graph.AddDirectedEdge(a, d, 8);
            graph.AddDirectedEdge(c, d, 9);
            graph.AddDirectedEdge(d, b, 6);
            graph.AddDirectedEdge(d, t, 10);
            graph.AddDirectedEdge(b, t, 10);

            var fordGraph = new FordFulkerson<string>(graph);

            var maxFlow = fordGraph.GetMaxFlow(s, t);

        }
    }
}
