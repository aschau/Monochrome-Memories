using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushObject : baseObject
{
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
        this.boxSize = this.GetComponent<Collider2D>().bounds.size;

        base.particleColor = new Color32(0, 150, 0, 255);
        this.moved = false;
    }

    public override void activate()
    {
        Debug.Log("activated");

        if (this.activation.activated1)
        {
            RaycastHit2D[] ray = Physics2D.RaycastAll(new Vector2(this.transform.position.x + this.boxSize.x / 2, this.transform.position.y), Vector2.right, .1f);

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
        else if (this.activation.dualActivation && this.activation.activated2)
        {
            RaycastHit2D[] ray = Physics2D.RaycastAll(new Vector2(this.transform.position.x + this.boxSize.x / 2, this.transform.position.y), Vector2.right, .1f);

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
    // Update is called once per frame
    public override void deactivate()
    {
        Debug.Log("deactivated");
        base.deactivate();
        RaycastHit2D[] ray = Physics2D.RaycastAll(new Vector2(this.transform.position.x - this.boxSize.x / 2, this.transform.position.y), Vector2.left, .1f);

        foreach (RaycastHit2D rh in ray)
        {
            if (!rh.collider.isTrigger && rh.collider.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
            {
                this.isMoving = false;
                return;
            }
        }

        if (this.transform.position.x > (this.originalPosition.x))
        {
            this.transform.Translate(new Vector2(-this.speed * Time.deltaTime, 0));
        }
        if (this.transform.position.x <= this.originalPosition.x)
        {
            this.isMoving = false;
        }

        base.activate();
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
                this.originalPosition = this.GetComponent<boxTriggers>().currentPosition;
            }
        }
    }
}
