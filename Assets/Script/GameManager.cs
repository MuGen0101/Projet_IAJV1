using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MouvPlayer playerMovement; // R�f�rence vers le script de mouvement
    public Button startButton; // R�f�rence vers le bouton UI
    public Button restartButton; // R�f�rence vers le bouton Red�marrer

    void Start()
    {
        // D�sactive le mouvement du joueur au d�marrage
        playerMovement.enabled = false;
        

        // Ajoute un �couteur d'�v�nement au bouton pour d�marrer le jeu
        startButton.onClick.AddListener(StartGame);
        restartButton.onClick.AddListener(RestartGame);
    }

    // M�thode pour d�marrer le jeu
    void StartGame()
    {
        playerMovement.enabled = true; // Active le script de mouvement
        restartButton.gameObject.SetActive(true); // Affiche le bouton Red�marrer

    }

    void RestartGame()
    {
        // Recharge la sc�ne actuelle pour red�marrer le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
