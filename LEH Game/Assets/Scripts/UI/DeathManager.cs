using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private Player player;
    private bool gameOver = false;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (player.isAlive == false && !gameOver)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        if (PlayerPrefs.GetInt("Score")>PlayerPrefs.GetInt("HighScore")){}
            PlayerPrefs.SetInt("HighScore",PlayerPrefs.GetInt("Score"));
        
        StartCoroutine(LoadGameOver());
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
        
    }
}
