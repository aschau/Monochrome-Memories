using UnityEngine;
using System.Collections;

public class moveObject : baseObject {

    public override void Awake()
    {
        base.Awake();
    }

    // Use this for initialization
	public override void Start () {
        base.Start();

	    if (!base.activated)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = true;
        }

        this.GetComponent<Rigidbody2D>().drag = 0f;
        base.particleColor = new Color32(68, 135, 255, 255);
	}
	
	// Update is called once per frame
    public override void activate()
    {
        base.activate();
        this.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    public override void deactivate()
    {
        base.deactivate();
        this.GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
