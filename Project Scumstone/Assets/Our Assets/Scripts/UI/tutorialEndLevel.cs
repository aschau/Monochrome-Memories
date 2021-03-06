﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutorialEndLevel : MonoBehaviour
{
    public float speed = .5f;
    public float resetTime = 5f;
    public string nextLevel;
    [HideInInspector]
    public AudioSource backgroundMusic, resetSound;

    private bool resetting = false;
    private static bool specialReset = false;
    private Color color;
    private playerMovement player1, player2;
    private GameObject topCover, bottomCover, pause, deck, shiftButton, firstHalf, shift;
    private endLevelObject endlevel1, endlevel2;

    // Use this for initialization
    void Awake()
    {
        this.backgroundMusic = GameObject.Find("backgroundMusic").GetComponent<AudioSource>();
        this.resetSound = GameObject.Find("resetSound").GetComponent<AudioSource>();
        this.topCover = GameObject.Find("topImage");
        this.bottomCover = GameObject.Find("bottomImage");
        this.endlevel1 = GameObject.Find("endLevel1").GetComponent<endLevelObject>();
        this.endlevel2 = GameObject.Find("endLevel2").GetComponent<endLevelObject>();
        this.player1 = GameObject.Find("Player").GetComponent<playerMovement>();
        this.player2 = GameObject.Find("Player 2").GetComponent<playerMovement>();
        this.pause = GameObject.Find("Pause Menu");
        this.deck = GameObject.Find("Deck Box");
        this.shiftButton = GameObject.Find("ShiftButton");
        this.firstHalf = GameObject.Find("TopHalf");
        this.shift = GameObject.Find("clickShift");
        
    }

    void Start()
    {
        this.GetComponent<Image>().enabled = true;
        this.topCover.SetActive(false);
        this.pause.SetActive(false);
        this.shift.SetActive(false);
        //this.playerControl.enabled = false;

        if (playerMovement.isMobile)
        {
            this.shiftButton.SetActive(false);
        }
    }

    public void toggleMenu()
    {
        //this.playerControl.enabled = !this.playerControl.enabled;

        this.player1.enabled = !this.player1.enabled;
        this.player2.enabled = !this.player2.enabled;
        if (playerMovement.player == "Player")
        {
            this.topCover.SetActive(!this.topCover.activeSelf);
        }

        else
        {
            this.bottomCover.SetActive(!this.bottomCover.activeSelf);
        }

        if (this.deck)
        {
            this.deck.SetActive(!this.deck.activeSelf);
        }
        
        this.pause.SetActive(!this.pause.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > 1 && Input.GetKey(KeyCode.R) && !resetting)
        {
            reset();
        }

        if (!this.resetting && this.GetComponent<Image>().color.a > 0)
        {
            fadeTransition(-this.speed);
            if (specialReset == true)
            {
                //player1.stopMoving();
                player1.gameObject.SetActive(false);
                //GameObject.Find("Player").SetActive(false);
                playerMovement.player = "Player 2";
                this.topCover.SetActive(false);
                this.bottomCover.SetActive(false);
                if (this.firstHalf)
                {
                this.firstHalf.SetActive(false);                
                }
            }
        }

        if (this.resetting && this.GetComponent<Image>().color.a < 255)
        {
            fadeTransition(this.speed);
        }

        if (this.endlevel1.activated && !this.resetting)
        {
            //this.playerControl.enabled = true;

            if (playerMovement.isMobile == false)
            {
                //shiftButton.GetComponent<Button>().enabled = false;
                this.shift.SetActive(true);
            }

            else
            {
                this.shiftButton.SetActive(true);
            }
            
            if (playerMovement.isMobile)
            {
                if (shiftButton.GetComponent<touchScript>().shifted)
                {
                    this.shift.SetActive(false);
                    fadeTransition(this.speed);
                    this.resetting = true;
                    this.backgroundMusic.Stop();
                    this.topCover.SetActive(false);
                    this.bottomCover.SetActive(true);
                    specialReset = true;
                    Invoke("resetScene", this.resetTime);
                    this.player1.enabled = false;
                    this.player2.enabled = false;
                    this.backgroundMusic.Stop();
                    this.resetSound.Play();
                }
            }

            else if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                this.shift.SetActive(false);
                fadeTransition(this.speed);
                this.resetting = true;
                this.backgroundMusic.Stop();
                this.topCover.SetActive(false);
                this.bottomCover.SetActive(true);
                specialReset = true;
                Invoke("resetScene", this.resetTime);
                this.player1.enabled = false;
                this.player2.enabled = false;
                this.backgroundMusic.Stop();
                this.resetSound.Play();

            }
        
        }

        if (this.endlevel2.activated && !this.resetting)
        {
            Invoke("loadNext", 5);
            this.resetting = true;
            fadeTransition(this.speed);
            //this.playerControl.enabled = false;
            this.backgroundMusic.Stop();
            this.resetSound.Play();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.toggleMenu();
        }
    }

    void fadeTransition(float speed)
    {
        this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, this.GetComponent<Image>().color.a + (speed * Time.deltaTime));
    }

    public void reset()
    {
        this.resetting = true;
        if (specialReset == true)
        {
            this.topCover.SetActive(true);
            this.bottomCover.SetActive(false);
        }
        else {
            this.topCover.SetActive(false);
            this.bottomCover.SetActive(true);
        }
        
        Invoke("resetScene", this.resetTime);
        //this.playerControl.enabled = false;
        this.player1.enabled = false;
        this.player2.enabled = false;
        this.backgroundMusic.Stop();
        this.resetSound.Play();
    }

    void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exit()
    {
        Invoke("mainMenu", resetTime);
        this.resetting = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void mainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("mainMenu");
    }

    void loadNext()
    {
        SceneManager.LoadScene(this.nextLevel);
    }
}
