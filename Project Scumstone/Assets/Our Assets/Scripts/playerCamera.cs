using UnityEngine;
using System.Collections;

public class playerCamera : MonoBehaviour {
    public playerController player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = player.transform.position + offset;
	}
}
