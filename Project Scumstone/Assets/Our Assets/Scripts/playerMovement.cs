﻿using UnityEngine;
using System.Collections;
using DragonBones;

public enum Direction
{
    Right,
    Left,
    None
}

[RequireComponent(typeof(playerPickup))]
public class playerMovement : MonoBehaviour {
    public static string player = "Player";
    public static bool isMobile = false;

    public float moveSpeed = 0f, maxMoveSpeed = 3f, jumpSpeed = 5f, previousYVelocity;
    public bool walkingLeft, walkingRight, idle, idleReady = false, onGround = true, jumpPressed;
    
    private Direction lastDirection = Direction.None, currentDirection = Direction.None;
    [HideInInspector]
    public Animator anim;
    private GameObject leftButton, rightButton, jumpButton;
    private Rigidbody2D body;
    private Vector3 previousPos;
    private UnityEngine.Transform bottom;
    [SerializeField]
    private LayerMask layer;

    private float horizontal, vertical;

    void Awake()
    {
        if (isMobile == true)
        {
            leftButton = GameObject.Find("LeftButton");
            rightButton = GameObject.Find("RightButton");
            jumpButton = GameObject.Find("JumpButton");
        }

        this.bottom = transform.Find("bottom");
        this.anim = this.GetComponent<Animator>();
        this.body = this.GetComponent<Rigidbody2D>();

    }

	// Use this for initialization
	void Start () {
        player = "Player";
	}
	
	// Update is called once per frame
    //void Update()
    //{
    //    if (this.name == player)
    //    {
    //        //if (isMobile == true)
    //        //{
    //        //    if (this.rightButton.GetComponent<touchScript>().held == true)
    //        //    {
    //        //        this.moveSpeed = 3f;
    //        //        this.GetComponent<SpriteRenderer>().flipX = false;
    //        //        this.walkingRight = true;
    //        //        this.currentDirection = Direction.Right;
    //        //        if (this.currentDirection != this.lastDirection)
    //        //        {
    //        //            this.anim.SetBool("isWalking", true);
    //        //        }
    //        //    }

    //        //    else if (this.leftButton.GetComponent<touchScript>().held == true)
    //        //    {
    //        //        this.moveSpeed = 3f;
    //        //        this.GetComponent<SpriteRenderer>().flipX = true;
    //        //        this.walkingLeft = true;
    //        //        this.currentDirection = Direction.Left;
    //        //        if (this.currentDirection != this.lastDirection)
    //        //        {
    //        //            this.anim.SetBool("isWalking", true);
    //        //        }
    //        //    }
    //        //    else
    //        //    {
    //        //        this.moveSpeed = 0f;
    //        //        this.walkingRight = false;
    //        //        this.walkingLeft = false;
    //        //        this.anim.SetBool("isWalking", false);
    //        //    }
    //        //}
    //        //else
    //        //{
    //        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
    //        {
    //            this.moveSpeed = Mathf.Clamp(this.moveSpeed + .2f, 0f, this.maxMoveSpeed);
    //            this.GetComponent<SpriteRenderer>().flipX = false;
    //            this.walkingRight = true;
    //            this.currentDirection = Direction.Right;
    //            if (this.currentDirection != this.lastDirection)
    //            {
    //                this.anim.SetBool("isWalking", true);
    //            }
    //        }

    //        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) || (Input.GetAxis("Horizontal") == 0 && this.walkingRight))
    //        {
    //            this.walkingRight = false;
    //            this.anim.SetBool("isWalking", false);
    //        }

    //        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
    //        {
    //            this.moveSpeed = Mathf.Clamp(this.moveSpeed - .2f, -this.maxMoveSpeed, 0);
    //            this.GetComponent<SpriteRenderer>().flipX = true;
    //            this.walkingLeft = true;
    //            this.currentDirection = Direction.Left;
    //            if (this.currentDirection != this.lastDirection)
    //            {
    //                this.anim.SetBool("isWalking", true);
    //            }
    //        }
    //        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || (Input.GetAxis("Horizontal") == 0 && this.walkingLeft))
    //        {
    //            this.walkingLeft = false;
    //            this.anim.SetBool("isWalking", false);
    //        }

