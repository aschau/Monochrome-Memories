﻿using UnityEngine;
using System.Collections;

public class fallObject : MonoBehaviour {
    public float speed = 5f;
    public bool activated = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
        if (activated)
        {
            this.transform.Translate(new Vector2(0, -this.speed * Time.deltaTime));
        }
    }
}
