using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class soundEffectsControl : MonoBehaviour {
    private GameObject[] soundEffects;
    private float[] soundEffectVolumes;
    
    void Awake()
    {
        this.soundEffects = GameObject.FindGameObjectsWithTag("sound");
    }

	// Use this for initialization
	void Start () {
        //for (int i = 0; i < soundEffects.Length; i++)
        //{
        //    this.soundEffectVolumes[i] = this.soundEffects[i].GetComponent<AudioSource>().volume;
        //}
        this.GetComponent<Slider>().value = 1f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void setVolume()
    {
        for (int i = 0; i < this.soundEffects.Length; i++)
        {
            this.soundEffects[i].GetComponent<AudioSource>().volume = this.soundEffectVolumes[i] * this.GetComponent<Slider>().value;
        }
    }
}
