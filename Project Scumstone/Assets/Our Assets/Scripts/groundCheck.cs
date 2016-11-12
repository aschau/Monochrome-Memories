using UnityEngine;
using System.Collections;

public class groundCheck: MonoBehaviour {
    public bool onGround = true;
    private playerController controller;

    void Awake ()
    {
        this.controller = GameObject.Find("playerControl").GetComponent<playerController>();
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
                    if (this.transform.parent.name == "Player")
                    {
                        this.controller.p1JumpSpeed = this.controller.originalJumpSpeed * other.GetComponentInParent<jumpObject>().multiplier;
                    }

                    else
                    {
                        this.controller.p2JumpSpeed = this.controller.originalJumpSpeed * other.GetComponentInParent<jumpObject>().multiplier;
                    }
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        onGround = true;
        this.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
        if (other.CompareTag("jumpArea"))
        {
            if (other.GetComponentInParent<jumpObject>().activated)
            {
                if (this.transform.parent.name == "Player")
                {
                    this.controller.p1JumpSpeed = this.controller.originalJumpSpeed * other.GetComponentInParent<jumpObject>().multiplier;
                }

                else
                {
                    this.controller.p2JumpSpeed = this.controller.originalJumpSpeed * other.GetComponentInParent<jumpObject>().multiplier;
                }
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
                if (this.transform.parent.name == "Player")
                {
                    this.controller.p1JumpSpeed = this.controller.originalJumpSpeed;
                }

                else
                {
                    this.controller.p2JumpSpeed = this.controller.originalJumpSpeed;
                }
            }
        }
    }
}
