using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.NetworkInformation;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text hsText;
    public GameObject GameOverScreen;
    private bool gameOverVariable = false;
    public int highScore;
    public string highScoreText;
    public float itemCooldown = 5f;
    public bool isTimeActive = false;
    public bool isInvertedActive = false;
    public bool isHighGravityActive = false;
    public bool isAlternateGravityActive = false;
    public bool isShortPipe = false;
    public bool isGameOverSound = true;

    [ContextMenu("Increase Score")]
    public void addScore(int ScoreToAdd)
    {
        if (!gameOverVariable)
        {
            FindObjectOfType<AudioManager>().Play("increasePoint");
            highScore = PlayerPrefs.GetInt("highScore");
            playerScore += ScoreToAdd;
            scoreText.text = playerScore.ToString();
        }

        if (playerScore > highScore)
        {
            highScore = playerScore;
        }

        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.Save();
        highScore = PlayerPrefs.GetInt("highScore");

    }

    public void restartGame()
    {
        FindObjectOfType<AudioManager>().Play("clickButton");
        StartCoroutine(addGameOverScreen());
    }

    public void gameOver()
    {
        if (isGameOverSound)
        {
            FindObjectOfType<AudioManager>().Play("gameOverSound");
            isGameOverSound = false;
        }

        gameOverVariable = true;
        GameOverScreen.SetActive(true);
        hsText = GameObject.Find("High Score").GetComponent<Text>();
        highScoreText = "High Score: " + highScore.ToString();
        hsText.text = highScoreText;
    }

    public IEnumerator addGameOverScreen()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("ScreenTutorial");
    }
}
