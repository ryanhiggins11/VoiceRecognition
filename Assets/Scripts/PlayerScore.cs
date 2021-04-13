using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script is for displaying the player score
 */
public class PlayerScore : MonoBehaviour
{
    //player score will always start at 0
    public static float playerScore = 0;
    private Text scoreText;

    void Start()
    {
        //displays the scoretext
        scoreText = GetComponent<Text>();
    }

    
    void Update()
    {
        //updates the score
        scoreText.text = "Score" + playerScore;
    }
}
