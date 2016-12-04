using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cardCollection : MonoBehaviour {
    public GameObject cardToBe;
    public AudioClip cardCollected;
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
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (cardCollection.half)
            {
                this.cardToBe.GetComponent<newCard>().isCollected = true;
                this.deckBox.GetComponent<CardMenu>().onClick();

            }
            else
            {
                half = true;
            }
            this.GetComponent<ParticleSystem>().Stop();
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            source.PlayOneShot(cardCollected, volume);
            
            

            
        }
        
    }
}
