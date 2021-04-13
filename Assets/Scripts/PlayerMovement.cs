using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;
/*
 * This script controls the players movements which are controlled by voice recognition.
 */

public class PlayerMovement : MonoBehaviour
{
    
    //List of variables
    private GrammarRecognizer gr;
    private Transform player;
    public float speed;
    //voice recognition variable
    private static string spokenWord;
    // Min & max values
    // Values to go up and down
    public float min_Y, max_Y; // Up down
    // Values to go left and right
    public float min_X, max_X; // Left right
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    private void Start()
    {
        //Calls the voice recognition method
        VoiceRecognitionCommands();
    }
    private static void GR_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        // Read the semantic meanings from the args passed in.
        var message = new StringBuilder();
        var meanings = args.semanticMeanings;

        Debug.Log("Recognised a phrase");

        // Foreach gets all the meanings.
        foreach (var meaning in meanings)
        {
            var item = meaning.values[0].Trim();
            message.Append("Word Detected: " + item); // Testing
            spokenWord = item;
        }
    }
    // Awake listens for grammar that matches the xml
    private void Awake()
    {
        // Set initial spoken word to null
        spokenWord = "";

        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath,
                                                "Grammer.xml"),
                                    ConfidenceLevel.Low);
        Debug.Log("Grammar loaded!"); // Test
        gr.OnPhraseRecognized += GR_OnPhraseRecognized;
        gr.Start(); // Starts the recogniser
    }

    void Update()
    {
        //Calls method below
        VoiceRecognitionCommands();
    }
    //switch statement which calls the spoken word which
    //is linked to the Grammer.xml file and will then call
    //specific functions when it recognises a word
    private void VoiceRecognitionCommands()
    {
        switch (spokenWord)
        {
            case "up":
                up();
                break;

            case "down":
                down();
                break;

            case "left":
                left();
                break;

            case "stop":
                stop();
                break;

            case "shoot":
                shoot();
                break;

            case "right":
                right();
                break;
        }
    }

    //When shoot is called it triggers this method which will then make the player shoot
    private void shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

    }
    //when stop is called it triggers this method which then will stop the player
    private void stop()
    {
        transform.Translate(0, 0, 0);

    }

    //when up is called it allows the player to go up until a certain point which is set by the max y
    //found this worked better than continously having to say up over and over to reach the top point
    private void up()
    {
        Vector3 temp = transform.position;
        temp.y += speed * Time.deltaTime;
        if (temp.y > max_Y)
            temp.y = max_Y;
        transform.position = temp;
    }
    //when down is called it allows the player to go up until a certain point which is set by the max x
    //found this worked better than continously having to say down over and over to reach the bottom point
    private void down()
    {
        Vector3 temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        if (temp.y < min_Y)
            temp.y = min_Y;
        transform.position = temp;
    }
    //allows player to go left
    //only have to say left once and then it will go left and then stop at a certain point
    //Better than having to say left and moving slowly over 
        
    private void left()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        if (temp.x < min_X)
            temp.x = min_X;
        transform.position = temp;
    }
    //allows player to go right
    //only have to say right once and then it will go right and then stop at a certain point
    //Better than having to say right and moving slowly over 
    private void right()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        if (temp.x > max_X)
            temp.x = max_X;
        transform.position = temp;
    }


    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhraseRecognized;
            gr.Stop();
        }
    }


}

