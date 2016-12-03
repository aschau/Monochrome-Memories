using UnityEngine;
using System.Collections;

public class fallObject : baseObject {
    public float speed = 5f;
    public float variance;
    public float originalPlace;
    
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        this.originalPlace = this.transform.position.y;
        base.particleColor = new Color32(0, 150, 0, 255);
    }

    public override void activate()
    {
        base.activate();
        if (this.transform.position.y >= (this.originalPlace - this.variance) && this.transform.position.y <= this.originalPlace)
        {
            this.transform.Translate(new Vector2(0, -this.speed * Time.deltaTime));
        }
    }

}
