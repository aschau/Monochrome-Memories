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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.sceneControl.GetComponent<sceneControl>().levelComplete)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<playerMovement>().stopMoving();
                other.gameObject.SetActive(false);
                this.activated = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (this.sceneControl.GetComponent<sceneControl>().levelComplete)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<playerMovement>().stopMoving();
                other.gameObject.SetActive(false);
                this.activated = true;
            }
        }
    }

}
