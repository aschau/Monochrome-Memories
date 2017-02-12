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
    public static bool isMobile = false;
    public bool objectAvailable, held; //checks whether an object is in the vicinty to pick up
    public GameObject interactiveObject;
    public float moveSpeed = 0f, maxMoveSpeed = 3f, jumpSpeed = 220f, originalJumpSpeed, previousYVelocity;
    private bool walkingLeft, walkingRight, idle, idleReady = false, onGround = true, jumpPressed;
    private Direction lastDirection = Direction.None, currentDirection = Direction.None;
    //private DragonBones.Animation anim;
    [HideInInspector]
    public Animator anim;
    private GameObject leftButton, rightButton, jumpButton;
    private Rigidbody2D body;
    private Vector3 previousPos;
    private UnityEngine.Transform bottom;
    [SerializeField]
    private LayerMask layer;

    void Awake()
    {
        if (isMobile == true)
        {
            leftButton = GameObject.Find("LeftButton");
            rightButton = GameObject.Find("RightButton");
            jumpButton = GameObject.Find("JumpButton");
        }

        this.bottom = transform.Find("bottom");

    }

	// Use this for initialization
	void Start () {
        player = "Player";
        this.originalJumpSpeed = this.jumpSpeed;
        this.anim = this.GetComponent<Animator>();
        this.body = this.GetComponent<Rigidbody2D>();
        this.objectAvailable = false;
        this.held = false;
        //this.anim = this.GetComponent<UnityArmatureComponent>().animation;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.name == player)
        {
            if (isMobile == true)
            {
                if (this.rightButton.GetComponent<touchScript>().held == true)

                {
                    //this.GetComponent<UnityArmatureComponent>()._armature._flipX = false;
                    this.moveSpeed = 3f;
                    this.GetComponent<SpriteRenderer>().flipX = false;
                    this.walkingRight = true;
                    this.currentDirection = Direction.Right;
                    if (this.currentDirection != this.lastDirection)
                    {
                        //this.anim.FadeIn("Walking", 0.3f);
                        this.anim.SetBool("isWalking", true);
                    }
                }

                else if (this.leftButton.GetComponent<touchScript>().held == true)
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
                else
                {
                    this.moveSpeed = 0f;
                    this.walkingRight = false;
                    this.walkingLeft = false;
                    this.anim.SetBool("isWalking", false);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))

                {
                    //this.GetComponent<UnityArmatureComponent>()._armature._flipX = false;
                    this.moveSpeed = 3f;
                    this.GetComponent<SpriteRenderer>().flipX = false;
                    this.walkingRight = true;
                    this.currentDirection = Direction.Right;
                    if (this.currentDirection != this.lastDirection)
                    {
                        //this.anim.FadeIn("Walking", 0.3f);
                        this.anim.SetBool("isWalking", true);
                    }
                }

                else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
                {
                    this.moveSpeed = 0f;
                    this.walkingRight = false;
                    this.anim.SetBool("isWalking", false);
                }

                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
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
                else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    this.moveSpeed = 0f;
                    this.walkingLeft = false;
                    this.anim.SetBool("isWalking", false);
                }

                if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
                {
                    if (!held) //if the player is not already holding something then it may be able to pick something up 
                    {

                        if (this.objectAvailable) //the objects turn this boolean on if there is an object available to be picked up 
                        {
                            this.interactiveObject.GetComponent<Rigidbody2D>().isKinematic = true;
                            this.interactiveObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1.2f, this.transform.position.z);
                            this.interactiveObject.transform.parent = this.transform;
                            if (this.interactiveObject.GetComponent<baseObject>())
                            {
                                this.interactiveObject.GetComponent<baseObject>().isMoving = false;
                            }
                            this.held = true;
                            this.interactiveObject.GetComponent<boxTriggers>().touched = true;
                        }
                    }
                    else
                    {
                        if (this.objectAvailable)
                        {
                            if (this.interactiveObject.GetComponent<boxTriggers>().touched == true)
                            {
                                this.interactiveObject.transform.parent = null;
                                this.interactiveObject.GetComponent<Rigidbody2D>().isKinematic = false;
                                if (this.GetComponent<SpriteRenderer>().flipX == true)
                                {
                                    this.interactiveObject.transform.position = new Vector3(this.transform.position.x - 0.8f, this.transform.position.y + 0.3f, this.transform.position.z);
                                }

                                else
                                {
                                    this.interactiveObject.transform.position = new Vector3(this.transform.position.x + 0.8f, this.transform.position.y + 0.3f, this.transform.position.z);
                                }
                                if (this.interactiveObject.GetComponent<baseObject>())
                                {
                                    this.interactiveObject.GetComponent<baseObject>().originalPosition = this.interactiveObject.transform.position;
                                    this.interactiveObject.GetComponent<baseObject>().activated = false;
                                }
                                this.held = false;
                                this.interactiveObject.GetComponent<boxTriggers>().touched = false;
                                this.interactiveObject = null;
                                this.objectAvailable = false;
                            }
                        }
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.jumpPressed = true;
            }
            this.onGround = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(this.bottom.position, .11f, this.layer);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    this.onGround = true;
                }
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
            //this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            //if (this.moveSpeed < this.maxMoveSpeed)
            //{
            //    this.moveSpeed++;
            //}
        }

        else if (this.name == player && this.walkingLeft && !this.walkingRight)
        {
            this.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0f));
            //this.GetComponent<Rigidbody2D>().velocity = new Vector2(-this.moveSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
            //if (this.moveSpeed < this.maxMoveSpeed)
            //{
            //    this.moveSpeed++;
            //}
        }

        if (isMobile == true)
        {
            if (jumpButton.GetComponent<touchScript>().jump && this.name == player)
            {
                if (this.onGround)
                {
                    this.onGround = false;
                    jumpButton.GetComponent<touchScript>().jump = false;
                    this.body.AddForce(new Vector2(0f, this.jumpSpeed));
                }

                //if (this.transform.Find("groundDetect").GetComponent<groundCheck>().onGround && player == this.name)
                //{
                //    this.transform.Find("groundDetect").GetComponent<groundCheck>().onGround = false;
                //    this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
                //}

            }
        }
        else
        {
            if (this.jumpPressed)
            {
                if (this.onGround && this.name == player)
                {
                    this.onGround = false;
                    this.jumpPressed = false;
                    this.body.AddForce(new Vector2(0f, this.jumpSpeed));
                }
                //if (this.transform.Find("groundDetect").GetComponent<groundCheck>().onGround && player == this.name)
                //{
                //    this.transform.Find("groundDetect").GetComponent<groundCheck>().onGround = false;
                //    this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
                //}

            }
        }
        //if (!Input.anyKey)
        //{
        //    if (this.moveSpeed > 0)
        //    {
        //        this.moveSpeed--;
        //    }

        //    if (this.moveSpeed == 0)
        //    {
        //        this.walkingLeft = false;
        //        this.walkingRight = false;
        //    }
        //}
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