    //        if (!this.walkingLeft && !this.walkingRight)
    //        {
    //            if (!this.onGround)
    //            {
    //                if (this.moveSpeed < 0)
    //                {
    //                    this.moveSpeed = Mathf.Clamp(this.moveSpeed + .075f, -this.maxMoveSpeed, 0f);
    //                }

    //                else if (this.moveSpeed > 0)
    //                {
    //                    this.moveSpeed = Mathf.Clamp(this.moveSpeed - .075f, 0f, this.maxMoveSpeed);
    //                }
    //            }

    //            else
    //            {
    //                this.moveSpeed = 0;
    //            }

    //        }

            //Collider2D[] colliders = Physics2D.OverlapCircleAll(this.bottom.position, .11f, this.layer);
            //this.onGround = false;
            //for (int i = 0; i < colliders.Length; i++)
            //{
            //    if (colliders[i].gameObject != gameObject)
            //    {
            //        this.onGround = true;
            //    }
            //}

    //        if (this.walkingLeft ^ this.walkingRight)
    //        {
    //            this.idle = false;
    //            this.idleReady = true;
    //            this.anim.SetBool("isWalking", true);
    //        }

    //        else
    //        {
    //            this.idle = true;
    //            this.currentDirection = Direction.None;
    //            this.anim.SetBool("isWalking", false);
    //        }

    //        if (this.idle && this.idleReady)
    //        {
    //            this.idleReady = false;
    //        }

    //        this.lastDirection = this.currentDirection;
    //    }
    //    //}
    //}
   
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
       
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.bottom.position, .11f, this.layer);

        this.onGround = false;
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                this.onGround = true;
            }
        }

        if (this.name == player)
        {
            if (horizontal < 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
                this.anim.SetBool("isWalking", true);
            }

            else if (horizontal > 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
                this.anim.SetBool("isWalking", true);
            }

            else
            {
                this.anim.SetBool("isWalking", false);
            }

            if (this.onGround && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0")))
            {
                this.jumpPressed = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (this.name == player)
        {
            if (this.onGround && this.jumpPressed) //|| Input.GetAxis("Vertical") > 0))
            {
                this.onGround = false;
                this.body.velocity = new Vector2(0f, this.jumpSpeed);
                this.jumpPressed = false;
            }
            this.transform.Translate(new Vector3(this.horizontal * this.maxMoveSpeed * Time.deltaTime, 0f, 0f));
        }
    }

    //void FixedUpdate()
    //{

    //    if (this.name == player)// && this.walkingRight && !this.walkingLeft)
    //    {
    //        this.body.velocity = new Vector2(horizontal * this.maxMoveSpeed, this.body.velocity.y);
    //        //this.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
    //    }

    //    if (isMobile == true)
    //    {
    //        if (jumpButton.GetComponent<touchScript>().jump && this.name == player)
    //        {
    //            if (this.onGround)
    //            {
    //                this.body.velocity = new Vector2(this.body.velocity.x, 0);
    //                this.onGround = false;
    //                jumpButton.GetComponent<touchScript>().jump = false;
    //                this.body.AddForce(new Vector2(0f, this.jumpSpeed));
    //                //this.jumpPressed = false;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
    //        {
    //            if (this.onGround && this.name == player)
    //            {
    //                this.body.velocity = new Vector2(this.body.velocity.x, 0);
    //                this.onGround = false;
    //                this.jumpPressed = false;
    //                this.body.AddForce(new Vector2(0f, this.jumpSpeed));
    //            }
    //        }
    //    }
    //}

    public void stopMoving()
    {
        this.anim.SetBool("isWalking", false);
    }


}
