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
        source = this.transform.FindChild("Box Sound Effect").GetComponent<AudioSource>();
        foreach (GameObject card in cards)
        {
            card.SetActive(false);
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            this.toggleCard(0);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            this.toggleCard(1);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            this.toggleCard(2);
        }
    }

    public void toggleCard(int index)
    {
        if (this.cards.Count >= index+1)
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
        //source.PlayOneShot(cardSound, volume);
    }



}
