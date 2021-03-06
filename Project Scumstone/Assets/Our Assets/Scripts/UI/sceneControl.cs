﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class sceneControl : MonoBehaviour {
    public float speed = .5f, resetTime;
    public string nextLevel;
    public bool levelComplete = false, mainLevel;
    [HideInInspector]
    public AudioSource backgroundMusic, resetSound, backgroundMusic2;
    public static bool paused;

    private bool resetting = false;
    private Color color;
    private playerController playerControl;
    private playerMovement player1, player2;
    private GameObject topCover, bottomCover, pause, deck, clickShift;
    private endLevelObject endlevel1, endlevel2;

    // Use this for initialization
    void Awake()
    {
        this.backgroundMusic = GameObject.Find("Black World Music").GetComponent<AudioSource>();
        this.backgroundMusic2 = GameObject.Find("White World Music").GetComponent<AudioSource>(); 
        this.resetSound = GameObject.Find("resetSound").GetComponent<AudioSource>(); 
        this.playerControl = GameObject.FindObjectOfType<playerController>();
        this.topCover = GameObject.Find("topImage");
        this.bottomCover = GameObject.Find("bottomImage");
        this.endlevel1 = GameObject.Find("BottomTeleportPad").GetComponent<endLevelObject>();
        this.endlevel2 = GameObject.Find("TopTeleportPad").GetComponent<endLevelObject>();
        this.player1 = GameObject.Find("Player").GetComponent<playerMovement>();
        this.player2 = GameObject.Find("Player 2").GetComponent<playerMovement>();
        this.pause = GameObject.Find("Pause Menu");
        this.deck = GameObject.Find("Deck Box");
        this.clickShift = GameObject.Find("clickShift");
    }

	void Start () {
        this.GetComponent<Image>().enabled = true;
        this.topCover.SetActive(false);
        this.resetTime = 5f;
        paused = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > 1 && Input.GetKey(KeyCode.R) && !resetting)
        {
            reset();
        }

        if (!this.resetting && this.GetComponent<Image>().color.a > 0)
        {
            fadeTransition(-this.speed);
        }

        if (this.resetting && this.GetComponent<Image>().color.a < 255)
        {
            fadeTransition(this.speed);
        }

        if (!this.player1.gameObject.activeSelf && this.player2.gameObject.activeSelf)
        {
            playerMovement.player = "Player 2";
            bottomCover.SetActive(false);
            topCover.SetActive(true);
        }

        else if (this.player1.gameObject.activeSelf && !this.player2.gameObject.activeSelf)
        {
            playerMovement.player = "Player";
            topCover.SetActive(false);
            bottomCover.SetActive(true);
        }

        if (this.endlevel1.activated && this.endlevel2.activated && !this.resetting)
        {
            Invoke("loadNext", this.resetTime);
            this.resetting = true;
            fadeTransition(this.speed);
            this.playerControl.enabled = false;
            this.backgroundMusic.Stop();
            this.backgroundMusic2.Stop(); 
            this.resetSound.Play();

            if (this.mainLevel && Convert.ToInt32(SceneManager.GetActiveScene().name.Substring(5)) == mainMenu.currentLevel)
            {
                mainMenu.currentLevel++;
                PlayerPrefs.SetInt("levelCount", mainMenu.currentLevel);
                PlayerPrefs.Save();
            }

        }

	}

    public void fadeTransition(float speed)
    {
        this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, this.GetComponent<Image>().color.a + (speed * Time.deltaTime));
    }

    public void reset()
    {
        this.resetting = true;
        if (!paused)
        {
            this.togglePause();
        }
        Invoke("resetScene", this.resetTime);
 
        this.backgroundMusic.Stop();
        this.resetSound.Play();
    }

    public void togglePause()
    {
        paused = !paused;
        this.playerControl.enabled = !this.playerControl.enabled;
        this.player1.enabled = !this.player1.enabled;
        this.player2.enabled = !this.player2.enabled;
        this.deck.GetComponent<CardMenu>().toggleTriggers();

        if (paused)
        {
            this.topCover.SetActive(true);
            this.bottomCover.SetActive(true);
        }

        else
        {
            if (playerMovement.player == "Player")
            {
                this.topCover.SetActive(false);
            }

            else if (playerMovement.player == "Player 2")
            {
                this.bottomCover.SetActive(false);
            }
        }
    }

    void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exit()
    {
        Invoke("loadMainMenu", resetTime);
        this.resetting = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void loadMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("mainMenu");
    }

    void loadNext()
    {
        SceneManager.LoadScene(this.nextLevel);
    }
}
