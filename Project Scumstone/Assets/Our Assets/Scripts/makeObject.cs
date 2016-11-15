using UnityEngine;
using System.Collections;

public class makeObject : MonoBehaviour {
    public bool activated = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (activated)
        {
            this.enabled = false;
        }
	
	}
}
