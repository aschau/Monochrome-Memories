using UnityEngine;
using System.Collections;

public class moveObject : MonoBehaviour {
    public bool activated = false;

	// Use this for initialization
	void Start () {
        //this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
	    if (!this.activated)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        this.GetComponent<Rigidbody2D>().drag = 5f;
	}
	
	// Update is called once per frame
	public void Update () {
        if (this.activated)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = false;
        }
	}
}
