using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPickup : MonoBehaviour {
    public bool objectAvailable, held; //checks whether an object is in the vicinty to pick up
    public GameObject interactiveObject;

    [HideInInspector]
    public Animator anim;
    private GameObject camera1, camera2;
    private AudioSource error_sound;

    void Awake()
    {
        this.anim = this.GetComponent<Animator>();
        this.camera1 = GameObject.Find("Black Camera");
        this.camera2 = GameObject.Find("White Camera");
        this.error_sound = GameObject.Find("Error Sound").GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {
        this.objectAvailable = false;
        this.held = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown("joystick button 1")) && this.name == playerMovement.player)
        {
            if (!held) //if the player is not already holding something then it may be able to pick something up 
            {

                if (this.objectAvailable) //the objects turn this boolean on if there is an object available to be picked up 
                {
                    Debug.Log("Picked up");
                    this.anim.SetBool("isCarrying", true);
                    if (this.transform.parent)
                    {
                        if (this.transform.parent.gameObject.GetInstanceID() == this.interactiveObject.gameObject.GetInstanceID())
                        {
                            this.transform.parent = null;
                        }
                    }

                    this.interactiveObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    this.interactiveObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    this.interactiveObject.transform.parent = this.transform;
                    this.interactiveObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1.2f, this.transform.position.z);
                    if (this.interactiveObject.GetComponent<baseObject>())
                    {
                        this.interactiveObject.GetComponent<baseObject>().isMoving = false;
                    }
                    this.held = true;
                    this.interactiveObject.GetComponent<boxTriggers>().touched = true;

                }
                else
                {
                    //error_sound.Play(); 
                }
            }
            else
            {
                Ray cameraRay = new Ray() ;
                if (playerMovement.player == "Player")
                {
                    if (this.GetComponent<SpriteRenderer>().flipX)
                    {
                        cameraRay = this.camera1.GetComponent<Camera>().ScreenPointToRay(this.camera1.GetComponent<Camera>().WorldToScreenPoint(new Vector3(this.transform.position.x - 1f, this.transform.position.y + 0.3f, this.transform.position.z)));

                    }

                    else
                    {
                        cameraRay = this.camera1.GetComponent<Camera>().ScreenPointToRay(this.camera1.GetComponent<Camera>().WorldToScreenPoint(new Vector3(this.transform.position.x + 1f, this.transform.position.y + 0.3f, this.transform.position.z)));
                    }
                }

                else if (playerMovement.player == "Player 2")
                {
                    if (this.GetComponent<SpriteRenderer>().flipX)
                    {
                        cameraRay = this.camera2.GetComponent<Camera>().ScreenPointToRay(this.camera2.GetComponent<Camera>().WorldToScreenPoint(new Vector3(this.transform.position.x - 1f, this.transform.position.y + 0.3f, this.transform.position.z)));
                    }

                    else
                    {
                        cameraRay = this.camera2.GetComponent<Camera>().ScreenPointToRay(this.camera2.GetComponent<Camera>().WorldToScreenPoint(new Vector3(this.transform.position.x + 1f, this.transform.position.y + 0.3f, this.transform.position.z)));
                    }
                }
                if (this.objectAvailable)
                {

                    RaycastHit2D hit = Physics2D.Raycast(new Vector2(cameraRay.origin.x, cameraRay.origin.y), new Vector2(cameraRay.direction.x, cameraRay.direction.y));
                    if (!hit)
                    {
                        DropObject();
                    }
                    else if (hit)
                    {
                        Debug.Log(hit.transform.name);
                        if (hit.transform.tag == "interactive")
                        {
                            DropObject();
                        }
                        else
                        {
                            error_sound.Play();
                        }
                    }

                        
                }
                    
            }
        }
    }
    private void DropObject()
    {
        if (this.interactiveObject.GetComponent<boxTriggers>().touched == true)
        {
            this.anim.SetBool("isCarrying", false);

            this.interactiveObject.transform.parent = null;
            this.interactiveObject.GetComponent<Rigidbody2D>().isKinematic = false;
            if (this.GetComponent<SpriteRenderer>().flipX)
            {
                this.interactiveObject.transform.position = new Vector3(this.transform.position.x - 0.8f, this.transform.position.y + 0.3f, this.transform.position.z);
            }

            else
            {
                this.interactiveObject.transform.position = new Vector3(this.transform.position.x + 0.8f, this.transform.position.y + 0.3f, this.transform.position.z);
            }
            if (this.interactiveObject.GetComponent<baseObject>())
            {
                this.interactiveObject.GetComponent<baseObject>().originalPosition = this.interactiveObject.transform.position;
                this.interactiveObject.GetComponent<baseObject>().activated = false;
            }
            this.held = false;
            this.interactiveObject.GetComponent<boxTriggers>().touched = false;
            this.interactiveObject = null;
            this.objectAvailable = false;
        }
    }
}