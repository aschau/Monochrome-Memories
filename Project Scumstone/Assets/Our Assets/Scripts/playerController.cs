using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
    public float moveSpeed = 3f;
    public float jumpSpeed = 100f;
    public int playerNumber;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (playerNumber == 1)
        {
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
            }

            else if (Input.GetKey(KeyCode.A))
            {
                this.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0f));
            }

            if (this.transform.Find("groundDetect").GetComponent<groundCheck>().onGround && Input.GetKey(KeyCode.W))
            {
                this.transform.Find("groundDetect").GetComponent<groundCheck>().onGround = false;
                this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
            }
        }

        else if (playerNumber == 2)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0f));
            }

            if (this.transform.Find("groundDetect").GetComponent<groundCheck>().onGround && Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Find("groundDetect").GetComponent<groundCheck>().onGround = false;
                this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpSpeed);
            }
        }



	}
}
