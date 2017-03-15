using UnityEngine;
using System.Collections;

public class droppingItem : MonoBehaviour {
    private Vector2 originalPosition;
    public AudioSource breakingSound, brokenSound;
    public float respawnDelay = 1.0f;
    public GameObject player;
    public int count;
    private bool resetting, touched;
    public float maxRotation = 5f;
    //public float amplitude = 5f;
    private float originalZ;
    public float speed = 10;

	// Use this for initialization

    void Start () {
        this.originalPosition = this.transform.position;
        this.transform.GetComponent<Rigidbody2D>().isKinematic = true;
        this.resetting = false;
        this.originalZ = this.transform.rotation.z;
        //if (this.transform.childCount >= 1)
            //this.transform.GetComponentInChildren<ParticleSystem>().Stop();
	}

    IEnumerator respawn() //delays the respawning of the branch to original position
    {
        yield return new WaitForSeconds(respawnDelay);
        this.resetting = false;
        this.transform.GetComponent<Rigidbody2D>().isKinematic = true;
        this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        this.touched = false;
        this.transform.position = this.originalPosition;
        yield return 0; 
    }

    IEnumerator shaking()
    {
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        yield return new WaitForSeconds(30f);
        yield return 0;
        
    }
	
	// Update is called once per frame
    void Update()
    {
        if (!this.touched) //When the player has not interacted with branch it should move
        {
            this.transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
            if (Mathf.RoundToInt(Time.fixedTime)%2 == 0)
            {
                StartCoroutine(shaking());
            }
        }
        if (!resetting)
        {
            if (player != null)
            {
                if (player.name == "Player 2")
                {

                    GameObject ground = GameObject.Find("Black Platform");
                    if (this.transform.position.y <= ground.transform.position.y)
                    {

                        brokenSound.Play();
                        this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                        //Debug.Log("It should be kinematic");
                        this.resetting = true;
                        StartCoroutine(respawn());
                    }
                }
                else if (player.name == "Player")
                {
                    GameObject ground = GameObject.Find("White Platform");
                    if (this.transform.position.y <= ground.transform.position.y)
                    {
                        brokenSound.Play();
                        this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                        this.resetting = true;
                        StartCoroutine(respawn());

                    }
                }
            }
        }
       
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.tag == "Player")
        {
            if (other.transform.position.y > this.transform.position.y)
            {
                this.touched = true;
                StartCoroutine(fall(other.transform.gameObject));
            }
        }
    }

    IEnumerator fall(GameObject collidedObject) //slight delay before branch falls
    {
        yield return new WaitForSeconds(0.2f);
        this.player = collidedObject.transform.gameObject;
        breakingSound.Play();
        this.transform.GetComponent<Rigidbody2D>().isKinematic = false;
        yield return 0;
    }
}

