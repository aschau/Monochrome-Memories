using UnityEngine;
using System.Collections;

public class pauseMenuControl : MonoBehaviour {
    private GameObject settingsMenu, defaultMenu, topCover, bottomCover, deck, sceneController;
    private playerController playerControl;
    private playerMovement player1, player2;

    void Awake()
    {
        if (GameObject.Find("playerControl"))
        {
            this.playerControl = GameObject.Find("playerControl").GetComponent<playerController>();
        }
        this.sceneController = GameObject.Find("Scene Control");
        this.settingsMenu = GameObject.Find("Settings Menu");
        this.defaultMenu = GameObject.Find("Default Menu");
        this.player1 = GameObject.Find("Player").GetComponent<playerMovement>();
        this.player2 = GameObject.Find("Player 2").GetComponent<playerMovement>();
        this.topCover = GameObject.Find("topImage");
        this.bottomCover = GameObject.Find("bottomImage");
    }

	// Use this for initialization
	void Start () {
        this.settingsMenu.SetActive(false);
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void toggleMenu()
    {
        if (this.playerControl != null)
        {
            this.playerControl.enabled = !this.playerControl.enabled;
        }

        if (this.player1 != null)
        {
            this.player1.enabled = !this.player1.enabled;
        }

        if (this.player2 != null)
        {
            this.player2.enabled = !this.player2.enabled;
        }

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

        this.settingsMenu.SetActive(false);
        this.defaultMenu.SetActive(true);
        this.gameObject.SetActive(!this.gameObject.activeSelf);
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
