using UnityEngine;
using System.Collections;

public class activateObject : MonoBehaviour {
    public bool activated1, activated2, camera1, camera2, dualActivation = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (!dualActivation)
        {
            if (this.activated1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
            }
        }

        else
        {
            if (this.activated1 && this.activated2)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
            }

            else if (this.activated1 || this.activated2)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 220, 0);
            }
        }
	}
}
