using GraphWorld.Search;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphWorld.MaxFlow
{
    class FordFulkerson<T> where T : IComparable
    {
        private DirectedGraph<T, int> _graph;

        public FordFulkerson(DirectedGraph<T, int> graph)
        {
            _graph = graph;
        }

        public int GetMaxFlow(DirectedGraphNode<T, int> start, DirectedGraphNode<T, int> end)
        {
            var maxFlow = 0;
            var augmentedPath = GetAugmentedPath(_graph, start, end);

            while(augmentedPath != null)
            {
                maxFlow = maxFlow + MakeResidualGraph(augmentedPath, start, end);

                augmentedPath = GetAugmentedPath(_graph, start, end);
            }

            return maxFlow;
        }

        public int MakeResidualGraph(List<WeightedEdge<DirectedGraphNode<T, int>, int>> path, DirectedGraphNode<T, int> start, DirectedGraphNode<T, int> end)
        {
            var min = path[0].Weight;

            foreach (var edge in path)
            {
                if (min < edge.Weight)
                    min = edge.Weight;
            }

            foreach (var edge in path)
            {
                edge.Weight = edge.Weight - min;

                var connectedEdge = edge.ToNode.ConnectedEdges.FirstOrDefault(e => e.ConnectedNode.CompareTo(edge.FromNode) == 0);

                if (connectedEdge != null)
                {
                    connectedEdge.Weight = connectedEdge.Weight + min;
                }
                else
                {
                    edge.ToNode.AddNeighbor(edge.FromNode, min);
                }
            }

            return min;
        }

        public List<WeightedEdge<DirectedGraphNode<T, int>, int>> GetAugmentedPath(DirectedGraph<T, int> graph, DirectedGraphNode<T, int> start, DirectedGraphNode<T, int> end)
        {
            var path = DepthFirstSearch<T, int>.SearchPath(graph, start, end, 0);

            return path;
        }
    }
}
