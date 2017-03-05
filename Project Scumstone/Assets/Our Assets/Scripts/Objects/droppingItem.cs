using UnityEngine;
using System.Collections;

public class droppingItem : MonoBehaviour {
    private Vector2 originalPosition;
    public AudioClip breakingSound;
    private AudioSource source;

	// Use this for initialization

    void Start () {
        this.originalPosition = this.transform.position;
        this.transform.GetComponent<Rigidbody2D>().isKinematic = true;
        //if (this.transform.childCount >= 1)
            //this.transform.GetComponentInChildren<ParticleSystem>().Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.tag == "Player")
        {
            if (this.transform.GetComponent<Rigidbody2D>().isKinematic == false)
            {
                this.transform.position = this.originalPosition;
                this.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                this.transform.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            

        }
        else
        {
            this.transform.position = this.originalPosition;
            this.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
