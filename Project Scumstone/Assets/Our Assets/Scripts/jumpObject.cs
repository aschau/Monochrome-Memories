using UnityEngine;
using System.Collections;

public class jumpObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("JUMP");
            other.GetComponent<playerController>().jumpSpeed = other.GetComponent<playerController>().jumpSpeed * 2;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OUT JUMP");
            other.GetComponent<playerController>().jumpSpeed /= 2;
        }
    }
}
