using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bridgeEnd : MonoBehaviour {
    private playerMovement player, player2;
    private GameObject currentPlayer, topImage, bottomImage, playerControl;
    private sceneControl sceneController;

    void Awake()
    {
        this.player = GameObject.Find("Player").GetComponent<playerMovement>();
        this.player2 = GameObject.Find("Player 2").GetComponent<playerMovement>();
        this.topImage = GameObject.Find("topImage");
        this.bottomImage = GameObject.Find("bottomImage");
        this.playerControl = GameObject.Find("playerControl");
        this.sceneController = GameObject.Find("Scene Control").GetComponent<sceneControl>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!this.player.enabled && !this.player2.enabled && !sceneControl.paused)
        {
            this.GetComponent<droppingItem>().activateDrop(this.currentPlayer);
            this.sceneController.fadeTransition(this.sceneController.speed);
            Invoke("backToMain", 5f);
        }
    }

    void backToMain()
    {
        SceneManager.LoadScene("mainMenu");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<playerMovement>().stopMoving();
            other.transform.GetComponent<playerMovement>().enabled = false;
            this.currentPlayer = other.transform.gameObject;
            if (other.name == "Player")
            {
                this.topImage.SetActive(true);
                this.bottomImage.SetActive(false);
                playerMovement.player = "Player 2";
            }

            else
            {
                this.topImage.SetActive(false);
                this.bottomImage.SetActive(true);
                playerMovement.player = "Player";
            }

            this.playerControl.SetActive(false);
        }
    }
}
