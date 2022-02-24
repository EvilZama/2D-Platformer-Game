using Assets.Resources.PlayerResources.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieController : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb;
    public LayerMask groudLayer;
    public Transform groundCheck;
    
    bool isFacingRight = true;

    RaycastHit2D hit;

    public void Update()
    {
        hit = Physics2D.Raycast(groundCheck.position, -transform.up, 1f, groudLayer);
    }
    
    public void FixedUpdate()
    {
        Vector3 scale = transform.localScale;
        if (hit.collider != false)
        {
           if(isFacingRight)
            {
                //scale.x = -1f * Mathf.Abs(scale.x);
                //transform.localScale = scale;
                rb.velocity = new Vector2(speed, rb.velocity.y);
                Debug.Log("Enemie Hitting Ground");
            }
            else
            {
                //scale.x = Mathf.Abs(scale.x);
                //transform.localScale = scale;
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        else
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
            Debug.Log("Enemie NOT Hitting Ground");
        }
    }
#region // collision to player to die whenit touch the enemie
    
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        //if (collision.gameObject.GetComponent<EvilPlayerControler>() != null)
      //  {
          //  EvilPlayerControler evilPlayerControler = collision.gameObject.GetComponent<EvilPlayerControler>();
            //evilPlayerControler.KillPlayer();
            
        //}
    //}
#endregion
}
