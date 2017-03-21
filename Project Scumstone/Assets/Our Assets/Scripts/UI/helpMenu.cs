using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class helpMenu : MonoBehaviour {
    private GameObject help,help1,help2,help3,help4,RA,LA;
    private sceneControl sceneController;

    void Awake()
    {
        this.help = GameObject.Find("Help Menu");
        this.help1 = GameObject.Find("Help1");
        this.help2 = GameObject.Find("Help2");
        this.help3 = GameObject.Find("Help3");
        this.help4 = GameObject.Find("Help4"); 
        this.RA = GameObject.Find("RightArrow");
        this.LA = GameObject.Find("LeftArrow"); 
        this.sceneController = GameObject.Find("Scene Control").GetComponent<sceneControl>();
    }

	// Use this for initialization
	void Start () {
        this.help.SetActive(false);
        this.help2.SetActive(false); 
        this.help3.SetActive(false);
        this.help4.SetActive(false); 
        this.LA.SetActive(false); 
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
    public void RightArrow()
    {
        if (this.help1.activeSelf)
        {
            this.help2.SetActive(true);
            this.LA.SetActive(true); 
            this.help1.SetActive(false);     
        }
        else if (this.help2.activeSelf)
        {
            this.help3.SetActive(true);
            this.help2.SetActive(false); 
        }
        else if (this.help3.activeSelf)
        {
            this.RA.SetActive(false);
            EventSystem.current.SetSelectedGameObject(this.LA);
            this.help4.SetActive(true);
            this.help3.SetActive(false); 
        }
    }

    public void LeftArrow()
    {
        if (this.help4.activeSelf)
        {
            this.RA.SetActive(true);
            this.help3.SetActive(true); 
            this.help4.SetActive(false); 
        }
        else if (this.help3.activeSelf)
        {
            this.RA.SetActive(true); 
            this.help2.SetActive(true); 
            this.help3.SetActive(false);
        }
        else if (this.help2.activeSelf)
        {
            this.LA.SetActive(false);
            EventSystem.current.SetSelectedGameObject(this.RA);
            this.help1.SetActive(true);
            this.help2.SetActive(false); 
        }
    }
}
