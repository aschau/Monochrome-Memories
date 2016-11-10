using UnityEngine;
using System.Collections;

public class droppingItem : MonoBehaviour {
    public Vector2 originalPosition;
    public AudioClip breakingSound;
    public AudioSource source;
	// Use this for initialization
	void Start () {
        originalPosition = this.transform.position;
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
            this.transform.position = originalPosition;
            this.transform.GetComponent<Rigidbody2D>().isKinematic = true;
            source = GetComponent<AudioSource>();
            source.Play();
        }
    }
}
