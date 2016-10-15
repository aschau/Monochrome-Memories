using UnityEngine;
using System.Collections;

public class jumpObject : MonoBehaviour {

    public bool activated = false;
    public float multiplier = 1.5f;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
        {
            if (other.tag == "Player")
            {
                Debug.Log("JUMP");
                other.GetComponent<playerController>().jumpSpeed = other.GetComponent<playerController>().originalJumpSpeed * multiplier;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (activated)
        {
            if (other.tag == "Player")
            {
                Debug.Log("OUT JUMP");
                other.GetComponent<playerController>().jumpSpeed = other.GetComponent<playerController>().originalJumpSpeed;
            }
        }

    }
}
