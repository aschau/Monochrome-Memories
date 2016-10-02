using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
    public float speed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector2(speed * Time.deltaTime, 0f));
        }

        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector2(-speed * Time.deltaTime, 0f));
        }

	}
}
