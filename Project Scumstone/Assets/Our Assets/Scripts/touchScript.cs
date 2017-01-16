using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class touchScript : MonoBehaviour {
    public bool held = false;
    public bool shifted = false;
    public bool jump = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //this.held = false;
        //this.shifted = false;
	}
    public void onPointerClick()
    {
        this.shifted = true;
    }
    public void onPointerEnter(){

    }

    public void onPointerDown()
    {
        this.held = true;
    }

    public void onPointerUp()
    {
        this.held = false;
        //this.shifted = true;
    }

    public void onJump()
    {
        this.jump = true;
    }
}
