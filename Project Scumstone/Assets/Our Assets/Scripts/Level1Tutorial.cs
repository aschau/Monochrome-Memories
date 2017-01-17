using UnityEngine;
using System.Collections;

public class Level1Tutorial : MonoBehaviour {
    GameObject deckBox, selectCard, deckArrow, cardArrow;
    public GameObject otherObject;
    public bool completed;
    public bool completed2 = false;
    GameObject[] tutorialObjects;
	// Use this for initialization
	void Start () {
        tutorialObjects = GameObject.FindGameObjectsWithTag("tutorial");
        foreach (GameObject tutorials in tutorialObjects)
        {
            tutorials.GetComponent<SpriteRenderer>().enabled = false;
        }
        this.deckBox = GameObject.Find("openDeckBox");
        this.selectCard = GameObject.Find("clickCard");
        if (this.completed == false && this.name == "Deck Box")
        {
            selectCard.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (this.name == "Deck Box")
        {
            openDeck();
        }
        if (this.tag == "pushBlock")
        {
            pushObject();
        }
        if (this.name == "jumpPushCard")
        {
            selectedCard();
        }
        if (this.tag == "jumpBlock")
        {
            jumpObject();
        }
	}

    void openDeck()
    {
        if (this.GetComponent<CardMenu>().isClicked == true)
        {
            this.deckBox.SetActive(false);
            if (this.completed == false)
            {
                this.selectCard.SetActive(true);
                this.completed = true;
            }
        }
    }

    void selectedCard()
    {
        if (this.GetComponent<jumpPushCard>().isClicked == true)
        {
            this.selectCard.SetActive(false);
            if (this.otherObject.GetComponent<Level1Tutorial>().completed == false)
            {
                this.otherObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                this.completed = true;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        /*if (this.name == "secondJumpPushBlock")
        {
            GameObject test = GameObject.Find("JumpPush Block");
            if (test.GetComponent<activateObject>().activated2 && other.transform.tag == "Player")
            {
                if (this.completed2 != true)
                {
                    GameObject item2 = GameObject.Find("whiteWorldTrashCan");
                    item2.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                    this.completed2 = true;
                }
            }
        }*/
        
        if (other.transform.tag == "pushBlock") {
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            if (this.otherObject.name == "JumpPush Block" && this.otherObject.GetComponent<Level1Tutorial>().completed)
            {
                GameObject item3 = GameObject.Find("jumpAhead");
                item3.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (this.otherObject.GetComponent<Level1Tutorial>().completed == false)
            {
                this.otherObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                this.completed = true;
            }
        }
    }

    void jumpObject()
    {
        if (this.GetComponent<jumpObject>().activated == true)
        {
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            if (this.otherObject.GetComponent<Level1Tutorial>().completed == true)
            {
                GameObject nextTutorial = GameObject.Find("jump");
                nextTutorial.GetComponent<SpriteRenderer>().enabled = true;
                this.completed = true;
            }
        }
    }

    void pushObject()
    {
        if (this.GetComponent<activateObject>().activated1 == true)
        {
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            if (this.otherObject.GetComponent<Level1Tutorial>().completed == false)
            {
                this.otherObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                this.completed = true;
            }
        }
        if (this.name == "JumpPush Block")
        {
            if (this.completed && (this.GetComponent<activateObject>().activated2 == true))
            {
                GameObject tutorialItem = GameObject.Find("jump");
                tutorialItem.GetComponent<SpriteRenderer>().enabled = false;
                if (this.completed2 != true)
                {
                    tutorialItem = GameObject.Find("secondWhiteTrashCan");
                    tutorialItem.GetComponent<SpriteRenderer>().enabled = true;
                    this.completed2 = true;
                }
                
                
            }
        }
    }
}
