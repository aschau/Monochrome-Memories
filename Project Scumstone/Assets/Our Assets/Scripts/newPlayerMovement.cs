using UnityEngine;
using System.Collections;

public class newPlayerMovement : MonoBehaviour {
    public float maxSpeed = 3f, jump = 200f;

    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public Rigidbody2D body;
    public bool onGround;
    private Transform bottom;
    [SerializeField]
    private LayerMask layer;

    void Awake()
    {
        this.bottom = transform.Find("bottom");
        this.anim = this.GetComponent<Animator>();
        this.body = this.GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
	
	}
    // Update is called once per frame
    void Update()
    {
        this.onGround = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.bottom.position, .1f, this.layer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                this.onGround = true;
        }
    }
	
	void FixedUpdate () {


        if (this.onGround && Input.GetKey(KeyCode.W))
        {
            this.onGround = false;
            this.body.AddForce(new Vector2(0f, this.jump));
        }


	}
}
