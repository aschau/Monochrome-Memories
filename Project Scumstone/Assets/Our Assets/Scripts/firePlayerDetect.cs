﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class firePlayerDetect : MonoBehaviour {
    private sceneControl sceneController;
    void Awake()
    {
        this.sceneController = GameObject.FindObjectOfType<sceneControl>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.sceneController.reset();
        }
    }
}
