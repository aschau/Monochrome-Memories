using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.transform.tag != "Player")
        {
            this.transform.parent.GetComponent<boxTriggers>().currentPosition = this.transform.parent.position;
            if (this.transform.parent.GetComponent<baseObject>())
            {
                this.transform.parent.GetComponent<baseObject>().originalPosition = this.transform.parent.position;
                this.transform.parent.GetComponent<baseObject>().activated = false;
            }
        }
    }
}
