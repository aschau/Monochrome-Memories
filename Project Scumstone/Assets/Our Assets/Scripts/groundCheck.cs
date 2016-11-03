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
                    this.controller.jumpSpeed = this.controller.originalJumpSpeed * other.GetComponent<jumpObject>().multiplier;
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        onGround = true;

        if (other.CompareTag("jumpArea"))
        {
            if (other.GetComponentInParent<jumpObject>().activated)
            {
                Debug.Log("JUMP");
                this.controller.jumpSpeed = this.controller.originalJumpSpeed * other.GetComponentInParent<jumpObject>().multiplier;
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
                this.controller.jumpSpeed = this.controller.originalJumpSpeed;
            }
        }
    }
}
