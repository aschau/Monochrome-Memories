using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyControl : MonoBehaviour {
    public int collected = 0;
    public string currentStory = "None";
    public List<string> collectedStory; //list by name of stories that are collected
    private GameObject Menu;

    void Awake()
    {
        this.Menu = GameObject.Find("Default Menu");
        DontDestroyOnLoad(this.gameObject);
    }
	// Use this for initialization
	void Start () {

	}
	
	// should override the playercontrols so that keypresses affect this menu and not the game 
    // shows different stories depending on mouse click
	void Update () {
		
	}
    
    // Occurs when the backpack is clicked and stories are displayed 
    void readingStory()
    {
        this.Menu.SetActive(false);
        this.transform.FindChild("Empty Story");
        

    }
}
