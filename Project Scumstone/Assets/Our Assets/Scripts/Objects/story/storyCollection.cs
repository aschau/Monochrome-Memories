using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyCollection : MonoBehaviour {
    private GameObject storyControl;
    public string storyName;

    void Awake()
    {
        storyControl = GameObject.Find("Story");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.storyControl.GetComponent<storyControl>().collectedStory.Add(this.storyName);
            this.storyControl.GetComponent<storyControl>().currentStory = this.storyName;

            this.gameObject.SetActive(false);
        }
    }
}
