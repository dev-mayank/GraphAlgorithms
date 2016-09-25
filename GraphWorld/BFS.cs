using System.Collections.Generic;

namespace GraphWorld
{
    public class BFS
    {
        public static List<Node<T>> GraphTraverse<T>(Graph<T> graph, Node<T> startingNode = null)
        {
            List<Node<T>> bfsList = new List<Node<T>>();
            Queue<Node<T>> queue = new Queue<Node<T>>();
            HashSet<Node<T>> visited = new HashSet<Node<T>>();

            if (startingNode == null)
                startingNode = graph.Nodes[0];

            queue.Enqueue(startingNode);

            while(queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                foreach (var node in currentNode.Neighbors)
                {
                    if (!visited.Contains(node))
                        queue.Enqueue(node);
                }

                visited.Add(currentNode);
                bfsList.Add(currentNode);
            }
            return bfsList;
        }
    }
}
