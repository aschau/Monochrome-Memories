using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class levelSelect : MonoBehaviour {
    public static int currentLevel = 1;

    private GameObject level1, tutorialPanel;

    void Awake()
    {
        this.level1 = GameObject.Find("Level 1");
        this.tutorialPanel = GameObject.Find("Tutorial Prompt");
    }

	// Use this for initialization
	void Start () {
        EventSystem.current.SetSelectedGameObject(this.level1);
        this.tutorialPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void pressBack()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
