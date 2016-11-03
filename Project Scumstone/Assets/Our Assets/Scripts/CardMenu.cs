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

    public GameObject[] cards;

    public virtual void Awake()
    {
        this.cards = GameObject.FindGameObjectsWithTag("gameCards");
        foreach (GameObject card in cards)
        {
            card.SetActive(false);
        }
    }

    public virtual void Start()
    {
        newLocation = new Vector3(this.transform.position.x - 10, this.transform.position.y, this.transform.position.z);
        oldLocation = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void onPointerEnter()
    {
        //this.GetComponent<Image>().sprite = newImage;
        this.transform.position = newLocation;

        //yield return new WaitForSeconds(0.2f);
    }

    public virtual void onPointerExit()
    {
        if (this.isClicked == false)
        {
            this.GetComponent<Image>().sprite = currentImage;
            this.transform.position = oldLocation;
        }

    }

    public virtual void onClick()
    {
        this.isClicked = !(this.isClicked);
        if (isClicked == true)
        {
            this.GetComponent<Image>().sprite = newImage;
            foreach (GameObject card in this.cards)
            {
                card.SetActive(true);

            }
        }
        else
        {
            this.GetComponent<Image>().sprite = currentImage;
            foreach (GameObject card in cards)
            {
                card.GetComponent<newCard>().turnOff();
                card.SetActive(false);

            }
        }
        source.PlayOneShot(cardSound, volume);
    }



}
