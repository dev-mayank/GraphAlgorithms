using System;
using System.Collections.Generic;

namespace GraphWorld
{
    public class Kruskals<T, Tw>
        where T : IComparable
        where Tw: IComparable
    {
        private List<WeightedEdge<Node<T>, Tw>> _mstEdges = new List<WeightedEdge<Node<T>, Tw>>();
        private List<HashSet<Node<T>>> _visitedLists = new List<HashSet<Node<T>>>();

        public List<WeightedEdge<Node<T>, Tw>> GetMST(WeightedGraph<T, Tw> weightedGraph)
        {
            var edges = weightedGraph.Edges.ToArray();
            Array.Sort(edges);

            foreach (var edge in edges)
            {
                int nodeOneVisitedSetIndex;
                int nodeTwoVisitedSetIndex;

                var isNodeOneVisited = TryGetVisitedSetOfNode(edge.NodeOne, out nodeOneVisitedSetIndex);
                var isNodeTwoVisited = TryGetVisitedSetOfNode(edge.NodeTwo, out nodeTwoVisitedSetIndex);

                if (isNodeOneVisited || isNodeTwoVisited)
                {
                    if (isNodeOneVisited && isNodeTwoVisited)
                    {
                        if(nodeTwoVisitedSetIndex == nodeOneVisitedSetIndex)
                        {
                            continue;
                        }
                        else
                        {
                            _mstEdges.Add(edge);
                            _visitedLists[nodeTwoVisitedSetIndex].UnionWith(_visitedLists[nodeOneVisitedSetIndex]);
                            _visitedLists.RemoveAt(nodeOneVisitedSetIndex);
                        }
                    }
                    else
                    {
                        if (isNodeOneVisited)
                        {
                            _visitedLists[nodeOneVisitedSetIndex].Add(edge.NodeTwo);
                        }
                        else
                        {
                            _visitedLists[nodeTwoVisitedSetIndex].Add(edge.NodeOne);
                        }
                        _mstEdges.Add(edge);
                    }
                }
                else
                {
                    _visitedLists.Add(new HashSet<Node<T>>()
                    {
                        edge.NodeOne,
                        edge.NodeTwo
                    }
                    );

                    _mstEdges.Add(edge);
                }
            }
            return _mstEdges;
        }

        private bool TryGetVisitedSetOfNode(Node<T> node, out int visitedSetIndex)
        {
            //TODO : Optimize this
            for (int i = 0; i < _visitedLists.Count; i++)
            {
                if (_visitedLists[i].Contains(node))
                {
                    visitedSetIndex = i;
                    return true;
                }
            }
            visitedSetIndex = -1;
            return false;
        }

    }
}
