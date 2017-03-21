using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class levelSelectButton : MonoBehaviour {
    public float speed = .5f, resetTime = 5f;
    public Sprite level1Tutorial, level1, level2Tutorial, level3;

    private AudioSource startSound, music;
    private GameObject tutorialPanel;
    private Image screenFade;
    private Button button;
    private int level;
    private bool isFading = false;
    private string levelToLoad;

    void Awake()
    {
        this.button = this.GetComponent<Button>();
        this.tutorialPanel = GameObject.Find("Tutorial Prompt");
        this.screenFade = GameObject.Find("Screen Fade").GetComponent<Image>();
        this.music = GameObject.Find("Black World Music").GetComponent<AudioSource>();
        this.startSound = GameObject.Find("resetSound").GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {
        this.level = Convert.ToInt32(this.name.Substring(5));
	}
	
	// Update is called once per frame
	void Update () {
		if (this.level > mainMenu.currentLevel)
        {
            this.button.interactable = false;
        }

        if (this.isFading)
        {
            fadeTransition(this.speed);
        }
	}

    public void onClick()
    {
        if (this.level == 1)
        {
            this.tutorialPrompt();
        }

        else
        {
            this.startFade();
            if (this.level == 2)
            {
                this.levelToLoad = "Level 2 Tutorial";
                this.screenFade.sprite = this.level2Tutorial;
                Invoke("loadNext", this.resetTime);

            }

            else if (this.level == 3)
            {
                this.levelToLoad = "Level 3";
                this.screenFade.sprite = this.level3;
                Invoke("loadNext", this.resetTime);
            }
        }
    }

    public void tutorialPrompt()
    {
        this.tutorialPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(this.tutorialPanel.transform.FindChild("Yes").gameObject);
    }

    public void pressNo()
    {
        this.startFade();
        this.levelToLoad = "Level 1";
        this.screenFade.sprite = this.level1;
        Invoke("loadNext", this.resetTime);
    }

    public void pressYes()
    {
        this.startFade();
        this.levelToLoad = "Intro";
        this.screenFade.sprite = this.level1Tutorial;
        Invoke("loadNext", this.resetTime);
    }

    private void loadNext()
    {
        SceneManager.LoadScene(this.levelToLoad);
    }

    public void exitPrompt()
    {
        EventSystem.current.SetSelectedGameObject(this.gameObject);
        this.tutorialPanel.SetActive(false);
    }

    private void fadeTransition(float speed)
    {
        this.screenFade.color = new Color(this.screenFade.color.r, this.screenFade.color.g, this.screenFade.color.b, this.screenFade.color.a + (speed * Time.deltaTime));
    }

    private void startFade()
    {
        this.music.Stop();
        this.startSound.Play();
        this.isFading = true;
        this.screenFade.enabled = true;
    }

}
