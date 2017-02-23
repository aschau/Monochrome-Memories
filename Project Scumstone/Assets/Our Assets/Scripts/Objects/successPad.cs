using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class successPad : MonoBehaviour
{
    public bool activated = false;
    private bool check = false;
    private GameObject sceneControl, otherPlatform, clickShift, touchShift, playerController, topImage, bottomImage;
    private AudioSource unlocked;

    void Awake()
    {
        this.sceneControl = GameObject.Find("Scene Control");
        this.unlocked = GameObject.Find("unlockedSound").GetComponent<AudioSource>();
        this.otherPlatform = GameObject.Find("TopTeleportPad");
        this.clickShift = GameObject.Find("clickShift");
        this.touchShift = GameObject.Find("ShiftButton");
        this.playerController = GameObject.Find("playerControl");
        this.topImage = GameObject.Find("topImage");
        this.bottomImage = GameObject.Find("bottomImage");

    }
    // Use this for initialization
    void Start()
    {
        this.GetComponent<ParticleSystem>().Stop();

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
    void Update()
    {
        if (check == false)
        {
            if (this.name == "BottomTeleportPad")
            {
                if (this.otherPlatform.GetComponent<successPad>().activated == true && this.activated)
                {
                    this.check = true;
                    this.sceneControl.GetComponent<sceneControl>().levelComplete = true;
                    this.unlocked.Play();
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            if (this.touchShift && this.activated)
            {
                if (this.touchShift.GetComponent<touchScript>().shifted)
                {
                    this.touchShift.SetActive(false);
                }
            }
            if (this.clickShift && this.activated)
            {
                if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && !this.playerController.activeSelf)
                {
                    this.bottomImage.GetComponent<Image>().color = new Color(0, 0, 0, 1);
                    this.bottomImage.GetComponent<CanvasGroup>().alpha = 0.5f;
                    this.clickShift.SetActive(false);
                    this.bottomImage.SetActive(false);
                    this.topImage.SetActive(true);
                    this.playerController.SetActive(true);
                    playerMovement.player = "Player 2";
                }
            }
        }


        if (this.touchShift && this.activated)
        {
            if (this.touchShift.GetComponent<touchScript>().shifted)
            {
                this.touchShift.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.activated = true;
            this.GetComponent<ParticleSystem>().Play();
            if (SceneManager.GetActiveScene().name == "Level 1" && this.name == "TopTeleportPad" && !this.playerController.activeSelf)
            {
                if (playerMovement.isMobile)
                {
                    this.touchShift.SetActive(true);
                }

                if (this.clickShift && !this.touchShift.activeSelf)
                {
                    this.clickShift.SetActive(true);
                }
            }
        }
    }
}
