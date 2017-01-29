using System;
using System.Collections.Generic;

namespace GraphWorld
{
    public class BFS
    {
        public static List<Node<T>> GraphTraverse<T>(UnWeightedGraph<T> graph, Node<T> startingNode = null)
            where T : IComparable
        {
            List<Node<T>> bfsList = new List<Node<T>>();
            Queue<Node<T>> queue = new Queue<Node<T>>();
            HashSet<T> visited = new HashSet<T>();

            if (startingNode == null)
                startingNode = graph.Nodes[0];

            queue.Enqueue(startingNode);

            while(queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                foreach (var node in currentNode.Neighbors)
                {
                    if (!visited.Contains(node.Data))
                        queue.Enqueue(node);
                }

                visited.Add(currentNode.Data);
                bfsList.Add(currentNode);
            }
            return bfsList;
        }
    }
}
