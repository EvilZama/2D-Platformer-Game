using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOverComplete : MonoBehaviour
{
   
   private void  OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EvilPlayerControler>() != null) 
        {
            Debug.Log("Level Complted player is reached the end");
        }        
    }
    // public void Level1() 
    // {
    //     SceneManager.LoadScene(0);
    // }

    // public void Level2() 
    // {
    //     SceneManager.LoadScene(1);
    // }
}