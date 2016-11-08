using UnityEngine;
using System.Collections;

public class droppingItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("Collided");
            this.transform.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}
