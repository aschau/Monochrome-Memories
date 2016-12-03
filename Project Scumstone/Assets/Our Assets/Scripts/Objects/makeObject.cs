using UnityEngine;
using System.Collections;

public class makeObject : baseObject {
    public Sprite repaired;

    private bool changed = false;

	// Use this for initialization
	public override void Start () {
        base.Start();
	}

    public override void activate()
    {
        base.activate();
        if (!this.changed)
        {
            if (this.GetComponent<AudioSource>() != null)
            {
                this.GetComponent<AudioSource>().Play();
            }
            this.GetComponent<SpriteRenderer>().sprite = repaired;
            Destroy(this.GetComponent<Collider2D>());
            this.gameObject.AddComponent<PolygonCollider2D>();
            this.changed = true; 
        }
    }
}
