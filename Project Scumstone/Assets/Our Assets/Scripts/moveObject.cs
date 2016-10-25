using UnityEngine;
using System.Collections;

public class moveObject : MonoBehaviour {
    public bool activated = false;

	// Use this for initialization
	void Start () {
	    if (!this.activated)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = true;
        }
	}
	
	// Update is called once per frame
	public void Update () {
        if (this.activated)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = false;
        }
	}
}
