using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class levelSelectButton : MonoBehaviour {
    private GameObject tutorialPanel;
    private Button button;
    private int level;

    void Awake()
    {
        this.button = this.GetComponent<Button>();
        this.tutorialPanel = GameObject.Find("Tutorial Prompt");
    }

	// Use this for initialization
	void Start () {
        this.level = Convert.ToInt32(this.name.Substring(5));
	}
	
	// Update is called once per frame
	void Update () {
		if (this.level > levelSelect.currentLevel)
        {
            this.button.interactable = false;
        }
	}

    public void onClick()
    {
        if (this.level == 1)
        {
            this.tutorialPrompt(this.level);
        }
    }

    public void tutorialPrompt(int level)
    {
        this.tutorialPanel.SetActive(true);
    }
}
