using Assets.Resources.PlayerResources.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlockKey : MonoBehaviour
{
    // public void StartTheGame;
   
   private void  OnTriggerEnter2D(Collider2D collision)
    {
        // if(collision.gameObject.GetComponent<EvilPlayerControler>() !=null)
        // {
        //     SceneManager.LoadScene(1);
        // }
        if(collision.gameObject.GetComponent<EvilPlayerControler>() != null) 
        {
            Debug.Log("Level Key is Opened");
            
            
        }            
    }   
}
