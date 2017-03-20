using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class CardMenu: MonoBehaviour
{
    public bool isClicked = false;
    public Sprite currentImage;
    public Sprite newImage;
    public Vector3 newLocation;
    public Vector3 oldLocation;
    public AudioClip cardSound;
    public float volume;
    AudioSource source;

    private List<GameObject> cards = new List<GameObject>();
    private int index = -1;
    private bool cardSelecting = false;

    public void Awake()
    {
        source = this.transform.FindChild("Box Sound Effect").GetComponent<AudioSource>();
        GameObject[] tempCards = GameObject.FindGameObjectsWithTag("gameCards");

        foreach (GameObject card in tempCards)
        {
            if (cards.Count == 0)
            {
                cards.Add(card);
            }

            else
            {
                if (card.name[card.name.Length - 1] > cards[cards.Count - 1].name[cards[cards.Count - 1].name.Length - 1])
                {
                    cards.Add(card);
                }

                else
                {
                    for (int i = 0; i < cards.Count; i++)
                    {
                        if (card.name[card.name.Length - 1] < cards[i].name[cards[i].name.Length - 1])
                        {
                            cards.Insert(i, card);
                            break;
                        }
                    }
                }


            }
        }
    }

    public void Start()
    {
        newLocation = new Vector3(this.transform.position.x - 10, this.transform.position.y, this.transform.position.z);
        oldLocation = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        foreach (GameObject card in cards)
        {
            card.GetComponent<Animator>().SetBool("isDisabled", true);
            //card.GetComponent<Button>().interactable = false;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (!sceneControl.paused)
        {
            if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1) || (Input.GetAxisRaw("X360_DPadY") == 1 && !this.cardSelecting)))
            {
                this.cardSelecting = true;
                this.toggleCard(0);
            }

            else if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2) || (Input.GetAxisRaw("X360_DPadX") == 1 && !this.cardSelecting)))
            {
                this.cardSelecting = true;
                this.toggleCard(1);
            }

            if (Input.GetAxisRaw("X360_DPadY") == 0 && Input.GetAxisRaw("X360_DPadX") == 0)
            {
                this.cardSelecting = false;
            }
        }
    }

    public void toggleCard(int index)
    {
        if (index < this.cards.Count)
        {
            if (this.cards[index].activeSelf)
            {
                if (this.index != -1 && this.index != index && this.isClicked)
                {
                    this.cards[this.index].GetComponent<newCard>().onClick();
                    this.cards[this.index].GetComponent<newCard>().onPointerExit();
                }
                this.index = index;
                if (this.cards.Count >= index + 1)
                {
                    if (!this.isClicked)
                    {
                        this.onPointerEnter();
                        this.onClick();
                    }

                    if (!this.cards[index].GetComponent<newCard>().isClicked)
                    {
                        this.cards[index].GetComponent<newCard>().onPointerEnter();
                        this.cards[index].GetComponent<newCard>().onClick();
                    }
                    else
                    {
                        this.cards[index].GetComponent<newCard>().onClick();
                        this.cards[index].GetComponent<newCard>().onPointerExit();
                        this.onClick();
                        this.onPointerExit();
                    }

                }
            }
        }

    }

    public void onPointerEnter()
    {
        this.transform.position = newLocation;
    }

    public void onPointerExit()
    {
        if (this.isClicked == false)
        {
            this.GetComponent<Image>().sprite = currentImage;
            this.transform.position = oldLocation;
        }
    }

    public void onClick()
    {
        this.isClicked = !(this.isClicked);
        if (isClicked == true)
        {
            this.GetComponent<Image>().sprite = newImage;
            foreach (GameObject card in this.cards)
            {
                if (card.GetComponent<newCard>().isCollected == true)
                {
                    card.GetComponent<Animator>().SetBool("isDisabled", false);
                    //card.GetComponent<Button>().interactable = true;
                }
            }
        }
        else
        {
            this.GetComponent<Image>().sprite = currentImage;
            foreach (GameObject card in cards)
            {
                if (card.GetComponent<newCard>().isCollected == true)
                {
                    card.GetComponent<newCard>().turnOff();
                    card.GetComponent<Animator>().SetBool("isDisabled", true);
                    //card.GetComponent<Button>().interactable = false;
                }
            }
        }
        source.PlayOneShot(cardSound, volume);
    }

    public void toggleTriggers()
    {
        this.GetComponent<EventTrigger>().enabled = !this.GetComponent<EventTrigger>().enabled;
        foreach (GameObject card in this.cards)
        {
            card.GetComponent<EventTrigger>().enabled = !card.GetComponent<EventTrigger>().enabled;
        }
    }

}
