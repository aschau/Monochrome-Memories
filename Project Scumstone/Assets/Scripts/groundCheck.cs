using UnityEngine;
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
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onGround = false; 
    }
}
