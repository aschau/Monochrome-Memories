using UnityEngine;
using System.Collections;

public class SwitchAudio : MonoBehaviour {
   
    public AudioSource _AudioSource1;
    public AudioSource _AudioSource2;

	// Use this for initialization
	void Start ()
    {
        _AudioSource1.mute = false;
        _AudioSource2.mute = true; 
        _AudioSource1.Play();
        _AudioSource2.Play(); 
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            if (_AudioSource1.mute == false)
            {

                _AudioSource1.mute = true; 

                _AudioSource2.mute = false;

            }

            else if (_AudioSource2.mute == false)
            {

                _AudioSource2.mute = true;

                _AudioSource1.mute = false;

            }

        }
	}
}
