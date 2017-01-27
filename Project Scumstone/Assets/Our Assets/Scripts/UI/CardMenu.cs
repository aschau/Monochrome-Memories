using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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

    public void Awake()
    {
        GameObject[] tempCards = GameObject.FindGameObjectsWithTag("gameCards");
        foreach (GameObject card in tempCards)
        {
            if (cards.Count == 0 )
            {
                cards.Add(card);
            }

            else
            {
                if (card.name[card.name.Length - 1] > cards[cards.Count-1].name[cards[0].name.Length - 1])
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
                        }
                    }
                }
                

            }
            card.SetActive(false);
        }


        //this.cards = tempCards;

    }

    public void Start()
    {
        newLocation = new Vector3(this.transform.position.x - 10, this.transform.position.y, this.transform.position.z);
        oldLocation = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        source = this.transform.FindChild("Box Sound Effect").GetComponent<AudioSource>();
        this.onPointerEnter();
        this.onClick();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
        {
            this.cards[0].GetComponent<newCard>().onClick();
            if (this.cards[0].GetComponent<newCard>().isClicked)
            {
                this.cards[0].GetComponent<newCard>().onPointerEnter();
            }
            else
            {
                this.cards[0].GetComponent<newCard>().onPointerExit();
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
                    card.SetActive(true);
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
                    card.SetActive(false);
                }
            }
        }
        source.PlayOneShot(cardSound, volume);
    }



}
