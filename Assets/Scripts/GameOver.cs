using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script is for when the Game is over a screen appears with Game over and the game is then over
 */
public class GameOver : MonoBehaviour
{
    //variables
    public static bool isPlayerDead = false;
    private Text gameOver;


    void Start()
    {
        //displays text
        gameOver = GetComponent<Text>();
        gameOver.enabled = false;
    }

    void Update()
    {
        if (isPlayerDead) 
        {
            Time.timeScale = 0;
            gameOver.enabled = true;
        }
    }
}
