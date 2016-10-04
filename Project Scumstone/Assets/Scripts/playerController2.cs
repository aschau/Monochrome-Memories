using UnityEngine;
using System.Collections;

public class playerController2 : MonoBehaviour {
    public float moveSpeed = 3f;
    public float jumpSpeed = 100f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
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
