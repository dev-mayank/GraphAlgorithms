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
            var augmentedPath = GetAugmentedPath(start,end);

            while(augmentedPath != null)
            {
                maxFlow = maxFlow + MakeResidualGraph(augmentedPath, start, end);

                augmentedPath = GetAugmentedPath(start, end);
            }

            return maxFlow;
        }

        public int MakeResidualGraph(List<WeightedEdge<DirectedGraphNode<T, int>, int>> path, DirectedGraphNode<T, int> start, DirectedGraphNode<T, int> end)
        {
            var min = path[0].Weight;

            foreach (var edge in path)
            {
                if (min > edge.Weight) 
                    min = edge.Weight;
            }

            var current = start;
            foreach (var edge in path)
            {
                foreach (var item in current.ConnectedEdges)
                { 
                    if(item.ConnectedNode.CompareTo(edge.ToNode) == 0)
                    {
                        item.Weight = item.Weight - min;
                        current = item.ConnectedNode;
                        break;
                    }
                }

                var reverseEdge = edge.ToNode.ConnectedEdges.FirstOrDefault(e => e.ConnectedNode.CompareTo(edge.FromNode) == 0);

                if (reverseEdge != null)
                {
                    reverseEdge.Weight = reverseEdge.Weight + min;
                }
                else
                {
                    if (edge.FromNode.CompareTo(start) != 0)
                    {
                        if (edge.ToNode.CompareTo(end) != 0)
                        {
                            edge.ToNode.AddNeighbor(edge.FromNode, min);
                        }
                    }
                }
            }

            return min;
        }

        public List<WeightedEdge<DirectedGraphNode<T, int>, int>> GetAugmentedPath(DirectedGraphNode<T, int> start, DirectedGraphNode<T, int> end)
        {
            Stack<ConnectedWeightedEdge<DirectedGraphNode<T, int>, int>> stack = new Stack<ConnectedWeightedEdge<DirectedGraphNode<T, int>, int>>();
            HashSet<ConnectedWeightedEdge<DirectedGraphNode<T, int>, int>> visitedPath = new HashSet<ConnectedWeightedEdge<DirectedGraphNode<T, int>, int>>();

            var path = new Stack<WeightedEdge<DirectedGraphNode<T, int>, int>>();

            var current = start;
            foreach (var edge in current.ConnectedEdges)
            {
                if (edge.Weight > 0)
                    stack.Push(edge);
            }

            while (stack.Count > 0)
            {
                var movingEdge = stack.Pop();
                path.Push(new WeightedEdge<DirectedGraphNode<T, int>, int>(current, movingEdge.ConnectedNode, movingEdge.Weight));

                current = movingEdge.ConnectedNode;

                var validConnedtedEdgesForPath = current.ConnectedEdges.Where(edge => edge.Weight > 0 && !visitedPath.Contains(edge)).ToList();

                if (validConnedtedEdgesForPath.Any())
                {
                    foreach (var edge in validConnedtedEdgesForPath)
                    {
                        visitedPath.Add(edge);
                        if (edge.ConnectedNode.CompareTo(end) == 0)
                        {
                            path.Push(new WeightedEdge<DirectedGraphNode<T, int>, int>(current, edge.ConnectedNode, edge.Weight));
                            return path.Reverse().ToList();
                        }
                        else
                        {
                            stack.Push(edge);
                        }
                    }
                }
                else
                {
                    var item = path.Pop();
                    current = item.FromNode;
                }
            }

            return null;
        }
    }
}
