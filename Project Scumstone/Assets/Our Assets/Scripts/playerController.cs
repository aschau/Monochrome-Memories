using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {
    private GameObject player1, player2;
    private GameObject topCover, bottomCover, shiftButton;
    

    void Awake()
    {
        this.player1 = GameObject.Find("Player");
        this.player2 = GameObject.Find("Player 2");
        this.topCover = GameObject.Find("topImage");
        this.bottomCover = GameObject.Find("bottomImage");
        if (playerMovement.isMobile == true)
        {
            this.shiftButton = GameObject.Find("ShiftButton");
        }
    }

	// Use this for initialization
	void Start () {
        
	}

    void Update()
    {
        if (playerMovement.isMobile == true)
        {
            if (shiftButton.GetComponent<touchScript>().shifted == true)
            {
                shiftButton.GetComponent<touchScript>().shifted = false;
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
        else
        {
            if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && (this.player1.activeSelf && this.player2.activeSelf))
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

            //to pick up objects
            


        }
    }

}