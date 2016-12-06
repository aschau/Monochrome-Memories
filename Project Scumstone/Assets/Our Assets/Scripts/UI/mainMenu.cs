using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
    private GameObject defaultMenu, settingsMenu;
    void Awake()
    {
        this.defaultMenu = GameObject.Find("Default Menu");
        this.settingsMenu = GameObject.Find("Settings Menu");
    }
	// Use this for initialization
	void Start () {
        this.settingsMenu.SetActive(false);
        if (Application.platform == RuntimePlatform.Android)
        {
            playerMovement.isMobile = true;
        }

        else
        {
            playerMovement.isMobile = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void openSettings()
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
