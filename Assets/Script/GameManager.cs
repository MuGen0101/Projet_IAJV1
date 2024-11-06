using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MouvPlayer playerMovement; // Référence vers le script de mouvement
    public Button startButton; // Référence vers le bouton UI
    public Button restartButton; // Référence vers le bouton Redémarrer

    void Start()
    {
        // Désactive le mouvement du joueur au démarrage
        playerMovement.enabled = false;
        

        // Ajoute un écouteur d'événement au bouton pour démarrer le jeu
        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);
    }

    // Méthode pour démarrer le jeu
    void StartGame()
    {
        playerMovement.enabled = true; // Active le script de mouvement
        restartButton.gameObject.SetActive(true); // Affiche le bouton Redémarrer

    }

    void RestartGame()
    {
        // Recharge la scène actuelle pour redémarrer le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
