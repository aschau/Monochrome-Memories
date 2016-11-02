using UnityEngine;
using System.Collections;

public class floatObject : MonoBehaviour {
    public bool activated = false;
    public float speed = 5f;
    public float variance = 0f;
    private float originalY = 0f;
    private float changedY = 0f;

    // Use this for initialization
    public void Start()
    {
        this.originalY = this.transform.position.y;
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
            if (this.transform.position.y <= (this.originalY + this.variance))
            {
                this.transform.Translate(new Vector2(0, this.speed * Time.deltaTime));
                this.changedY = this.speed * Time.deltaTime;
            }
            else
            {
                this.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "pushBlock")
        {
            other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y + this.changedY);
        }
        else
        {
            this.activated = false;
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {

        if (other.transform.tag == "pushBlock")
        {
            other.transform.position = new Vector2(other.transform.position.x, other.transform.position.y + this.changedY);
        }
    }
}
