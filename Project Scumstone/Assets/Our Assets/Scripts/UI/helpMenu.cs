using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpMenu : MonoBehaviour {
    private GameObject help;
    private sceneControl sceneController;

    void Awake()
    {
        this.help = GameObject.Find("Help Menu");
        this.sceneController = GameObject.Find("Scene Control").GetComponent<sceneControl>();
    }

	// Use this for initialization
	void Start () {
        this.help.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown("joystick button 6"))
        {
            this.onClick();
        }
	}

    public void onClick()
    {
        if ((sceneControl.paused && this.help.activeSelf) || (!sceneControl.paused && !this.help.activeSelf))
        {
            this.sceneController.togglePause();
            this.help.SetActive(!this.help.activeSelf);
        }
    }
}
