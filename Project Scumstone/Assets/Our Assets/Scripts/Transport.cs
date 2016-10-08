using UnityEngine;
using System.Collections;

public class Transport : MonoBehaviour {
    public GameObject test;
    public GameObject player;
    public Transform newPlace;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pushBlock")
        {
            test = other.gameObject;
            other.transform.position = newPlace.position;
        }
        else if (other.tag == "Player")
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
            this.GetComponent<BoxCollider2D>().isTrigger = false;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

}
