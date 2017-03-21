using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storyItem : MonoBehaviour {
    public bool collected = false;
    public bool selected = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.collected == false)
        {
            //black picture
        }
        else
        {
            if (this.selected == true)
            {
                //selected picture 
            }
            else
            {
                //regular picture
            }
        }
	}
}
