using UnityEngine;
using System.Collections;
using DragonBones;

public class armatureControl : MonoBehaviour {
    bool p1Left, p2Left, p1Right, p2Right;

    void Awake()
    {
        //this.player1 = GameObject.Find("Player").GetComponent<UnityArmatureComponent>();
        //this.player2 = GameObject.Find("Player 2").GetComponent<UnityArmatureComponent>();
        //this.playerControl = GameObject.Find("playerControl").GetComponent<playerController>();
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    if (this.playerControl.playerNumber == 1)
        //    {
        //        this.p1Left = true;
        //        this.player1.transform.localScale = new Vector3(Mathf.Abs(this.player1.transform.localScale.x), this.player1.transform.localScale.y, this.player1.transform.localScale.z);
        //        this.player1.GetComponent<UnityArmatureComponent>().animation.FadeIn("Walking", 0.3f);
        //    }
        //}

        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    if (this.playerControl.playerNumber == 1)
        //    {
        //        this.p1Left = false;
        //        this.player1.animation.FadeIn("Idle", 0.5f);
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    if (this.playerControl.playerNumber == 1)
        //    {
        //        this.p1Right = true;
        //    }
        //}


        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    if (this.playerControl.playerNumber == 1)
        //    {
        //        this.p1Right = false;
        //    }
        //    if (this.playerControl.playerNumber == 1)
        //    {
        //        this.player1.animation.FadeIn("Idle", 0.5f);
        //    }
        //}

        //if (this.p1Left && this.p1Right)
        //{

        //}

        //else if (this.p1Left)
        //{
        //    if (this.playerControl.playerNumber == 1)
        //    {
        //        this.player1.transform.localScale = new Vector3(-this.player1.transform.localScale.x, this.player1.transform.localScale.y, this.player1.transform.localScale.z);
        //        this.player1.GetComponent<UnityArmatureComponent>().animation.FadeIn("Walking", 0.3f);
        //    }
        //}

        //else if (this.p1Left)
        //{

        //}

        //else if (!(this.p1Right && this.p1Left))
        //{

        //}
	}
}
