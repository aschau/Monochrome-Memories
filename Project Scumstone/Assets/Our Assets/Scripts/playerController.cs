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
        this.originalMoveSpeed = this.moveSpeed;
        this.originalJumpSpeed = this.jumpSpeed;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
    }   

	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.D))
        {
            if (playerNumber == 1)
            {
                this.player1.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
            }

            else if (playerNumber == 2)
            {
                this.player2.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
            }
        }

        else if (Input.GetKey(KeyCode.A))
        {
            if (playerNumber == 1)
            {
                this.player1.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0f));
            }

            else if (playerNumber == 2)
            {
                this.player2.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0f));
            }
        }

        if (Input.GetKey(KeyCode.W))
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