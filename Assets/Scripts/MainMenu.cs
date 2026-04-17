using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("CityScene");
    }

    public void Credits()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
