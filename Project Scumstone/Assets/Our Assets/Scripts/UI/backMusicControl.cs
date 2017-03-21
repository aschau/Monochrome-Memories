using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class backMusicControl : MonoBehaviour {
	private AudioSource backgroundMusic;
    private AudioSource backgroundMusicBottom; 
    static float sliderAmount = 1f;
    private float originalVolume;
    private float originalVolume2; 
    
    void Awake()
    {
        if (PlayerPrefs.HasKey("musicAmount"))
        {
            sliderAmount = PlayerPrefs.GetFloat("musicAmount");

        }

        else
        {
            sliderAmount = 1f;
        }

        this.backgroundMusic = GameObject.Find("Black World Music").GetComponent<AudioSource>();
        this.backgroundMusicBottom = GameObject.Find("White World Music").GetComponent<AudioSource>(); 
        this.originalVolume = this.backgroundMusic.volume;
        this.originalVolume2 = this.backgroundMusicBottom.volume; 
        this.backgroundMusic.volume = this.originalVolume * sliderAmount;
        this.backgroundMusicBottom.volume = this.originalVolume2 * sliderAmount;
        this.GetComponent<Slider>().value = sliderAmount;

    }

    // Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        sliderAmount = this.GetComponent<Slider>().value;
	}

    public void setVolume()
    {
        this.backgroundMusic.volume = this.originalVolume * this.GetComponent<Slider>().value;
        this.backgroundMusicBottom.volume = this.originalVolume2 * this.GetComponent<Slider>().value;
        sliderAmount = this.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("musicAmount", sliderAmount);
        PlayerPrefs.Save(); 
    }
}
