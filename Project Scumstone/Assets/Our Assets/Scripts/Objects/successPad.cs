using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class successPad : MonoBehaviour {
    public GameObject sceneControl, otherPlatform;
    public bool activated = false;
    private bool check = false;
    public AudioSource unlocked;

    void Awake()
    {
        this.sceneControl = GameObject.Find("Scene Control");
        this.unlocked = GameObject.Find("unlockedSound").GetComponent<AudioSource>();
        this.otherPlatform = GameObject.Find("TopTeleportPad");
    }
	// Use this for initialization
	void Start () {
        this.GetComponent<ParticleSystem>().Stop();
	}
	
	// Update is called once per frame
	void Update () {
        if (check == false)
        {
            if (this.name == "BottomTeleportPad")
            {
                if (this.otherPlatform.GetComponent<successPad>().activated == true && this.activated)
                {
                    this.check = true;
                    this.sceneControl.GetComponent<sceneControl>().levelComplete = true;
                    this.unlocked.Play();
                }
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.activated = true;
            this.GetComponent<ParticleSystem>().Play();
            
        }
    }
}
