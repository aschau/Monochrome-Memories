using UnityEngine;
using System.Collections;

public class droppingItem : MonoBehaviour {
    private Vector2 originalPosition;
    public AudioSource breakingSound;
    private int count;

	// Use this for initialization

    void Start () {
        this.originalPosition = this.transform.position;
        this.transform.GetComponent<Rigidbody2D>().isKinematic = true;
        this.count = 0;
        //if (this.transform.childCount >= 1)
            //this.transform.GetComponentInChildren<ParticleSystem>().Stop();
	}
	
	// Update is called once per frame
    void Update()
    {
        if (count >= 15)
        {
            this.transform.position = this.originalPosition;
            this.GetComponent<Rigidbody2D>().isKinematic = true;
            this.count = -1;
        }
        else
        {
            if (this.count > -1)
            {
                this.count += 1;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.tag == "Player")
        {
            if (other.transform.position.y > this.transform.position.y)
            {
                breakingSound.Play(); 
                this.transform.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
        else
        {
            this.count = 0;
        }
    }
}
