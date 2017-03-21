using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class storyItem : MonoBehaviour {
    public bool collected = false;
    public bool selected = false;
    public Sprite missingStory;
    public Sprite currentStory;
	// Use this for initialization
	void Start () {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.GetComponent<Image>().sprite = this.missingStory;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.collected)
        {
            this.GetComponent<Image>().sprite = this.currentStory;
        }

	}
    public void OnSelect()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        if (this.collected)
        {
            this.transform.GetChild(0).GetComponent<Image>().sprite = this.currentStory;
        }
        else
        {
            this.transform.GetChild(0).GetComponent<Image>().sprite = this.missingStory;
        }
    }
    public void Deselected()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
}
