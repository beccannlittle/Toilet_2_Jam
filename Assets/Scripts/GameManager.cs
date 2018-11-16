using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Player player;
    public Text messageText;
    [Header("Restarting")]
    public KeyCode restartButton;
    [Header("Winning")]
    public string winMessage = "Whew! You got away...For now.";
    [Header("Score")]
    public Text scoreText;

    private void Start()
    {
        messageText.enabled = false;
        player.playerDied += EnableRestartText;
        player.playerWon += EnableWinText;
    }

    private float score;

    public void IncrementScore(float toIncrement)
    {
        score += toIncrement;
        scoreText.text = "Score: " + score;
    }

    private bool isRestartable;

    private void EnableRestartText()
    {
        messageText.text = "Press ' " + restartButton.ToString() + "' to Restart";
        messageText.enabled = true;
        isRestartable = true;
        player.playerDied -= EnableRestartText;
    }

    private void EnableWinText()
    {
        messageText.text = winMessage;
        messageText.enabled = true;
        player.playerWon -= EnableWinText;
    }

    private void Update()
    {
        if (isRestartable && Input.GetKeyDown(restartButton))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
