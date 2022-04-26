using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    public int score;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;
    private void Awake()
    {
        Advertisement.Initialize("4617013");
        gameOverPanel.SetActive(false);
        highScoreText.text = "High Score : " + getHighScore().ToString();
    }

    public void increaseScore()
    {
        score += 1;
        scoreText.text = score.ToString();
        

        if(score > getHighScore())
        {
            PlayerPrefs.SetInt("highscore", score);
            highScoreText.text = "High Score : " + score.ToString();
        }
    }

    private int getHighScore()
    {
        highScore = PlayerPrefs.GetInt("highscore",0);
        return highScore;
    }

    public void BombHit()
    {
        Advertisement.Show();
        Time.timeScale = 0;

        gameOverPanel.SetActive(true);
        gameOverPanelScoreText.text = "Score : " + score.ToString();

        
    }
    
    public void RestartGame()
    {
        score = 0;
        scoreText.text = "0";

        gameOverPanel.SetActive(false);
        gameOverPanelScoreText.text = "0";

        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Inactive"))
        {
            Destroy(g);
        }


        Time.timeScale = 1;
    }
}
