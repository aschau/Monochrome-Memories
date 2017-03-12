﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullObject : baseObject
{
    public float speed = 5f;
    public float variance;
    //public float originalPlace;
    //private Vector3 originalPosition;
    private bool moved;
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
        if (this.activation.activated1)
        {
            RaycastHit2D[] ray = Physics2D.RaycastAll(this.transform.position, Vector2.right, this.boxSize.x);

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
                this.isMoving = false;
            }

        }
        else if (this.activation.dualActivation && this.activation.activated2)
        {
            RaycastHit2D[] ray = Physics2D.RaycastAll(this.transform.position, Vector2.right, this.boxSize.x);

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
                this.isMoving = false;
            }

        }
    }
    // Update is called once per frame
    public override void deactivate()
    {
        base.deactivate();

        RaycastHit2D[] ray = Physics2D.RaycastAll(this.transform.position, Vector2.left, this.boxSize.x);
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

            base.activate();
        }
        else
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
                //this.originalPlace = this.GetComponent<boxTriggers>().currentPosition.x;
                this.originalPosition = this.GetComponent<boxTriggers>().currentPosition;
            }
        }
    }

}