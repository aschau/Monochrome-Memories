using UnityEngine;
using System.Collections;
using DragonBones;

public enum Direction
{
    Right,
    Left,
    None
}

public class playerMovement : MonoBehaviour {
    public static string player = "Player";

    public float moveSpeed = 3f, jumpSpeed = 200f, originalMoveSpeed, originalJumpSpeed;
    private bool walkingLeft, walkingRight, idle, idleReady = false;
    private Direction lastDirection = Direction.None, currentDirection = Direction.None;
    private DragonBones.Animation anim;

	// Use this for initialization
	void Start () {
        this.originalMoveSpeed = this.moveSpeed;
        this.originalJumpSpeed = this.jumpSpeed;
        this.anim = this.GetComponent<UnityArmatureComponent>().animation;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.name == player)
        {
            //if (Input.GetKeyDown(KeyCode.D))
            //{
            //    //this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            //    this.animation.FadeIn("Walking", 0.3f);
            //    //this.walkingRight = true;
            //}

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
                this.walkingRight = true;
                this.currentDirection = Direction.Right;

                if (this.currentDirection != this.lastDirection)
                {
                    this.anim.FadeIn("Walking", 0.3f);
                }
            }

            else if (Input.GetKeyUp(KeyCode.D))
            {
                this.walkingRight = false;
            }

            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    //this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            //    this.animation.FadeIn("Walking", 0.3f);
            //    //this.walkingLeft = true;
            //}

            if (Input.GetKey(KeyCode.A))
            {
                this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
                this.walkingLeft = true;
                this.currentDirection = Direction.Left;
                if (this.currentDirection != this.lastDirection)
                {
                    this.anim.FadeIn("Walking", 0.3f);
                }
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                this.walkingLeft = false;
            }

            Debug.Log(this.currentDirection);

            if (this.walkingLeft ^ this.walkingRight)
            {
                this.idle = false;
                this.idleReady = true;
            }

            else
            {
                this.idle = true;
            }

            if (this.idle && this.idleReady)
            {
                this.anim.FadeIn("Idle", 0.5f);
                this.idleReady = false;
            }

            this.lastDirection = this.currentDirection;
        }
	}

    void FixedUpdate()
    {
        if (this.name == player && this.walkingRight && !this.walkingLeft)
        {
            if (this.transform.localScale.x < 0)
            {
                this.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0f));
            }

            else
            {
                this.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
            }
        }

        else if (this.name == player && this.walkingLeft && !this.walkingRight)
        {
            if (this.transform.localScale.x < 0)
            {
                this.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
            }

            else
            {
                this.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0f));
            }

        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {

            if (this.transform.Find("groundDetect").GetComponent<groundCheck>().onGround && player == this.name)
            {
                this.transform.Find("groundDetect").GetComponent<groundCheck>().onGround = false;
                this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
            }

        }
    }
}
