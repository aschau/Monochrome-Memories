using UnityEngine;
using System.Collections;

public class cardFloat : MonoBehaviour {
    public float amplitude = 10;

    private float originalY;
    private float originalX;
    public bool horizontal = false;
    public float speed = 1;

	// Use this for initialization
	void Start () {
        this.originalY = this.transform.position.y;
        this.originalX = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (horizontal == true)
        {
            this.transform.position = new Vector2(originalX + (Mathf.Cos(Time.time * speed) * amplitude), transform.position.y);
        }
        else
        {
            this.transform.position = new Vector2(transform.position.x, originalY + (Mathf.Sin(Time.time * speed) * amplitude));
        }
	}

}
