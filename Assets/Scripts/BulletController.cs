using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script will program controls player bullet
 */

public class BulletController : MonoBehaviour
{
    //Variables
    private Transform bullet;
    public float speed;
    
    void Start()
    {
        //Gets transform
        bullet = GetComponent<Transform>();
    }

    //fixed update = set period of time bullet released
    void FixedUpdate()
    {
        //Upward direction * by speed
        bullet.position += Vector3.up * speed;
        if (bullet.position.y >= 10) // Destroy bullet if greater than 10
            Destroy(gameObject);//clear bullets when there off the screen
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy") // if tag equals enemy then it will destroy the enemy game object 
        {
            Destroy(other.gameObject);
            Destroy(gameObject); //destroys enemy and bullet when bullet hits enemy
            //Increase Player score
            PlayerScore.playerScore += 10; //score increases by 10
        }
        //if tag if the base which is the base infront of player dont damage base just destroy it
        else if (other.tag == "Base") 
        {
            Destroy(gameObject);
        }
    }
}
