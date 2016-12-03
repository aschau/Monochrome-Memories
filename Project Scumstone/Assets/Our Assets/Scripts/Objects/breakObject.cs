using UnityEngine;
using System.Collections;

public class breakObject : baseObject {
    public Sprite broken;

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
            this.GetComponent<SpriteRenderer>().sprite = broken;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - this.GetComponent<Collider2D>().bounds.size.y / 2 + this.GetComponent<SpriteRenderer>().bounds.size.y / 2, this.transform.position.z);
            Destroy(this.GetComponent<Collider2D>());
            this.gameObject.AddComponent<PolygonCollider2D>();
            this.changed = true;
        }
    }
}
