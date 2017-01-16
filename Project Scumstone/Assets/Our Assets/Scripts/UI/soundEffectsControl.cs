﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class soundEffectsControl : MonoBehaviour {
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
    }
}