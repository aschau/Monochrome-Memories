using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullObject : baseObject {
    public Vector3 originalPosition;
    public override void Awake()
    {
        base.Awake();
    }

	// Use this for initialization
	void Start () {
        this.originalPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //This is code for holding the box
        if (!base.activated)
        {
            if (this.transform.parent != null)
            {
                Debug.Log("This keeps happening");
                this.transform.parent = null;
                this.transform.position = new Vector3(this.transform.position.x - 0.2f, this.transform.position.y - 0.2f, this.transform.position.z);
                //this.transform.Translate(new Vector3(this.originalPosition.x -0.4f, this.originalPosition.y - 0.4f, this.originalPosition.z));
                this.originalPosition = this.transform.position;
            }
        }

        //This is code to pull the box with the player. It is a bit wonky but works.
        /*if (base.activated && this.transform.GetChild(0).GetComponent<pullTrigger>().activated)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(new Vector2(3f * Time.deltaTime, 0f));
            }
        }
        else if (base.activated && this.transform.GetChild(1).GetComponent<pullTrigger>().activated)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(new Vector2(-3f * Time.deltaTime, 0f));
            }
        }*/


	}

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (base.activated && hit.tag == "Player")
        {
            if (this.transform.parent == null)
            {
                Debug.Log("Attached much");
                this.transform.position = new Vector3(this.transform.position.x + 0.2f, this.transform.position.y + 0.2f, this.transform.position.z);
                this.transform.parent = hit.transform;
            }
        }
    }

}
