using UnityEngine;
using System.Collections;

public class playerCamera : MonoBehaviour {
    public Transform player;
    private Vector3 offset;

    void Awake()
    {
        if (this.name == "Black Camera")
        {
            this.player = GameObject.Find("Player").transform;
        }
        
        else if (this.name == "White Camera")
        {
            this.player = GameObject.Find("Player 2").transform;
        }
    }

	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(this.player.transform.position.x, this.player.transform.position.y + this.player.GetComponent<Collider2D>().bounds.size.y/2, this.transform.position.z);
        offset = this.transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
        if (this.player.gameObject.activeSelf)
        {
            this.transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + this.offset.y, player.transform.position.z + offset.z);
        }
	}
}
