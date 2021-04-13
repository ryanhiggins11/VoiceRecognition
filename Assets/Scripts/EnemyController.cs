using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script is for controlling the enemy which includes controlling enemy movemnt and also it 
 * controls the fire rate of the enemy
 */

public class EnemyController : MonoBehaviour
{
	//variables
	private Transform enemyHolder;
	public float speed;

	
	public GameObject shot;
	public Text winText;
	[SerializeField]public float fireRate = 0.997f; //sets fire rate from enemies

	// Use this for initialization
	void Start()
	{
		winText.enabled = false; 
		InvokeRepeating("MoveEnemy", 0.1f, 0.3f); 
		enemyHolder = GetComponent<Transform>();
	}

	void MoveEnemy()
	{
		enemyHolder.position += Vector3.right * speed; //enemy movement

		foreach (Transform enemy in enemyHolder) //go through each enemy placed inside enemy holder
		{
			if (enemy.position.x < -10.5 || enemy.position.x > 10.5) // if enemy position is less than -10.5 or more than 10.5
			{
				speed = -speed; //reverses direction enemy moving
				enemyHolder.position += Vector3.down * 0.5f; //make all enemies move down on screen together 
				return; // if true return
			}

			//EnemyBulletController called too
			if (Random.value > fireRate)
			{
				Instantiate(shot, enemy.position, enemy.rotation);
			}


			if (enemy.position.y <= -5) //if its reaches to level of -5 which = bases then games over players dead
			{
				GameOver.isPlayerDead = true;
				Time.timeScale = 0; //freezes game
			}
		}

		if (enemyHolder.childCount == 1) // if theres one enemy left cancel invoke and do it at a quicker speed
		{
			CancelInvoke();
			InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
		}

		if (enemyHolder.childCount == 0) // if enemy = 0 then the enemy loses and the player then will win the game.
		{
			winText.enabled = true;
		}
	}
}