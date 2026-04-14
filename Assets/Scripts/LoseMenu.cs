using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseMenu : MonoBehaviour
{
    private GameManager gameManager;
    // Score Texts
    public TextMeshProUGUI myScoreText;
    public TextMeshProUGUI highScoreText;
    // HeaderText
    public TextMeshProUGUI headerText;

    public GameObject drunkUI, damageUI;

    int highScore;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        myScoreText.text = "You Dropped Off " + gameManager.passengersDroppedOff + " Passengers!";
    }

    public void SetHeader(int deathVersion)
    {
        // 0 is drunk
        // 1 is damage
        if (deathVersion == 0)
        {
            headerText.text = "You Got Sober!\nYou Lose!";
            drunkUI.SetActive(true);
            damageUI.SetActive(false);
        }
        else if (deathVersion == 1)
        {
            headerText.text = "You Totaled Your Car!\nYou Lose!";
            drunkUI.SetActive(false);
            damageUI.SetActive(true);
        }
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
