using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxTriggers : MonoBehaviour {
    public bool stacked, touched;
    public Vector3 currentPosition;
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
            this.GetComponent<boxTriggers>().currentPosition = this.transform.position;
            //if (this.GetComponent<baseObject>())
            //{
            //    this.GetComponent<baseObject>().originalPosition = this.transform.position;
            //    this.GetComponent<baseObject>().activated = false;
            //}
        }
    }
}
