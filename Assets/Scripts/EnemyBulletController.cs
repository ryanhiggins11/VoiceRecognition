using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script will program controls bullet
 */
public class EnemyBulletController : MonoBehaviour
{

	private Transform bullet;
	public float speed;

	// Use this for initialization
	void Start()
	{
		bullet = GetComponent<Transform>();
	}

	void FixedUpdate()
	{
		bullet.position += Vector3.up * -speed; //controls speed and multiplying by negative speed makes it go in opposite direction

		if (bullet.position.y <= -10) // bullet position.y less than = to -10 destroy bullet
			Destroy(bullet.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") //if enemy bullet hits player then kill player and destroy bullet and Game over will appear
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
			GameOver.isPlayerDead = true;
		}
		else if (other.tag == "Base") // if enemy bullet hits base then reduce base health and destroy bullet
		{
			GameObject playerBase = other.gameObject;
			BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
			baseHealth.health -= 1;
			Destroy(gameObject);
		}
	}
}