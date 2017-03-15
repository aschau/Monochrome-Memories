﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushObject : baseObject {
    private bool moved;
    public float speed = 5f;
    public float variance;
    private Vector3 boxSize;
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
        this.boxSize = this.GetComponent<Collider2D>().bounds.size;

        base.particleColor = new Color32(0, 150, 0, 255);
        this.moved = false;
    }

    public override void activate()
    {
        Debug.Log("activated");

        if (this.activation.activated1)
        {
            RaycastHit2D[] ray = Physics2D.RaycastAll(this.transform.position, Vector2.right, this.boxSize.x/2);

            if (ray.Length <= 2)
            {
                if (this.transform.position.x < (this.originalPosition.x + this.variance))
                {
                    this.transform.Translate(new Vector2(this.speed * Time.deltaTime, 0));
                }
                if (this.transform.position.x >= (this.originalPosition.x + this.variance))
                {
                    this.isMoving = false;
                }

                base.activate();
            }
            else
            {
                foreach (RaycastHit2D rh in ray)
                {
                    if (!rh.collider.isTrigger && rh.collider.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
                    {
                        this.isMoving = false;
                        return;
                    }
                }

                if (this.transform.position.x < (this.originalPosition.x + this.variance))
                {
                    this.transform.Translate(new Vector2(this.speed * Time.deltaTime, 0));
                }
                if (this.transform.position.x >= (this.originalPosition.x + this.variance))
                {
                    this.isMoving = false;
                }

                base.activate();
            }

        }
        else if (this.activation.dualActivation && this.activation.activated2)
        {
            RaycastHit2D[] ray = Physics2D.RaycastAll(this.transform.position, Vector2.right, this.boxSize.x/2);

            if (ray.Length <= 2)
            {
                if (this.transform.position.x < (this.originalPosition.x + this.variance))
                {
                    this.transform.Translate(new Vector2(this.speed * Time.deltaTime, 0));
                }
                if (this.transform.position.x >= (this.originalPosition.x + this.variance))
                {
                    this.isMoving = false;
                }

                base.activate();
            }
            else
            {
                foreach (RaycastHit2D rh in ray)
                {
                    if (!rh.collider.isTrigger && rh.collider.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
                    {
                        this.isMoving = false;
                        return;
                    }
                }

                if (this.transform.position.x < (this.originalPosition.x + this.variance))
                {
                    this.transform.Translate(new Vector2(this.speed * Time.deltaTime, 0));
                }
                if (this.transform.position.x >= (this.originalPosition.x + this.variance))
                {
                    this.isMoving = false;
                }

                base.activate();

            }

        }
    }
    // Update is called once per frame
    public override void deactivate()
    {
        Debug.Log("deactivated");
        base.deactivate();
        RaycastHit2D[] ray = Physics2D.RaycastAll(this.transform.position, Vector2.left, this.boxSize.x/2);
        //Debug.DrawLine(this.transform.position, new Vector3(this.transform.position.x + (Vector2.right.x * this.boxSize.x), this.transform.position.y, this.transform.position.z), new Color(0, 0, 132), 1000);

        if (ray.Length <= 2)
        {
            if (this.transform.position.x > this.originalPosition.x)
            {
                this.transform.Translate(new Vector2(-this.speed * Time.deltaTime, 0));
            }
            if (this.transform.position.x == this.originalPosition.x)
            {
                this.isMoving = false;
            }

        }
        else
        {
            foreach (RaycastHit2D rh in ray)
            {
                if (!rh.collider.isTrigger && rh.collider.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
                {
                    this.isMoving = false;
                    return;
                }
            }

            if (this.transform.position.x < (this.originalPosition.x + this.variance))
            {
                this.transform.Translate(new Vector2(this.speed * Time.deltaTime, 0));
            }
            if (this.transform.position.x >= (this.originalPosition.x + this.variance))
            {
                this.isMoving = false;
            }

            base.activate();
        }
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
                //this.originalPlace = this.GetComponent<boxTriggers>().currentPosition.x;
                this.originalPosition = this.GetComponent<boxTriggers>().currentPosition;
            }
        }
    }
    /*public float speed = 5f;
    public float variance;
    //public float originalPlace;
    public override void Awake()
    {
        base.Awake();
    }

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        //this.originalPlace = this.transform.position.x;
        base.particleColor = new Color32(0, 150, 0, 255);
    }

    public override void activate()
    {
        base.activate();
        if (this.transform.position.x < (this.originalPosition.x - this.variance))
        {
            this.transform.Translate(new Vector2(this.speed * Time.deltaTime, 0));
        }
    }
    // Update is called once per frame
    public override void deactivate()
    {
        base.deactivate();
        if (this.transform.position.x > this.originalPosition.x)
        {
            this.transform.Translate(new Vector2(0, -this.speed * Time.deltaTime));
        }
    }*/
}