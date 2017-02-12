using UnityEngine;
using System.Collections;

public class MuteAudio : MonoBehaviour {

AudioSource audio;
    
    void Start() 
    {
    	audio = GetComponent<AudioSource>();
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.E))
            if (audio.mute)
                audio.mute = false;
            else
                audio.mute = true;
        
    }
}
