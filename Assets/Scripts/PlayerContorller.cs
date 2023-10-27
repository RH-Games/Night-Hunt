using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorller : MonoBehaviour
{
    public Rigidbody2D Character;
    public float CharacterSpeed;
    public float CharacterJump;
    public Transform GroundCheck;
    public LayerMask Ground;
    public float groundRadius;
    bool isOnGround;
  

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Character = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Character.velocity = new Vector3(horizontalInput * CharacterSpeed, Character.velocity.y, verticalInput * CharacterSpeed);

        //finds the ground and checks if the player is toughing the ground.
        isOnGround = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, Ground);

        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            //animator.SetTrigger("Jump");
            Character.velocity = new Vector2(Character.velocity.x, CharacterJump);
        }

        Motion();
    }

  

    public void Motion()
    {
        bool WalkRight = Input.GetKey("d");
        bool WalkLeft = Input.GetKey("a");
        bool WalkRightSword = Input.GetKey("d");
        bool WalkLeftSword = Input.GetKey("a");
        //bool SwordOut = Input.GetKey("left shift");
        //bool SwordAway = Input.GetKey("left ctrl");
        //bool HoldSword =false;
        bool Jump = Input.GetKey(KeyCode.Space);

        if (WalkRight)
        {
            animator.SetTrigger("IdleRight");
            animator.SetBool("WalkRight", true);
            animator.SetBool("IdleRight", true);
            animator.SetBool("IdleLeft", false);
        }
        else if (WalkRight == false){
            animator.SetBool("WalkRight", false);
        }
        //else if (WalkRight)
        if (WalkLeft) {
            animator.SetBool("WalkLeft", true);
            animator.SetBool("IdleLeft",true);
            animator.SetBool("IdleRight", false);
        }
        else if (WalkLeft == false)
        {
            animator.SetBool("WalkLeft", false);
        }

    }
}
