using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
    private GameObject player1, player2;
    private Image topCover, bottomCover;

    void Awake()
    {
        this.player1 = GameObject.Find("Player");
        this.player2 = GameObject.Find("Player 2");
        this.topCover = GameObject.Find("topImage").GetComponent<Image>();
        this.bottomCover = GameObject.Find("bottomImage").GetComponent<Image>();
    }

	// Use this for initialization
	void Start () {
        this.bottomCover.enabled = true;
	}

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.E)) && (this.player1.activeSelf && this.player2.activeSelf))
        {
            if (playerMovement.player == "Player")
            {
                playerMovement.player = "Player 2";
                bottomCover.enabled = false;
                topCover.enabled = true;
            }

            else if (playerMovement.player == "Player 2")
            {
                playerMovement.player = "Player";
                topCover.enabled = false;
                bottomCover.enabled = true;
            }
        }

        else if (!this.player1.activeSelf && this.player2.activeSelf)
        {
            playerMovement.player = "Player 2";
            bottomCover.enabled = false;
            topCover.enabled = true;
        }

        else if (this.player1.activeSelf && !this.player2.activeSelf)
        {
            playerMovement.player = "Player";
            topCover.enabled = false;
            bottomCover.enabled = true;
        }
    }   
}