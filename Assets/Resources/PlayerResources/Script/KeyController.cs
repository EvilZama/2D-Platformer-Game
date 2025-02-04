using Assets.Resources.PlayerResources.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EvilPlayerControler>() != null)
        {
            EvilPlayerControler evilPlayerControler = collision.gameObject.GetComponent<EvilPlayerControler>();
            evilPlayerControler.PickUpCoin();
            Destroy(gameObject);
        }
    }
}
