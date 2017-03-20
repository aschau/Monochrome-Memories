using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class mainMenu : MonoBehaviour {
    public float speed = .5f;
    public AudioSource slime; 
    public AudioSource Start_Game;
    public AudioSource button_sound;
    public AudioSource settings_sound;
    public AudioSource title_theme; 
    private GameObject defaultMenu, settingsMenu, startButton, scumLogo;
    private Slider effectsSlider;
    private int currentIndex = 1;
    void Awake()
    {
        this.scumLogo = GameObject.Find("Logo"); 
        this.defaultMenu = GameObject.Find("Default Menu");
        this.settingsMenu = GameObject.Find("Settings Menu");
        this.effectsSlider = GameObject.Find("Sound Effects").GetComponentInChildren<Slider>();
        this.startButton = GameObject.Find("Start Game");
    }
	// Use this for initialization
	void Start () {
        StartCoroutine(LateCall()); 
        if (Application.platform == RuntimePlatform.Android)
        {
            playerMovement.isMobile = true;
        }

        else
        {
            playerMovement.isMobile = false;
        }
        this.settingsMenu.SetActive(false);
        this.defaultMenu.SetActive(false);
	}

    void Update()
    {
        if (!EventSystem.current.currentSelectedGameObject && this.defaultMenu.activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(this.startButton);
        }

        else if (!EventSystem.current.currentSelectedGameObject && this.settingsMenu.activeSelf)
        {
            EventSystem.current.SetSelectedGameObject(this.effectsSlider.gameObject);
        }
    }

    IEnumerator LateCall()
    {
        slime.Play(); 
        yield return new WaitForSeconds(3);
        this.scumLogo.SetActive(false);      
        this.defaultMenu.SetActive(true); 
        title_theme.Play();
        //EventSystem.current.SetSelectedGameObject(this.startButton);
        
    }

    public void openSettings()
    {
        
        this.settings_sound.Play();
        this.settingsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(this.effectsSlider.gameObject);
        this.defaultMenu.SetActive(false);
    }

    public void loadLevelSelect()
    {
        Start_Game.Play();
        SceneManager.LoadScene("Level Select");
    }

    public void exitGame()
    {
        Start_Game.Play();
        Application.Quit();
    }

    public void exitSettings()
    {
        this.settings_sound.Play();
        this.defaultMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(this.startButton);
        this.settingsMenu.SetActive(false);
    }

    void fadeTransition(float speed)
    {
        this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, this.GetComponent<Image>().color.a + (speed * Time.deltaTime));
    }
    
}
