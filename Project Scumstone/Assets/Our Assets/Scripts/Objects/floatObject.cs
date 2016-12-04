using UnityEngine;
using System.Collections;

public class floatObject : baseObject {
    public float speed = 5f;
    public float variance = 0f;
    public float originalY = 0f;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        base.particleColor = new Color32(255, 200, 60, 255);
        this.originalY = this.transform.position.y;
        this.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public override void activate()
    {
        base.activate();
        this.GetComponent<Rigidbody2D>().isKinematic = true;

        if (this.transform.position.y <= (this.originalY + this.variance))
        {
            this.transform.Translate(new Vector2(0, this.speed * Time.deltaTime));
        }
    }

    public override void deactivate()
    {
        base.deactivate();
        if (this.transform.position.y >= this.originalY)
        {
            this.transform.Translate(new Vector2(0, -this.speed * Time.deltaTime));
        }
    }


}
