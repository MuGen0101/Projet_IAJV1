using System.Collections.Generic;
using UnityEngine;

public class AStarManager : MonoBehaviour
{
    public Node startNode;
    public Node targetNode;
    private List<Node> openSet = new List<Node>();
    private HashSet<Node> closedSet = new HashSet<Node>();

    public List<Node> FindPath()
    {
        openSet.Clear();
        closedSet.Clear();
        openSet.Add(startNode);

        startNode.gScore = 0;
        startNode.hScore = GetDistance(startNode, targetNode);
        startNode.cameFrom = null;

        while (openSet.Count > 0)
        {
            Node currentNode = GetLowestFScoreNode();
            if (currentNode == targetNode)
            {
                return RetracePath(startNode, targetNode);
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            foreach (Node neighbor in currentNode.connections)
            {
                if (closedSet.Contains(neighbor) || !neighbor.isWalkable)
                    continue;

                float tentativeGScore = currentNode.gScore + GetDistance(currentNode, neighbor);
                if (tentativeGScore < neighbor.gScore || !openSet.Contains(neighbor))
                {
                    neighbor.gScore = tentativeGScore;
                    neighbor.hScore = GetDistance(neighbor, targetNode);
                    neighbor.cameFrom = currentNode;

                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        return null; // Aucun chemin trouvé
    }

    private Node GetLowestFScoreNode()
    {
        Node lowestFScoreNode = openSet[0];
        foreach (var node in openSet)
        {
            if (node.FScore() < lowestFScoreNode.FScore())
                lowestFScoreNode = node;
        }
        return lowestFScoreNode;
    }

    private float GetDistance(Node a, Node b)
    {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }

    private List<Node> RetracePath(Node start, Node end)
    {
        List<Node> path = new List<Node>();
        Node currentNode = end;

        while (currentNode != start)
        {
            path.Add(currentNode);
            currentNode = currentNode.cameFrom;
        }
        path.Reverse();
        return path;
    }
}
