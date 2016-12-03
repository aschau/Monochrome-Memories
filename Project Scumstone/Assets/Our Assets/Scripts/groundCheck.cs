using UnityEngine;
using System.Collections;

public class groundCheck: MonoBehaviour {
    public bool onGround = true;

    void Awake ()
    {
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "jumpArea")
        {
            if (other.GetComponent<jumpObject>() != null)
            {
                if (other.GetComponent<jumpObject>().activated)
                {
                    Debug.Log("JUMP");
                    this.GetComponentInParent<playerMovement>().jumpSpeed = this.GetComponentInParent<playerMovement>().originalJumpSpeed * other.GetComponentInParent<jumpObject>().multiplier;
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        onGround = true;
        if (this.GetComponentInParent<Rigidbody2D>())
        {
            this.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (other.CompareTag("jumpArea"))
        {
            if (other.GetComponentInParent<jumpObject>().activated)
            {
                this.GetComponentInParent<playerMovement>().jumpSpeed = this.GetComponentInParent<playerMovement>().originalJumpSpeed * other.GetComponentInParent<jumpObject>().multiplier;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onGround = false;

        if (other.CompareTag("jumpArea"))
        {
            if (other.GetComponentInParent<jumpObject>().activated)
            {
                Debug.Log("JUMP");
                this.GetComponentInParent<playerMovement>().jumpSpeed = this.GetComponentInParent<playerMovement>().originalJumpSpeed;
            }
        }
    }
}
