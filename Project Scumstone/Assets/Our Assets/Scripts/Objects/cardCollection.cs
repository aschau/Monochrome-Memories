using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class cardCollection : MonoBehaviour {
    public GameObject cardToBe;
    public AudioSource cardCollected;
    private float volume = 0.8f;
    private static bool half = false;
    AudioSource source;
    GameObject otherHalf, deckBox;
	// Use this for initialization
    void Awake()
    {
        this.cardToBe.GetComponent<newCard>().isCollected = false;
        this.deckBox = GameObject.Find("Deck Box");
    }
	void Start () {
        half = false;
        this.cardToBe.SetActive(false);
        source = GetComponent<AudioSource>();
        if (this.name == "TopHalf")
        {
            otherHalf = GameObject.Find("BottomHalf");
        }
        else
        {
            otherHalf = GameObject.Find("TopHalf");
        }
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (this.cardToBe.GetComponent<Animator>().isInitialized)
        {
            if (this.cardToBe.GetComponent<Animator>().GetBool("isCollected") && !cardToBe.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(cardToBe.name))
            {
                this.cardToBe.GetComponent<Animator>().SetBool("isCollected", false);
                this.cardToBe.GetComponent<EventTrigger>().enabled = true;
            }
        }

	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (cardCollection.half)
            {
                this.cardToBe.GetComponent<newCard>().isCollected = true;
                this.cardToBe.SetActive(true);
                this.deckBox.GetComponent<CardMenu>().onClick();
                this.cardToBe.GetComponent<EventTrigger>().enabled = false;
                this.cardToBe.GetComponent<Animator>().SetBool("isCollected", true);
                this.cardToBe.GetComponent<Animator>().Play(this.cardToBe.name);
            }
            else
            {
                half = true;
            }
            this.GetComponent<ParticleSystem>().Stop();
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            cardCollected.Play(); 
        }
        
    }
}
