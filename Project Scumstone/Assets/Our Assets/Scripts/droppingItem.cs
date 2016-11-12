using UnityEngine;
using System.Collections;

public class droppingItem : MonoBehaviour {
    private Vector2 originalPosition;
    public AudioClip breakingSound;
    private AudioSource source;

    public bool regenerate;
	// Use this for initialization

    void Start () {
        originalPosition = this.transform.position;
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
            if (this.tag != "floatBlock")
            {
                Debug.Log("Collided");
                this.transform.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
        else if (other.transform.tag != "pushBlock")
        {
            source = GetComponent<AudioSource>();
            source.Play();
            if (regenerate == true)
            {
                this.transform.position = originalPosition;
                this.transform.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                if (this.transform.childCount >= 1)
                {
                    this.transform.DetachChildren();
                }
                this.transform.GetComponent<BoxCollider2D>().enabled = false;
                this.transform.GetComponent<SpriteRenderer>().enabled = false;
            }
            
        }
    }
}
