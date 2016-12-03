using UnityEngine;
using System.Collections;

public class pauseMenuControl : MonoBehaviour {
    private GameObject settingsMenu, defaultMenu;

    void Awake()
    {
        this.settingsMenu = GameObject.Find("Settings Menu");
        this.defaultMenu = GameObject.Find("Default Menu");
    }

	// Use this for initialization
	void Start () {
        this.settingsMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadSettings()
    {
        this.settingsMenu.SetActive(true);
        this.defaultMenu.SetActive(false);
        GameObject.Find("backgroundMaterials").SetActive(false);
    }

    public void exitSettings()
    {
        this.defaultMenu.SetActive(true); 
        this.settingsMenu.SetActive(false);
        GameObject.Find("backgroundMaterials").SetActive(true);
    }
}
