using UnityEngine;
using System.Collections;

public class playerCamera : MonoBehaviour {
    public Transform player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(player.transform.position.x + offset.x, this.transform.position.y, player.transform.position.z + offset.z);
	}
}
