using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {
    public AudioClip doorSound;
    public float volume;
    public Renderer display;
    AudioSource source;
    public GameObject player1;
    public GameObject player2;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            display = other.GetComponent<SpriteRenderer>();
            other.GetComponent<playerController>().moveSpeed = 0;
            display.enabled = false;
            source.PlayOneShot(doorSound, volume);
            yield return new WaitForSeconds(0.5f);
        }
        if (other.name == "Player 2")
        {
            display = other.GetComponent<SpriteRenderer>();
            other.GetComponent<playerController>().moveSpeed = 0;
            display.enabled = false;
            source.PlayOneShot(doorSound, volume);
            yield return new WaitForSeconds(0.5f);
        }
        if (player1.GetComponent<playerController>().moveSpeed == 0 && player2.GetComponent<playerController>().moveSpeed == 0)
        {
            Application.LoadLevel("Level 2");
        }
    }
}
