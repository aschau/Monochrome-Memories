using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class endLevelObject : MonoBehaviour {
    public bool activated = false;
    private GameObject playerController, sceneControl;

    void Awake()
    {
        this.sceneControl = GameObject.Find("Scene Control");
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (this.sceneControl.GetComponent<sceneControl>().levelComplete)
        {
            if (other.collider.CompareTag("Player"))
            {
                other.collider.GetComponent<playerMovement>().stopMoving();
                other.gameObject.SetActive(false);
                this.GetComponentInChildren<AudioSource>().Play();
                this.activated = true;
            }
        }
    }

}
