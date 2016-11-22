using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class endLevelObject : MonoBehaviour {
    public bool activated = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            this.GetComponent<AudioSource>().Play();
            this.activated = true;
        }
    }

}
