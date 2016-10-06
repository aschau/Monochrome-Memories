using UnityEngine;
using System.Collections;

public class moveObject : MonoBehaviour {
    public bool activated = false;

	// Use this for initialization
	void Start () {
	    if (!activated)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (activated)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = false;
        }
	}
}
