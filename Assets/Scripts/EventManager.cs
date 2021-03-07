using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public GameObject ResetPanel;

    public Text HighScoreText;

    private void Start()
    {
        HighScoreText.text = "HighScore: " + PlayerPrefs.GetInt("highScore").ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenResetPanel()
    {
        ResetPanel.SetActive(true);
    }

    public void CloseResetPanel()
    {
        ResetPanel.SetActive(false);
    }
    
    public void ResetHighscore()
    {
        PlayerPrefs.SetInt("highScore", 0);
        HighScoreText.text = "HighScore: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
