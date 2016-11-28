using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class backMusicControl : MonoBehaviour {
	private AudioSource backgroundMusic;
    
    void Awake()
    {
        this.backgroundMusic = GameObject.Find("backgroundMusic").GetComponent<AudioSource>();
    }

    // Use this for initialization
	void Start () {
	    this.GetComponent<Slider>().value = backgroundMusic.volume;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setVolume()
    {
        this.backgroundMusic.volume = this.GetComponent<Slider>().value;
    }
}
