using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour
{
    private void  OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EvilPlayerControler>() != null) 
        {
            Debug.Log("Level Complted player is reached the end");
        }        
    }
}
