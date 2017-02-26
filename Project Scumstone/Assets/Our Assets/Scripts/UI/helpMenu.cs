using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpMenu : MonoBehaviour {
    private GameObject settingsMenu, defaultMenu, topCover, bottomCover, deck, touchShift, helpMenu;
    private playerController playerControl;
    private sceneControl sceneController;
    private playerMovement player1, player2;

    void Awake()
    {
        if (GameObject.Find("playerControl"))
        {
            this.playerControl = GameObject.Find("playerControl").GetComponent<playerController>();
        }
        this.sceneController = GameObject.Find("Scene Control").GetComponent<sceneControl>();
        this.settingsMenu = GameObject.Find("Settings Menu");
        this.defaultMenu = GameObject.Find("Default Menu");
        this.player1 = GameObject.Find("Player").GetComponent<playerMovement>();
        this.player2 = GameObject.Find("Player 2").GetComponent<playerMovement>();
        this.topCover = GameObject.Find("topImage");
        this.bottomCover = GameObject.Find("bottomImage");
        this.touchShift = GameObject.Find("ShiftButton");
        this.helpMenu = GameObject.Find("Help Menu");
    }

	// Use this for initialization
	void Start () {
        this.helpMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H))
        {
            this.onClick();
        }
	}

    public void onClick()
    {
        this.sceneController.togglePause();
        this.helpMenu.SetActive(!this.helpMenu.activeSelf);
    }
}
