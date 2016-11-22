using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cardCollection : MonoBehaviour {
    public GameObject cardToBe;
    public AudioClip cardCollected;
    private float volume = 0.8f;
    AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<ParticleSystem>().Stop();
            this.cardToBe.SetActive(true);
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            source.PlayOneShot(cardCollected, volume);

            
        }
        
    }
}
