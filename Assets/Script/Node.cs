using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> connections = new List<Node>(); // Connexions avec les autres noeuds
    public float gScore = float.MaxValue; // Distance depuis le point de d�part
    public float hScore; // Estimation jusqu'au point d'arriv�e
    public Node cameFrom; // Noeud parent pour retracer le chemin
    public bool isWalkable = true; // Indique si le noeud est accessible

    public float FScore() => gScore + hScore; // FScore utilis� par l'algorithme A*

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (Node connection in connections)
        {
            Gizmos.DrawLine(transform.position, connection.transform.position);
        }
    }
}
