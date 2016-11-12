using UnityEngine;
using System.Collections;

public class fallObject : MonoBehaviour {
    public bool activated = false;
    public float speed = 5f;
    public float variance;
    private float originalPlace;
    //private bool falling = false;
    
    // Use this for initialization
    public  void Start()
    {
        originalPlace = this.transform.position.y;
        /*if (!this.activated)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = true;
        }*/
        //this.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
    }
    void FixedUpdate()
    {
        if (this.activated)
        {
            
            if (this.transform.position.y >= (this.originalPlace - this.variance) && this.transform.position.y <= this.originalPlace)
                this.transform.Translate(new Vector2(0, -this.speed * Time.deltaTime));
           /* if (this.GetComponent<moveObject>())
            {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }*/
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.transform.tag == "transporter")
        {
            this.originalPlace = other.transform.GetComponent<Transport>().newPlace.position.y; 
        }
        //this.activated = false;
    }
}
