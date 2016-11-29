using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
    private GameObject player1, player2;
    private GameObject topCover, bottomCover;

    void Awake()
    {
        this.player1 = GameObject.Find("Player");
        this.player2 = GameObject.Find("Player 2");
        this.topCover = GameObject.Find("topImage");
        this.bottomCover = GameObject.Find("bottomImage");
    }

	// Use this for initialization
	void Start () {
	}

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.E)) && (this.player1.activeSelf && this.player2.activeSelf))
        {
            if (playerMovement.player == "Player")
            {
                playerMovement.player = "Player 2";
                player1.GetComponent<playerMovement>().stopMoving();
                bottomCover.SetActive(false);
                topCover.SetActive(true);
            }

            else if (playerMovement.player == "Player 2")
            {
                playerMovement.player = "Player";
                player2.GetComponent<playerMovement>().stopMoving();
                topCover.SetActive(false);
                bottomCover.SetActive(true);
            }
        }
    }   
}