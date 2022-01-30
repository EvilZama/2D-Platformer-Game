using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Resources.PlayerResources.Script

{
    public class EvilPlayerControler : MonoBehaviour
    {
        public ScoreController scoreController;
        public Animator animator;
        public float speed;
        public Rigidbody2D rigidboddy2D;
        public bool Iscrouching;
        public bool Platform;
        public float jump;
        public Collider2D groundCheck;
        public Transform spawnPosition;

        public void PickUpCoin()
        {
            Debug.Log("Player collect the coin");
            scoreController.IncreaseScore(1);
        }

        public Transform PlayerTransofrm;

        private void Awake()
        {
            Debug.Log("Player controller awake");
            rigidboddy2D = gameObject.GetComponent<Rigidbody2D>();
        }
      
        private void Update()
        {
            Camera.main.transform.parent = null;
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Jump");

            MoveCharacter(horizontal, vertical);
            PlayMovementAnimations(horizontal, vertical);
            Respawn();
        }
        private void MoveCharacter(float horizontal, float vertical)
        {
            // move character horizontally
            Vector3 position = transform.position;
            //speed (distance / per time) * Time.deltaTime(frames/per time)
            position.x += horizontal * speed * Time.deltaTime;
            transform.position = position;
        }

        private void PlayMovementAnimations(float horizontal, float vertical)
        {
            //horizontal

            this.horizontal(horizontal);
            //crouching
            crouching();
            //jump
            Jump();
               
        }

        private void horizontal(float horizontal)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal * speed));
            Vector3 scale = transform.localScale;
            if (horizontal < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            else if (horizontal > 0)
            {
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
                rigidboddy2D.velocity = Vector2.up * jump;
            }
        }
        
        private void crouching()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                animator.SetBool("Crouch", true);
                Iscrouching = true;
                speed = 0;
            }
            else if (Input.GetKeyUp(KeyCode.C))
                animator.SetBool("Crouch", false);
                Iscrouching = false;
        }

        //respawnPlayer
        private void Respawn()
        {
            if(PlayerTransofrm.position.y < -10)
            {
                PlayerTransofrm.position = spawnPosition.position;
                
            }

        }

       
    }
}