using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    public void Resume()
    {
        gameManager.gamePaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("CityScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
