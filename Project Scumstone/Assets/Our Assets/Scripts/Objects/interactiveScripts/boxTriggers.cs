using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxTriggers : MonoBehaviour {
    public bool stacked;
    public bool touched;
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
            this.currentPosition = this.transform.position;
        }
    }
}
