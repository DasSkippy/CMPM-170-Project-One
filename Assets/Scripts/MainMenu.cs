using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Collections.AllocatorManager;

public class MainMenu : MonoBehaviour
{
    public AudioClip click;
    public GameObject menu, credits;
    public void StartGame()
    {
        SceneManager.LoadScene("CityScene");
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(click);
    }

    public void Credits()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(click);
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(click);
    }

    public void Back()
    {
        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(click);
        menu.SetActive(true);
        credits.SetActive(false);
    }
}
