using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class storyControl : MonoBehaviour {
    public int collected = 0;
    public string currentStory = "None";
    public List<string> collectedStory; //list by name of stories that are collected
    private GameObject Menu;
    private GameObject story;
    private GameObject firstStory;

    void Awake()
    {
        this.Menu = GameObject.Find("Default Menu");
        this.story = GameObject.Find("StoryItems");
        this.firstStory = GameObject.Find("storyIcon1");
        this.story.SetActive(false);
        //DontDestroyOnLoad(this.gameObject);
    }
	// Use this for initialization
	void Start () {

	}
	
	// should override the playercontrols so that keypresses affect this menu and not the game 
    // shows different stories depending on mouse click
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.Menu.SetActive(true);
            this.story.SetActive(false);
        }
		
	}
    
    // Occurs when the backpack is clicked and stories are displayed 
    public void readingStory()
    {
        this.story.SetActive(true);
        EventSystem.current.SetSelectedGameObject(this.firstStory);
        this.Menu.SetActive(false);
        foreach (string item in collectedStory){
            GameObject desiredStory = GameObject.Find(item);
            desiredStory.GetComponent<storyItem>().collected = true;
        }

    }
}
