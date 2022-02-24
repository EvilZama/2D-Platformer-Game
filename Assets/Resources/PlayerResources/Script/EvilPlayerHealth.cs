using Assets.Resources.PlayerResources.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvilPlayerHealth : MonoBehaviour
{
    public EvilPlayerControler evilPlayerControler;
    public GameObject[] hearts;
    public int life;
    private bool dead;
    private object animator;

    private void start()
    {
        life = hearts.Length;
    }
    void Update()
    {
       if (dead == true)

        {
            //object death = animator.SetTrigger("Death");
            Debug.Log("player is dead");
        }
    }
    public void TakeDamage(int d)
    {
        if(life >=1)
        {
            life -= d;
            Destroy(hearts[life].gameObject);
            if (life < 1)
            {
                dead = true;
            }
        }
    }
}
