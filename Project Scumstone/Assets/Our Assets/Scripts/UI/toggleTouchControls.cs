using UnityEngine;
using System.Collections;

public class toggleTouchControls : MonoBehaviour {

    void Awake()
    {

    }

	// Use this for initialization
	void Start () {
        if (!playerMovement.isMobile)
        {
            this.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
