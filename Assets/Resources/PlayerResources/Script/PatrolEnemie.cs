using Assets.Resources.PlayerResources.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemie : MonoBehaviour
{

    public float speed;
    public float distance;

    private Vector2 dir = new Vector2(-1, 0);

    public Transform groundCheck;
    public Transform groundCheck02;
    public new Rigidbody2D rigidbody2D;

    void start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D hit1 = Physics2D.Raycast(groundCheck.position, dir, distance);
        RaycastHit2D hit2 = Physics2D.Raycast(groundCheck02.position, dir, distance);
        if (hit2 == true)
        {
            if (hit2.collider.CompareTag("Ground"))
            {
                Flip();
                speed *= -1;
                dir *= -1;

            }

        }
        if (hit1 == false || hit1.collider.CompareTag("Ground"))
        {
            Flip();
            speed *= -1;
            dir *= -1;
        }
    }
    public void FixedUpate()
    {
        rigidbody2D velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }


    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EvilPlayerControler>() != null)
        {
            EvilPlayerControler evilPlayerControler = collision.gameObject.GetComponent<EvilPlayerControler>();
            evilPlayerControler.KillPlayer();

        }
    }

}

internal class rigidbody2D
{
    public static implicit operator rigidbody2D(Vector2 v)
    {
        throw new NotImplementedException();
    }
}