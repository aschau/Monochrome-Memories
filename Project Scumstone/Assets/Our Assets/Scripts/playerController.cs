using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
    public float moveSpeed = 3f;
    public float jumpSpeed = 200f;
    public float originalMoveSpeed;
    public float originalJumpSpeed;

    private static int playerNumber = 1;
    private GameObject player1, player2;
    private GameObject topCover, bottomCover;
    //private bool isMoving = false;

    void Awake()
    {
        this.player1 = GameObject.Find("Player");
        this.player2 = GameObject.Find("Player 2");
        this.topCover = GameObject.Find("topImage");
        this.bottomCover = GameObject.Find("bottomImage");
    }

	// Use this for initialization
	void Start () {
        this.topCover.SetActive(false);
        playerNumber = 1;
        this.originalMoveSpeed = this.moveSpeed;
        this.originalJumpSpeed = this.jumpSpeed;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (this.player1.activeSelf && this.player2.activeSelf))
        {
            if (playerNumber == 1)
            {
                playerNumber = 2;
                bottomCover.SetActive(false);
                topCover.SetActive(true);
            }

            else if (playerNumber == 2)
            {
                playerNumber = 1;
                topCover.SetActive(false);
                bottomCover.SetActive(true);
            }
        }

        else if (!this.player1.activeSelf && this.player2.activeSelf)
        {
            playerNumber = 2;
            bottomCover.SetActive(false);
            topCover.SetActive(true);
        }

        else if (this.player1.activeSelf && !this.player2.activeSelf)
        {
            playerNumber = 1;
            topCover.SetActive(false);
            bottomCover.SetActive(true);
        }
    }   

	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.D))
        {
            if (playerNumber == 1)
            {
                this.player1.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
                //this.player1.GetComponent<SpriteRenderer>().enabled = false;
                //this.player1.transform.FindChild("Armature").gameObject.SetActive(true);
                //this.player1.transform.FindChild("Armature").localScale = new Vector3(Mathf.Abs(this.player1.transform.localScale.x), this.player1.transform.localScale.y, this.player1.transform.localScale.z);
                //this.player1.GetComponent<SpriteRenderer>().flipX = false;
            }

            else if (playerNumber == 2)
            {
                this.player2.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
            }
        }

        //else if (Input.GetKeyUp(KeyCode.D))
        //{
        //    this.player1.transform.FindChild("Armature").gameObject.SetActive(false);
        //    this.player1.GetComponent<SpriteRenderer>().enabled = true;
        //}

        else if (Input.GetKey(KeyCode.A))
        {
            if (playerNumber == 1)
            {
                this.player1.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0f));
                //this.player1.GetComponent<SpriteRenderer>().enabled = false;
                //this.player1.transform.FindChild("Armature").gameObject.SetActive(true);
                //this.player1.transform.FindChild("Armature").localScale = new Vector3(-Mathf.Abs(this.player1.transform.localScale.x), this.player1.transform.localScale.y, this.player1.transform.localScale.z);
                //this.player1.GetComponent<SpriteRenderer>().flipX = true;
            }

            else if (playerNumber == 2)
            {
                this.player2.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0f));
            }
        }

        //else if (Input.GetKeyUp(KeyCode.A))
        //{
        //    this.player1.transform.FindChild("Armature").gameObject.SetActive(false);
        //    this.player1.GetComponent<SpriteRenderer>().enabled = true;
        //}

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {

            if (this.player1.transform.Find("groundDetect").GetComponent<groundCheck>().onGround && playerNumber == 1)
            {
                this.player1.transform.Find("groundDetect").GetComponent<groundCheck>().onGround = false;
                this.player1.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
            }

            else if (this.player2.transform.Find("groundDetect").GetComponent<groundCheck>().onGround && playerNumber == 2)
            {
                this.player2.transform.Find("groundDetect").GetComponent<groundCheck>().onGround = false;
                this.player2.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
            }

        }
	}
}