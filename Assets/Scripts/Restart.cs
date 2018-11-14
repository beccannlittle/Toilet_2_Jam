using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    public KeyCode restartButton;
    public Text restartText;
    public Player player;

    private void Start()
    {
        restartText.enabled = false;
        restartText.text = "Press ' " + restartButton.ToString() + "' to Restart";
        player.playerDied += EnableRestartText;
    }

    private bool isRestartable;

    private void EnableRestartText()
    {
        restartText.enabled = true;
        player.playerDied -= EnableRestartText;
        isRestartable = true;
    }

    private void Update()
    {
        if (isRestartable && Input.GetKeyDown(restartButton))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
