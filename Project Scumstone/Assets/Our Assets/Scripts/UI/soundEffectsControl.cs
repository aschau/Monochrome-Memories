using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class soundEffectsControl : MonoBehaviour {
    public AudioSource sliderSound;

    private GameObject[] soundEffects;
    private float[] soundEffectVolumes;
    static float sliderAmount = 1f;

    void Awake()
    {
        this.soundEffects = GameObject.FindGameObjectsWithTag("sound");
        this.soundEffectVolumes = new float[this.soundEffects.Length];
        for (int i = 0; i < soundEffects.Length; i++)
        {
            this.soundEffectVolumes[i] = this.soundEffects[i].GetComponent<AudioSource>().volume;
        }

        for (int i = 0; i < this.soundEffects.Length; i++)
        {
            this.soundEffects[i].GetComponent<AudioSource>().volume = this.soundEffectVolumes[i] * sliderAmount;
        }

        if (SceneManager.GetActiveScene().name != "mainMenu")
        {
            this.sliderSound = GameObject.Find("unlockedSound").GetComponent<AudioSource>();
        }
    }

	// Use this for initialization
	void Start () {
        this.GetComponent<Slider>().value = sliderAmount;
	}
	
	// Update is called once per frame
	void Update () {
        sliderAmount = this.GetComponent<Slider>().value;
	}

    public void setVolume()
    {
        for (int i = 0; i < this.soundEffects.Length; i++)
        {
            this.soundEffects[i].GetComponent<AudioSource>().volume = this.soundEffectVolumes[i] * this.GetComponent<Slider>().value;
        }
        sliderAmount = this.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("slider", sliderAmount);
        PlayerPrefs.Save();
        this.sliderSound.Play();
        //if (this.soundEffects.Length > 0)
        //{
        //    this.soundEffects[0].GetComponent<AudioSource>().Play();
        //}
    }
}
