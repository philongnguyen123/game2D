using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text textScore;
    [SerializeField] private GameObject pausePanel, diePanel;
    [SerializeField] private Button resumeGame, Menu;
    private int Score;
    public static GameController sInstance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!sInstance)
        {
            sInstance = this;
        }
    }
    void Start()
    {
        Score = 0;
    }
    public void UpdateScore()
    {
        Score++;
        textScore.text = "Score: " + Score;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => ResumeGame());
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("MainMenu");
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("LevelMenu");
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f;
        diePanel.SetActive(true);
        Menu.onClick.RemoveAllListeners();
        Menu.onClick.AddListener(() => RestartGame());
    }
}
