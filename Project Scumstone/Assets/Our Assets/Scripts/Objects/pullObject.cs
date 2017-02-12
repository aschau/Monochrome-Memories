using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullObject : baseObject
{
    public float speed = 5f;
    public float variance;
    public float originalPlace;
    private Vector3 originalPosition;
    private bool moved;
    public override void Awake()
    {
        base.Awake();
    }

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        this.originalPlace = this.transform.position.x;
        this.originalPosition = this.transform.position;
        base.particleColor = new Color32(0, 150, 0, 255);
        this.moved = false;
    }

    public override void activate()
    {
        if (this.transform.position.x < (this.originalPlace + this.variance))
        {
            this.transform.Translate(new Vector2(this.speed * Time.deltaTime, 0));
        }
        if (this.transform.position.x == (this.originalPlace + this.variance)){
            this.isMoving = false;
        }

        base.activate();
    }
    // Update is called once per frame
    public override void deactivate()
    {
        base.deactivate();
        if (this.transform.position.x > this.originalPlace)
        {
            this.transform.Translate(new Vector2(-this.speed * Time.deltaTime, 0));
        }
        if (this.transform.position.x == this.originalPlace)
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
            if (this.GetComponent<interactiveBox>() != null)
            {
                this.originalPlace = this.GetComponent<boxTriggers>().currentPosition.x;
                this.originalPosition = this.GetComponent<boxTriggers>().currentPosition;
            }
        }
    }

}