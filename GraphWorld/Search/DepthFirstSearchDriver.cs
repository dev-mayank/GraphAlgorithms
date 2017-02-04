using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWorld.Search
{
    public class SearchDriver
    {
        public static void DriverForDepthFirstSearch()
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

            var path = DepthFirstSearch<string, int>.SearchPath(graph, s, t, 0);

            bool flag = true;
            foreach (var item in path)
            {
                if (flag)
                {
                    Console.Write(item.FromNode.Data + "  -->  " + item.ToNode.Data);
                    flag = false;
                }
                else
                {
                    Console.Write("  -->  " + item.ToNode.Data);
                }
            }
        }
    }
}
