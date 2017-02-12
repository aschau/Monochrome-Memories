using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushObject : baseObject {

    public float speed = 5f;
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
    }
}
