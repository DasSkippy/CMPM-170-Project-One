using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int passengersDroppedOff;
    public TextMeshProUGUI myText;

    public bool gamePaused = false;

    //UI Menus
    public GameObject inGameUI;
    public GameObject pauseUI;
    public GameObject loseUI;

    private void Update()
    {
        myText.text = passengersDroppedOff.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
            gamePaused = !gamePaused;

        if (gamePaused)
            PauseGame();
        else
            UnpauseGame();
    }

    private void PauseGame()
    {
        inGameUI.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void UnpauseGame()
    {
        inGameUI.SetActive(true);
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Lose()
    {
        inGameUI.SetActive(false);
        loseUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
