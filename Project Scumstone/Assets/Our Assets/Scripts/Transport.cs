using UnityEngine;
using System.Collections;

public class Transport : MonoBehaviour {
    public GameObject player;
    public Transform newPlace;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
	}

    /*void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "pushBlock" || other.transform.tag == "jumpBlock")
        {
            other.transform.position = newPlace.position;
        }
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else if (other.tag == "pushBlock" || other.tag == "jumpBlock" || other.tag == "floatBlock" || other.tag == "fallBlock")
        {
            other.transform.position = newPlace.position;

        }
    }
    /*void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
            this.GetComponent<BoxCollider2D>().isTrigger = false;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }*/

}
