using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class mainMenuControl : MonoBehaviour {
    GameObject settings;
    string currentSelection;
    public GameObject exitImage, startImage, settingsImage;
    // the three strings are "Start", "Exit", and "Settings"

	// Use this for initialization
	void Start () {
        currentSelection = "Start";
        this.settings = GameObject.Find("Settings Menu");
        this.settings.SetActive(false);
        this.startImage.SetActive(true);
        this.settingsImage.SetActive(false);
        this.exitImage.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentSelection == "Start")
            {
                currentSelection = "Exit";
                this.exitImage.SetActive(true);
                this.startImage.SetActive(false);
            }
            else if (currentSelection == "Settings")
            {
                currentSelection = "Start";
                this.startImage.SetActive(true);
                this.settingsImage.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentSelection == "Start")
            {
                currentSelection = "Settings";
                this.startImage.SetActive(false);
                this.settingsImage.SetActive(true);

            }
            else if (currentSelection == "Exit")
            {
                currentSelection = "Start";
                this.exitImage.SetActive(false);
                this.startImage.SetActive(true);
            }
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentSelection == "Start")
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("Level 1");
            }
            else if (currentSelection == "Exit")
            {
                Debug.Log("It should exit");
            }
            else if (currentSelection == "Settings")
            {
                Debug.Log("The menu should appear");
            }
        }
	}

}
