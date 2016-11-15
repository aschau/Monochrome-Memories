using UnityEngine;
using System.Collections;

public class makeObject : MonoBehaviour {
    public bool activated = false;
    public Sprite repaired;

    private bool changed = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (this.activated && !this.changed)
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
