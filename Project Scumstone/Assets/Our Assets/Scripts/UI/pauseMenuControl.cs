using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class pauseMenuControl : MonoBehaviour {
    private GameObject settingsMenu, defaultMenu, pauseMenu, continueButton, musicSlider;
    private playerController playerControl;
    private sceneControl sceneController;
    void Awake()
    {
        this.sceneController = GameObject.Find("Scene Control").GetComponent<sceneControl>();
        this.settingsMenu = GameObject.Find("Settings Menu");
        this.defaultMenu = GameObject.Find("Default Menu");
        this.pauseMenu = GameObject.Find("Pause Menu");
        this.musicSlider = GameObject.Find("BGM");
        this.continueButton = GameObject.Find("Continue");
        this.settingsMenu.SetActive(false);
        this.pauseMenu.SetActive(false);
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            this.toggleMenu();
        }

        if (!EventSystem.current.currentSelectedGameObject && this.defaultMenu.activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(this.continueButton);
        }

        else if (!EventSystem.current.currentSelectedGameObject && this.settingsMenu.activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(this.musicSlider);
        }
	}


    public void toggleMenu()
    {
        if ((sceneControl.paused && this.pauseMenu.activeSelf) || (!sceneControl.paused && !this.pauseMenu.activeSelf))
        {
            this.sceneController.togglePause();
            this.exitSettings();
            this.pauseMenu.SetActive(!this.pauseMenu.activeSelf);

            if (this.pauseMenu.activeSelf)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(this.continueButton);
            }
        }
    }

    public void loadSettings()
    {
        this.settingsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(this.musicSlider);
        this.defaultMenu.SetActive(false);
    }

    public void exitSettings()
    {
        this.defaultMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(this.continueButton);
        this.settingsMenu.SetActive(false);
    }
}
