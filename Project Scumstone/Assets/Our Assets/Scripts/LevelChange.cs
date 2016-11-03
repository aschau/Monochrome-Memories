using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {
    public AudioClip doorSound;
    public float volume;
    public Renderer display;
    AudioSource source;
    public GameObject player1;
    public GameObject player2;
    public int finished = 0;
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
            //display = other.GetComponent<SpriteRenderer>();
            //other.GetComponent<playerController>().moveSpeed = 0;
            //display.enabled = false;
            player1.SetActive(false);
            this.finished += 1;
            source.PlayOneShot(doorSound, volume);
            yield return new WaitForSeconds(0.2f);
        }
        if (other.name == "Player 2")
        {
            //display = other.GetComponent<SpriteRenderer>();
            //other.GetComponent<playerController>().moveSpeed = 0;
            //display.enabled = false;
            player2.SetActive(false);
            this.finished += 1;
            source.PlayOneShot(doorSound, volume);
            yield return new WaitForSeconds(0.2f);
        }
        if (this.finished >= 2)
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
