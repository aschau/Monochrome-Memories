using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class endLevelObject : MonoBehaviour {
    public bool activated = false;
    private GameObject clickShift, player, playerController, touchShift, sceneControl;

    void Awake()
    {
        this.clickShift = GameObject.Find("clickShift");
        this.playerController = GameObject.Find("playerControl");
        this.touchShift = GameObject.Find("ShiftButton");
        this.sceneControl = GameObject.Find("Scene Control");
    }

	// Use this for initialization
	void Start () {

        if (this.clickShift)
        {
            this.clickShift.SetActive(false);
            this.playerController.SetActive(false);
        }

        if (this.touchShift)
        {
            if (SceneManager.GetActiveScene().name == "Level 1")
            {
                this.touchShift.SetActive(false);
                this.playerController.SetActive(false);
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            if (this.touchShift && this.activated)
            {
                if (this.touchShift.GetComponent<touchScript>().shifted)
                {
                    this.player.SetActive(false);
                    this.touchShift.SetActive(false);
                }
            }
            if (this.clickShift && this.activated)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
                {
                    this.player.SetActive(false);
                    this.clickShift.SetActive(false);
                }
            }
        }


        if (this.touchShift && this.activated)
        {
            if (this.touchShift.GetComponent<touchScript>().shifted)
            {
                this.player.SetActive(false);
                this.touchShift.SetActive(false);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.sceneControl.GetComponent<sceneControl>().levelComplete)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<playerMovement>().stopMoving();
                if (SceneManager.GetActiveScene().name == "Level 1")
                {
                    if (this.name == "endLevel2")
                    {
                        other.gameObject.SetActive(false);
                    }

                    else if (this.name == "endLevel1")
                    {
                        other.GetComponent<SpriteRenderer>().enabled = false;
                        other.GetComponent<Collider2D>().enabled = false;
                        if (playerMovement.isMobile)
                        {
                            this.touchShift.SetActive(true);
                        }

                        if (this.clickShift && !this.touchShift.activeSelf)
                        {
                            this.clickShift.SetActive(true);
                        }


                        this.player = other.gameObject;
                    }
                }
                else
                {
                    other.gameObject.SetActive(false);
                }
                this.GetComponentInChildren<AudioSource>().Play();
                this.activated = true;
            }
        }
    }

}
