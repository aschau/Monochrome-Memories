using UnityEngine;
using System.Collections;

public class fallObject : MonoBehaviour {
    public bool activated = false;
    public float speed = 5f;
    //private bool falling = false;
    
    // Use this for initialization
    public  void Start()
    {
        if (!this.activated)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        //this.transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
    }
    void FixedUpdate()
    {
        if (this.activated)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = false;
            this.transform.Translate(new Vector2(0, -this.speed * Time.deltaTime));
           /* if (this.GetComponent<moveObject>())
            {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }*/
        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        this.activated = false;
    }
}
