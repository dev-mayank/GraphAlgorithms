using System;
using System.Collections.Generic;

namespace GraphWorld
{
    public class DFS
    {
        public static List<Node<T>> GraphTraverse<T>(UnWeightedGraph<T> graph, Node<T> startingNode = null)
            where T: IComparable
        {
            List<Node<T>> dfsList = new List<Node<T>>();
            Stack<Node<T>> stack = new Stack<Node<T>>();
            HashSet<T> visited = new HashSet<T>();
            Node<T> currentNode;

            if (startingNode == null)
                startingNode = graph.Nodes[0];

            stack.Push(startingNode);

            while (stack.Count > 0)
            {
                currentNode = stack.Pop();
                foreach (var node in currentNode.Neighbors)
                {
                    if (!visited.Contains(node.Data))
                        stack.Push(node);
                }
                visited.Add(currentNode.Data);
                dfsList.Add(currentNode);
            }
            return dfsList;
        }
    }
}
