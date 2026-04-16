using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int passengersDroppedOff;
    public TextMeshProUGUI myText;
    public LoseMenu loseMenu;

    public bool gamePaused = false;
    private bool pausable = true;
    private bool lost = false;

    //UI Menus
    public GameObject inGameUI;
    public GameObject pauseUI;
    public GameObject loseUI;

    private void Start()
    {
        Application.targetFrameRate = 144;
        QualitySettings.vSyncCount = 1;
    }

    private void Update()
    {
        myText.text = passengersDroppedOff.ToString();

        if (Input.GetKeyDown(KeyCode.Escape) && pausable)
            gamePaused = !gamePaused;

        if (gamePaused && !lost)
            PauseGame();
        else if (!gamePaused && !lost)
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
        Debug.Log("unpause");
        inGameUI.SetActive(true);
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Lose(int loseType)
    {
        lost = true;
        pausable = false;
        inGameUI.SetActive(false);
        loseUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        loseMenu.SetHeader(loseType);
    }
}
