using UnityEngine;
using System.Collections;

public class floatObject : baseObject {
    public float speed = 5f;
    public float variance;
    //public float originalPlace;
    //private Vector3 originalPosition;
    private bool moved;
    public override void Awake()
    {
        base.Awake();
    }

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        //this.originalPlace = this.transform.position.x;
        //this.originalPosition = this.transform.position;
        base.particleColor = new Color32(0, 150, 0, 255);
        speed = 5f; 
        this.moved = false;
    }

    public override void activate()
    {
        this.GetComponent<Rigidbody2D>().isKinematic = true;
        if (this.transform.position.y < (this.originalPosition.y + this.variance))
        {
            this.transform.Translate(new Vector2(0, this.speed * Time.deltaTime));
        }
        if (this.transform.position.y == (this.originalPosition.y + this.variance))
        {
            this.isMoving = false;
        }

        base.activate();
    }
    // Update is called once per frame
    public override void deactivate()
    {
        base.deactivate();
        if (this.GetComponent<boxTriggers>() != null)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = false;
        }
        
        if (this.transform.position.y > this.originalPosition.y)
        {
            this.transform.Translate(new Vector2(0, -this.speed * Time.deltaTime));
        }
        if (this.transform.position.y == this.originalPosition.y)
        {
            this.isMoving = false;
        }
        //this.transform.position = this.originalPosition;
        //this.isMoving = false;        
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.transform.tag == "Player")
        {
            this.moved = true;
        }
        else
        {
            if (this.GetComponent<boxTriggers>() != null)
            {
                //this.originalPlace = this.GetComponent<boxTriggers>().currentPosition.x;
                this.originalPosition = this.GetComponent<boxTriggers>().currentPosition;
            }
        }
    }


}
