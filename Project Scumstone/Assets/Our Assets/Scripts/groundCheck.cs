﻿using UnityEngine;
using System.Collections;

public class groundCheck: MonoBehaviour {
    public bool onGround = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D other)
    {
        onGround = true;
        this.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;

        if (other.CompareTag("jumpArea"))
        {
            if (other.GetComponentInParent<jumpObject>().activated)
            {
                Debug.Log("JUMP");
                this.GetComponentInParent<playerController>().jumpSpeed = this.GetComponentInParent<playerController>().originalJumpSpeed * other.GetComponentInParent<jumpObject>().multiplier;
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
                this.GetComponentInParent<playerController>().jumpSpeed = this.GetComponentInParent<playerController>().originalJumpSpeed;
            }
        }
    }
}
