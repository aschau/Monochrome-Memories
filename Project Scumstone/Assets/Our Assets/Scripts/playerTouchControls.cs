using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DragonBones;

public class playerTouchControls : MonoBehaviour {
    public static string player;
    public float moveSpeed = 0f, jumpSpeed = 200f, originalMoveSpeed, originalJumpSpeed;
    private bool walkingLeft, walkingRight, idle, idleReady = false;
    private Direction lastDirection = Direction.None, currentDirection = Direction.None;
    private GameObject leftButton, rightButton, jumpButton;
    //private DragonBones.Animation anim;
    public Animator anim;

    void Awake()
    {
        leftButton = GameObject.Find("LeftButton");
        rightButton = GameObject.Find("RightButton");
        jumpButton = GameObject.Find("JumpButton");
    }

    // Use this for initialization
    void Start()
    {
        player = "Player";
        this.originalMoveSpeed = this.moveSpeed;
        this.originalJumpSpeed = this.jumpSpeed;
        this.anim = this.GetComponent<Animator>();

        //this.anim = this.GetComponent<UnityArmatureComponent>().animation;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == player)
        {

            //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            if (this.rightButton.GetComponent<touchScript>().held == true)
            {
                this.moveSpeed = 3f;
                //this.GetComponent<UnityArmatureComponent>()._armature._flipX = false;
                this.GetComponent<SpriteRenderer>().flipX = false;
                this.walkingRight = true;
                this.currentDirection = Direction.Right;
                if (this.currentDirection != this.lastDirection)
                {
                    //this.anim.FadeIn("Walking", 0.3f);
                    this.anim.SetBool("isWalking", true);
                }
            }
            /*else if(this.rightButton.GetComponent<touchScript>().held == false)//GetTouch(0).deltaPosition.x < this.transform.position)
            //else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                this.moveSpeed = 0f;
                this.walkingRight = false;
                this.anim.SetBool("isWalking", false);
            }*/

            else if (this.leftButton.GetComponent<touchScript>().held == true)
            //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                this.moveSpeed = 3f;
                this.GetComponent<SpriteRenderer>().flipX = true;
                //this.GetComponent<UnityArmatureComponent>()._armature._flipX = true;
                this.walkingLeft = true;
                this.currentDirection = Direction.Left;
                if (this.currentDirection != this.lastDirection)
                {
                    //this.anim.FadeIn("Walking", 0.3f);
                    this.anim.SetBool("isWalking", true);
                }
            }
            else //(this.leftButton.GetComponent<touchScript>().held == false)
            //else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                this.moveSpeed = 0f;
                this.walkingLeft = false;
                this.walkingRight = false;
                this.anim.SetBool("isWalking", false);
            }

            if (this.walkingLeft ^ this.walkingRight)
            {
                this.idle = false;
                this.idleReady = true;
                this.anim.SetBool("isWalking", true);
            }

            else
            {
                this.idle = true;
                this.currentDirection = Direction.None;
                this.anim.SetBool("isWalking", false);
            }

            if (this.idle && this.idleReady)
            {
                //this.anim.FadeIn("Idle", 0.5f);
                this.idleReady = false;
            }

            this.lastDirection = this.currentDirection;
        }
    }

    void FixedUpdate()
    {
        if (this.name == player && this.walkingRight && !this.walkingLeft)
        {
            this.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
        }

        else if (this.name == player && this.walkingLeft && !this.walkingRight)
        {
            this.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0f));
        }

        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        if (this.jumpButton.GetComponent<touchScript>().held == true)
        {

            if (this.transform.Find("groundDetect").GetComponent<groundCheck>().onGround && player == this.name)
            {
                this.transform.Find("groundDetect").GetComponent<groundCheck>().onGround = false;
                this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
            }

        }
    }

    public void stopMoving()
    {
        this.walkingLeft = false;
        this.walkingRight = false;
        this.idle = true;
        this.anim.SetBool("isWalking", false);
        //this.anim.FadeIn("Idle", 0.5f);
    }
}
