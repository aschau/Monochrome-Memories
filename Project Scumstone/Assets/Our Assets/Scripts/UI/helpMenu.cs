using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class helpMenu : MonoBehaviour {
    private GameObject help,help1,help2,help3,RA,LA;
    private sceneControl sceneController;

    void Awake()
    {
        this.help = GameObject.Find("Help Menu");
        this.help1 = GameObject.Find("Help1");
        this.help2 = GameObject.Find("Help2");
        this.help3 = GameObject.Find("Help3");
        this.RA = GameObject.Find("RightArrow");
        this.LA = GameObject.Find("LeftArrow"); 
        this.sceneController = GameObject.Find("Scene Control").GetComponent<sceneControl>();
    }

	// Use this for initialization
	void Start () {
        this.help.SetActive(false);
        this.help2.SetActive(false); 
        this.help3.SetActive(false);
        //this.LA.SetActive(false); 
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown("joystick button 6"))
        {
            this.onClick();
            EventSystem.current.SetSelectedGameObject(this.RA);
        }
        if (!(EventSystem.current.currentSelectedGameObject) && this.help.activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(this.RA);
        }
        
	}

    public void onClick()
    {
        if ((sceneControl.paused && this.help.activeSelf) || (!sceneControl.paused && !this.help.activeSelf))
        {
            this.sceneController.togglePause();
            this.help.SetActive(!this.help.activeSelf);
        }
    }
}
