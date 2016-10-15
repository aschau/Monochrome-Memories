using UnityEngine;
using System.Collections;

public class Duplicate : MonoBehaviour {
    public GameObject dup;
    public Transform newPlace;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            dup.transform.position = newPlace.position;
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

}
