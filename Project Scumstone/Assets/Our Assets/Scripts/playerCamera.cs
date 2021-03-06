﻿using UnityEngine;
using System.Collections;

public class playerCamera : MonoBehaviour {
    public Transform player;
    public bool panning = false;
    public float speed = 10f;

    private Vector3 offset;
    private float minY, maxY;
    void Awake()
    {
        if (this.name == "Black Camera")
        {
            this.player = GameObject.Find("Player").transform;
            GameObject playerPlatform = GameObject.Find("White Platform");
            this.minY = playerPlatform.transform.position.y + this.GetComponent<Camera>().orthographicSize;
            this.maxY = GameObject.Find("Black Ceiling").transform.position.y - this.GetComponent<Camera>().orthographicSize;
        }
        
        else if (this.name == "White Camera")
        {
            this.player = GameObject.Find("Player 2").transform;
            GameObject playerPlatform = GameObject.Find("Black Platform");
            this.minY = playerPlatform.transform.position.y + this.GetComponent<Camera>().orthographicSize;
            this.maxY = GameObject.Find("White Ceiling").transform.position.y - this.GetComponent<Camera>().orthographicSize;
        }
    }

	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(this.player.transform.position.x, this.minY, this.transform.position.z);
        this.offset = this.transform.position - player.transform.position;

        //Debug.Log(this.transform.position.y);
        //Debug.Log("Min Y: " + this.minY);

	}
	
	void LateUpdate () {
        if (this.player.gameObject.activeSelf && !this.panning)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(player.transform.position.x + offset.x, Mathf.Clamp(this.player.position.y, this.minY, this.maxY), player.transform.position.z + offset.z), this.speed * Time.deltaTime);
        }
	}
}
