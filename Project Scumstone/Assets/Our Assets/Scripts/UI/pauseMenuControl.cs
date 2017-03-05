using UnityEngine;
using System.Collections;

public class pauseMenuControl : MonoBehaviour {
    private GameObject settingsMenu, defaultMenu, pauseMenu;
    private playerController playerControl;
    private sceneControl sceneController;
    void Awake()
    {
        this.sceneController = GameObject.Find("Scene Control").GetComponent<sceneControl>();
        this.settingsMenu = GameObject.Find("Settings Menu");
        this.defaultMenu = GameObject.Find("Default Menu");
        this.pauseMenu = GameObject.Find("Pause Menu");
    }

	// Use this for initialization
	void Start () {
        this.settingsMenu.SetActive(false);
        this.pauseMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.toggleMenu();
        }
	}


    public void toggleMenu()
    {
        if ((sceneControl.paused && this.pauseMenu.activeSelf) || (!sceneControl.paused && !this.pauseMenu.activeSelf))
        {
            this.sceneController.togglePause();
            this.exitSettings();
            this.pauseMenu.SetActive(!this.pauseMenu.activeSelf);
        }
    }

    public void loadSettings()
    {
        this.settingsMenu.SetActive(true);
        this.defaultMenu.SetActive(false);
    }

    public void exitSettings()
    {
        this.defaultMenu.SetActive(true); 
        this.settingsMenu.SetActive(false);
    }
}
