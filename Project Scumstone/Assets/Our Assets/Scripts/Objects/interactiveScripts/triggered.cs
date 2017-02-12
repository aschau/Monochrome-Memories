using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggered : MonoBehaviour {
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

            this.transform.parent.GetComponent<boxTriggers>().stacked = true;
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {

        this.transform.parent.GetComponent<boxTriggers>().stacked = false;
    }
}
