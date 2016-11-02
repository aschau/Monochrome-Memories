using UnityEngine;
using System.Collections;

public class fireOutDetect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("fallBlock") || other.CompareTag("pushBlock"))
        {
            this.transform.FindChild("playerHitBox").gameObject.SetActive(false);
            this.GetComponent<ParticleSystem>().Stop();
        }
    }
}
