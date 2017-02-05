using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullTrigger : MonoBehaviour {
    public bool activated;

	// Use this for initialization
    void Awake()
    {
        activated = false;
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D hit)
    {
        activated = true;
    }
    void OnTriggerExit2D(Collider2D hit)
    {
        //activated = false;
    }

}
