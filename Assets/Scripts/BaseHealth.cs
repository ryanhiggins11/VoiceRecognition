using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script os for the base health so if the health drops below 0 it is then destroyed
 */
public class BaseHealth : MonoBehaviour
{
    [SerializeField]public float health = 5;
    
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
