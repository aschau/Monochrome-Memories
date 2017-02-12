using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveBox : MonoBehaviour
{
    public Vector3 newPosition;
    public GameObject child;
    //public Vector3 originalPosition;
    //private bool watchPlayer;
    // Use this for initialization
    void Start()
    {
        //this.watchPlayer = false;
        //child = this.transform.FindChild("stacked").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

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
        if (hit.tag == "Player") //when player enters the trigger
        {
            if (this.transform.parent.GetComponent<boxTriggers>().stacked == false) //if the child of this object is not activated, it means there is no stacked boxes on top 
            {
                hit.GetComponent<playerMovement>().objectAvailable = true; //player knows that there is an object available
                if (hit.GetComponent<playerMovement>().held == false) //if the player is not already holding an object
                {
                    hit.GetComponent<playerMovement>().interactiveObject = this.transform.parent.gameObject; //pick up the object as a child
                }
            }
        }
    }


    void OnTriggerExit2D(Collider2D hit)
    {
        if (this.transform.parent.GetComponent<boxTriggers>().stacked == false) // if not stacked
        {
            if (hit.tag == "Player") //if player leaves the box 
            {

                if (hit.GetComponent<playerMovement>().held == false) //and if the player is not holding anything
                    //this is to make sure the box that the player is holding 
                {
                    hit.GetComponent<playerMovement>().objectAvailable = false; //turn off available object 
                
                }
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
