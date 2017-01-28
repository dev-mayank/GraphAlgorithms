using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphWorld
{
    public class Prims<T, Tw>
           where Tw : IComparable
           where T : IComparable
    {
        private Heap<WeightedEdge<Node<T>, Tw>> _heap = new Heap<WeightedEdge<Node<T>, Tw>>();
        private HashSet<Node<T>> _visited = new HashSet<Node<T>>();
        private List<WeightedEdge<Node<T>, Tw>> _mstEdges = new List<WeightedEdge<Node<T>, Tw>>();

        public List<WeightedEdge<Node<T>, Tw>> GetMST(WeightedGraph<T, Tw> weightedGraph)
        {
            var currentNode = weightedGraph.Nodes[0];

            _visited.Add(currentNode);

            while (true)
            {
                //TODO: Need to optimize this
                var edgesConnectingCurrentNode = weightedGraph.Edges.Where(
                    edge => edge.NodeOne.Data.CompareTo(currentNode.Data) == 0
                            || edge.NodeTwo.Data.CompareTo(currentNode.Data) == 0).ToList();

                foreach (var edge in edgesConnectingCurrentNode)
                {
                    _heap.AddItem(edge);
                }

                var min = GetMinimunUnVisitedNodeFromHeap();

                if (min == null)
                    break;

                _visited.Add(min);
                currentNode = min;
            }

            return _mstEdges;
        }

        private Node<T> GetMinimunUnVisitedNodeFromHeap()
        {
            WeightedEdge<Node<T>, Tw> minEdge;

            while (!_heap.IsEmpty())
            {
                minEdge = _heap.Poll();

                var isNodeOneVisited = _visited.Contains(minEdge.NodeOne);
                var isNodeTwoVisited = _visited.Contains(minEdge.NodeTwo);

                if (isNodeOneVisited || isNodeTwoVisited)
                {
                    if (isNodeOneVisited && isNodeTwoVisited)
                    {
                        continue;
                    }
                    else if (isNodeOneVisited)
                    {
                        _mstEdges.Add(minEdge);
                        return minEdge.NodeTwo;
                    }
                    else
                    {
                        _mstEdges.Add(minEdge);
                        return minEdge.NodeOne;
                    }
                }
            }

            return null;
        }
    }
}