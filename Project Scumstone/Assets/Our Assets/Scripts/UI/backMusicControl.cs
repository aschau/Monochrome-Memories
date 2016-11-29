using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class backMusicControl : MonoBehaviour {
	private AudioSource backgroundMusic;
    static float sliderAmount = 1f;
    private float originalVolume;
    
    void Awake()
    {
        this.backgroundMusic = GameObject.Find("backgroundMusic").GetComponent<AudioSource>();
        this.originalVolume = this.backgroundMusic.volume;
    }

    // Use this for initialization
	void Start () {
        this.GetComponent<Slider>().value = sliderAmount;
        this.backgroundMusic.volume = this.originalVolume * sliderAmount;
    }
	
	// Update is called once per frame
	void Update () {
        sliderAmount = this.GetComponent<Slider>().value;
	}

    public void setVolume()
    {
        this.backgroundMusic.volume = this.originalVolume * this.GetComponent<Slider>().value;
    }
}
