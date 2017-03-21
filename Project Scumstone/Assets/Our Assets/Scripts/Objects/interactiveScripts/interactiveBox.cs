using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveBox : MonoBehaviour
{
    public Vector3 newPosition;
    public GameObject child;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D hit)
    {
        if (this.transform.parent.GetComponent<baseObject>())
        {
            if (!this.transform.parent.GetComponent<baseObject>().isMoving)
            {
                if (hit.tag == "Player") //when player enters the trigger
                {
                    if (this.transform.parent.GetComponent<boxTriggers>().stacked == false) //if the child of this object is not activated, it means there is no stacked boxes on top 
                    {
                        hit.GetComponent<playerPickup>().objectAvailable = true; //player knows that there is an object available
                        if (hit.GetComponent<playerPickup>().held == false) //if the player is not already holding an object
                        {
                            hit.GetComponent<playerPickup>().interactiveObject = this.transform.parent.gameObject; //pick up the object as a child
                        }
                    }
                }
            }
            else
            {
                Debug.Log("CAN'T PICKUP");
            }
        }

        else
        {
            if (hit.tag == "Player") //when player enters the trigger
            {
                if (this.transform.parent.GetComponent<boxTriggers>().stacked == false) //if the child of this object is not activated, it means there is no stacked boxes on top 
                {
                    hit.GetComponent<playerPickup>().objectAvailable = true; //player knows that there is an object available
                    if (hit.GetComponent<playerPickup>().held == false) //if the player is not already holding an object
                    {
                        hit.GetComponent<playerPickup>().interactiveObject = this.transform.parent.gameObject; //pick up the object as a child
                    }
                }
            }
        }

    }

    void OnTriggerStay2D(Collider2D hit)
    {
        if (this.transform.parent.GetComponent<baseObject>())
        {
            if (!this.transform.parent.GetComponent<baseObject>().isMoving)
            {
                if (hit.tag == "Player") //when player enters the trigger
                {
                    if (this.transform.parent.GetComponent<boxTriggers>().stacked == false) //if the child of this object is not activated, it means there is no stacked boxes on top 
                    {
                        hit.GetComponent<playerPickup>().objectAvailable = true; //player knows that there is an object available
                        if (hit.GetComponent<playerPickup>().held == false) //if the player is not already holding an object
                        {
                            hit.GetComponent<playerPickup>().interactiveObject = this.transform.parent.gameObject; //pick up the object as a child
                        }
                    }
                }
            }
            else
            {
                Debug.Log("CAN'T PICKUP");
            }
        }

        else
        {
            if (hit.tag == "Player") //when player enters the trigger
            {
                if (this.transform.parent.GetComponent<boxTriggers>().stacked == false) //if the child of this object is not activated, it means there is no stacked boxes on top 
                {
                    hit.GetComponent<playerPickup>().objectAvailable = true; //player knows that there is an object available
                    if (hit.GetComponent<playerPickup>().held == false) //if the player is not already holding an object
                    {
                        hit.GetComponent<playerPickup>().interactiveObject = this.transform.parent.gameObject; //pick up the object as a child
                    }
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

                if (hit.GetComponent<playerPickup>().held == false) //and if the player is not holding anything
                    //this is to make sure the box that the player is holding 
                {
                    hit.GetComponent<playerPickup>().objectAvailable = false; //turn off available object 
                
                }
            }
        }
    }
}
