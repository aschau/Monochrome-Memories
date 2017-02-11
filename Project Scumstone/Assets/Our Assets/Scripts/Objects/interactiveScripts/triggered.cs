using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggered : MonoBehaviour {
    public bool activated;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.tag == "interactive")
        {
            
            this.activated = true;
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        
        this.activated = false;
    }
}
