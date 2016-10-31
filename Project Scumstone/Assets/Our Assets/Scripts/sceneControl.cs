using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneControl : MonoBehaviour {
    public float speed = .5f;
    public AudioSource backgroundMusic, resetSound;
    
    private bool resetting = false;
    private Color color;
    private playerController playerControl;

    // Use this for initialization
    void Awake()
    {
        this.backgroundMusic = GameObject.Find("backgroundMusic").GetComponent<AudioSource>();
        this.resetSound = this.transform.FindChild("resetSound").GetComponent<AudioSource>();
        this.playerControl = GameObject.FindObjectOfType<playerController>();
    }

	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > 1 && Input.GetKey(KeyCode.R) && !resetting)
        {
            reset();
        }

        if (!this.resetting && this.GetComponent<Image>().color.a > 0)
        {
            fadeTransition(-this.speed);
        }

        if (this.resetting && this.GetComponent<Image>().color.a < 255)
        {
            fadeTransition(this.speed);
        }

	}

    void fadeTransition(float speed)
    {
        this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, this.GetComponent<Image>().color.a + (speed * Time.deltaTime));
    }


    public void reset()
    {
        this.resetting = true;
        Invoke("resetScene", 5);
        this.playerControl.enabled = false;
        this.backgroundMusic.Stop();
        this.resetSound.Play();
    }

    void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
