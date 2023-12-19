using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
    {
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;

    public AudioSource pointSound, deathSound;

    [ContextMenu("Increase Score")]
    public void updateScore(int scoreIncrease)
    {
        pointSound.Play();
        playerScore += scoreIncrease;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        deathSound.Play();
    }
}
