using UnityEngine;
using System.Collections;

public class Transport : MonoBehaviour
{
    public Transform newPlace;
    // Use this for initialization
    void Start()
    {
        this.newPlace = this.transform.Find("newPlace");
    }

    // Update is called once per frame
    void Update()
    {
        //this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    /*void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "pushBlock" || other.transform.tag == "jumpBlock")
        {
            other.transform.position = newPlace.position;
        }
    }*/

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "pushBlock" || other.transform.tag == "jumpBlock")
        {
            other.transform.position = newPlace.position;
        }
        else if (other.transform.tag == "floatBlock" || other.transform.tag == "fallBlock")
        {
            if (other.transform.GetComponent<floatObject>() != null)
            {
                other.transform.GetComponent<floatObject>().originalY = newPlace.position.y;
                other.transform.GetComponent<floatObject>().activated = false;

            }
            if (other.transform.GetComponent<fallObject>() != null)
            {
                other.transform.GetComponent<fallObject>().originalPlace = newPlace.position.y;
                other.transform.GetComponent<fallObject>().activated = false;
            }
            other.transform.position = newPlace.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == "Player")
        //{
        //    this.GetComponent<BoxCollider2D>().isTrigger = false;
        //}
        if (other.tag == "pushBlock" || other.tag == "jumpBlock")
        {
            other.transform.position = newPlace.position;
        }
        else if (other.tag == "floatBlock" || other.tag == "fallBlock")
        {
            if (other.transform.GetComponent<floatObject>() != null)
            {
                other.transform.GetComponent<floatObject>().originalY = newPlace.position.y;
                other.transform.GetComponent<floatObject>().activated = false;

            }
            if (other.transform.GetComponent<fallObject>() != null)
            {
                other.transform.GetComponent<fallObject>().originalPlace = newPlace.position.y;
                other.transform.GetComponent<fallObject>().activated = false;
            }
            other.transform.position = newPlace.position;
        }
        //}
        //void OnTriggerStay2D(Collider2D other)
        //{
        //    if (other.tag == "Player")
        //        this.GetComponent<BoxCollider2D>().isTrigger = false;
        //}
        //void OnTriggerExit2D(Collider2D other)
        //{
        //    this.GetComponent<BoxCollider2D>().isTrigger = true;
        //}

    }
}