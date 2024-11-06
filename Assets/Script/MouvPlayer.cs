using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MouvPlayer : MonoBehaviour
{
    public AStarManager aStarManager;
    public float moveSpeed = 3f;
    public TextMeshProUGUI finishText; // Ajoute le champ pour afficher le message
    private List<Node> path;
    private int pathIndex = 0;
    private float pathScore = 0f; // Score total du chemin

    void Start()
    {
        path = aStarManager.FindPath();
        if (path == null || path.Count == 0)
        {
            Debug.LogWarning("Chemin introuvable !");
        }
        else
        {
            transform.position = path[0].transform.position;
            finishText.text = ""; // Efface le texte au démarrage
        }
    }

    void Update()
    {
        if (path == null || pathIndex >= path.Count)
            return;

        Node targetNode = path[pathIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetNode.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetNode.transform.position) < 0.1f)
        {
            // Calcule la distance entre les nœuds pour le score
            if (pathIndex > 0)
                pathScore += Vector3.Distance(path[pathIndex - 1].transform.position, targetNode.transform.position);

            pathIndex++;

            // Affiche le message si le joueur atteint le dernier nœud
            if (pathIndex >= path.Count)
            {
                finishText.text = $"Vous avez atteint la sortie !  " + $"Score du chemin : {pathScore:F2}";
            }
        }
    }
}