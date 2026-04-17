using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameManager gameManager;
    public AudioClip click;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    public void Resume()
    {
        gameManager.gamePaused = false;
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(click);
    }

    public void Restart()
    {
        SceneManager.LoadScene("CityScene");
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(click);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(click);
    }
}
