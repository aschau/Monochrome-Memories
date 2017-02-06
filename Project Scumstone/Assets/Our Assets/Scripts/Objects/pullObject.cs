using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullObject : baseObject {
    //public Vector3 originalPosition;
    //private bool watchPlayer;
    public override void Awake()
    {
        base.Awake();
    }

	// Use this for initialization
	void Start () {
        //this.watchPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
        //This is code for holding the box

       /* if (this.transform.parent != null) //if the box is being held
        {
            
            if (!base.activated)
            {
                this.watchPlayer = true;
                this.transform.parent = null;
                
                this.GetComponent<Rigidbody2D>().gravityScale = 1;
                
            }
        }

        if (watchPlayer == true)
        {
                this.transform.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        else
            {
                this.transform.GetComponent<Rigidbody2D>().isKinematic = false;
            }
       
        */

	}


    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "Player")
        {
            hit.GetComponent<playerMovement>().objectAvailable = true;
            hit.GetComponent<playerMovement>().interactiveObject = this.gameObject;
            
        }
    }


    void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.tag == "Player")
        {
            
            if (hit.GetComponent<playerMovement>().held == false)
            {
                hit.GetComponent<playerMovement>().objectAvailable = false;
            }
        }
    }


   /* void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.tag == "Player")
        {

            if (base.activated)
            {
                this.watchPlayer = false;
                Debug.Log("Attached much");
                this.GetComponent<Rigidbody2D>().gravityScale = 0;
                this.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.1f, hit.transform.position.z);
                this.transform.parent = hit.transform;

                
            }
            else
            {
                this.watchPlayer = true;
            }
        }
    }*/

    /*void OnTriggerExit2D(Collider2D hit)
    {
        if (base.activated == false)
        {
            if (hit.tag == "Player")
            {
                Debug.Log("leftObject");
                this.watchPlayer = false;
            }
        }
    }*/

    /*void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.transform.tag == "Player")
        {
            this.watchPlayer = false;
        }
    }*/



    




}
