using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneControl : MonoBehaviour {
    public float speed = .5f;
    public GameObject backgroundMusic;
    public GameObject resetSound;
    private bool resetting = false;
    private Color color;
    // Use this for initialization
    void Awake()
    {
        this.backgroundMusic = GameObject.Find("backgroundMusic");
    }

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R) && !resetting)
        {
            Debug.Log("RAWR");
            resetting = true;
            Invoke("reset", 5);
            this.backgroundMusic.GetComponent<AudioSource>().Stop();
            this.resetSound.GetComponent<AudioSource>().Play();
        }

        if (!this.resetting && this.GetComponent<Image>().color.a > 0)
        {
            this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, this.GetComponent<Image>().color.a - (this.speed * Time.deltaTime));
        }

        if (this.resetting && this.GetComponent<Image>().color.a < 255)
        {
            this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, this.GetComponent<Image>().color.a + (this.speed * Time.deltaTime));
        }

	}


    void reset()
    {
        Debug.Log("RESTART DELAY");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
