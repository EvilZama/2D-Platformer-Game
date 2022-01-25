using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EvilPlayerControler: MonoBehaviour
{
  public Animator animator;

  public float speed;
    
  public Rigidbody2D rigidboddy2D;

  public bool Iscrouching;
  public bool Platform;
  public float jump;

  public Collider2D groundCheck;
      
  
  private void Awake() 
    {
      Debug.Log("Player controller awake");
      rigidboddy2D = gameObject.GetComponent<Rigidbody2D>();     
    }
  // private void OnCollisionEnter2D(Collision2D collision)
   //{
    //  Debug.Log("Collision:" + collision.gameObject.name);
 // }
 private void Update()
  {
      float horizontal = Input.GetAxisRaw("Horizontal");
      float vertical = Input.GetAxisRaw("Jump");

      MoveCharacter(horizontal, vertical);
      PlayMovementAnimations(horizontal, vertical);
  }
  private void MoveCharacter(float horizontal, float vertical)
  {
      // move character horizontally
      Vector3 position = transform.position;
      //speed (distance / per time) * Time.deltaTime(frames/per time)
      position.x += horizontal * speed * Time.deltaTime;
      transform.position = position;

      // move character vertically
      if(vertical > 0)
      {
          rigidboddy2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
      }
  }   


  private void PlayMovementAnimations(float horizontal, float vertical)
  {
    //horizontal
    
      animator.SetFloat("Speed", Mathf.Abs(horizontal*speed));
      Vector3 scale = transform.localScale;
    {
      if(horizontal < 0)
      {
      scale.x = -1f * Mathf.Abs(scale.x);
      transform.localScale= scale;
      }
      else if (horizontal > 0)
      {
      scale.x = Mathf.Abs(scale.x);
      transform.localScale = scale;
      }

    }
    
    //crouching
    {
      if(Input.GetKeyDown(KeyCode.C))
      {
        animator.SetBool("Crouch",true);
        Iscrouching = true;
      }
      else if(Input.GetKeyUp(KeyCode.C))
        animator.SetBool("Crouch", false);
        Iscrouching = false;
    }
    //jump
    {
      if(Input.GetKeyDown(KeyCode.Space))
      {
        animator.SetTrigger("Jump");
      }
    }
    // void OnCollisionStay2D(Collision2D other) 
    // {
    //     if (other.gameObject.tag == "Ground")
    //     {
    //         if(!groundCheck.IsTouching(other.collider))
    //             {return;}
    //      Platform = true;
    //     }
    // }
    // void OnCollisionExit2D(Collision2D other) 
    // {
    //     if (other.gameObject.tag == "Ground")
    //     {
    //         if(groundCheck.IsTouching(other.collider))
    //             {return;}
    //      Platform = false;
    //     }
    // }    
  }


}