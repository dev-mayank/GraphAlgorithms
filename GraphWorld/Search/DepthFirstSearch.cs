using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphWorld.Search
{
    public class DepthFirstSearch<T, Tw>
        where T : IComparable
        where Tw : IComparable
    {
        public static List<WeightedEdge<DirectedGraphNode<T, Tw>, Tw>> 
            SearchPath(DirectedGraph<T, Tw> graph, DirectedGraphNode<T, Tw> start, DirectedGraphNode<T, Tw> end, Tw weightThreshold)
        {
            Stack<ConnectedWeightedEdge<DirectedGraphNode<T, Tw>, Tw>> stack = new Stack<ConnectedWeightedEdge<DirectedGraphNode<T, Tw>, Tw>>();

            var path = new Stack<WeightedEdge<DirectedGraphNode<T, Tw>, Tw>>();

            var current = start;
            foreach (var edge in current.ConnectedEdges)
            {
                stack.Push(edge);
            }

            while (stack.Count > 0)
            {
                var movingEdge = stack.Pop();
                path.Push(new WeightedEdge<DirectedGraphNode<T, Tw>, Tw>(current, movingEdge.ConnectedNode, movingEdge.Weight));

                current = movingEdge.ConnectedNode;
                var validConnedtedEdgesForPath = current.ConnectedEdges.Where(edge => edge.Weight.CompareTo(weightThreshold) > 0).ToList();

                if (validConnedtedEdgesForPath.Any())
                {
                    foreach (var edge in validConnedtedEdgesForPath)
                    {
                        if (edge.ConnectedNode.CompareTo(end) == 0)
                        {
                            path.Push(new WeightedEdge<DirectedGraphNode<T, Tw>, Tw>(current, edge.ConnectedNode, movingEdge.Weight));
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
                    stack.Pop();
                    path.Pop();
                }
            }

            return null;
        }
    }
}
