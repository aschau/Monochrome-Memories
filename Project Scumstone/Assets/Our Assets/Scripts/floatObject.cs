using UnityEngine;
using System.Collections;

public class floatObject : MonoBehaviour {
    public bool activated = false;
    public float speed = 5f;

    // Use this for initialization
    public void Start()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        if (!this.activated)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    void FixedUpdate()
    {
        if (this.activated)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = false;
            this.transform.Translate(new Vector2(0, this.speed * Time.deltaTime));
        }
    }
}
