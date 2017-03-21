using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchAudio : MonoBehaviour {
   
    public AudioSource _AudioSource1;
    public AudioSource _AudioSource2;
    private successPad successPad1;
    private GameObject playerControl;

    void Awake()
    {
        this.successPad1 = GameObject.Find("TopTeleportPad").GetComponent<successPad>();
        this.playerControl = GameObject.Find("playerControl");
    }

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
        if (SceneManager.GetActiveScene().name == "Intro")
        {
            if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown("joystick button 2")) && this.successPad1.activated)
            {

                if (_AudioSource1.mute == false)
                {
                    // this._AudioSource1.GetComponent<AudioSource>().volume = 5 * (Time.deltaTime * 2);  


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

        else
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown("joystick button 2") && this.playerControl.activeSelf)
            {

                if (_AudioSource1.mute == false)
                {
                    // this._AudioSource1.GetComponent<AudioSource>().volume = 5 * (Time.deltaTime * 2);  


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
}
