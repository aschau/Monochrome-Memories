using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enterGame : mainMenuButton {
    public float speed = 1f;
    
    private SpriteRenderer screenFade;
    private AudioSource resetSound, backgroundMusic;
    private bool starting = false;

    public override void Awake()
    {
        base.Awake();
        this.screenFade = GameObject.Find("Screen Fade").GetComponent<SpriteRenderer>();
        this.resetSound = GameObject.Find("resetSound").GetComponent<AudioSource>();
        this.backgroundMusic = GameObject.Find("backgroundMusic").GetComponent<AudioSource>();
    }

    public override void Start()
    {
        base.Start();
        this.screenFade.enabled = true;
    }

    public override void Update()
    {
        base.Update();
        if (!this.starting && this.screenFade.color.a > 0)
        {
            fadeTransition(-this.speed);
        }

        if (this.starting && this.screenFade.color.a < 255)
        {
            fadeTransition(this.speed);
        }
    }

    public override void onClick()
    {
        base.onClick();
        Invoke("startGame", 3f);
        this.backgroundMusic.Stop();
        this.resetSound.Play();
        this.starting = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void startGame()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Level 1");
    }

    void fadeTransition(float speed)
    {
        this.screenFade.color = new Color(this.screenFade.color.r, this.screenFade.color.g, this.screenFade.color.b, this.screenFade.color.a + (speed * Time.deltaTime));
    }
}
