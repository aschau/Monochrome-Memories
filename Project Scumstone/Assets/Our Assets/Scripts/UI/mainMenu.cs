using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class mainMenu : MonoBehaviour {
    public AudioSource Start_Game;
    public AudioSource button_sound;
    public AudioSource settings_sound; 
    private GameObject defaultMenu, settingsMenu, startButton;
    private Slider effectsSlider;
    private int currentIndex = 1;
    void Awake()
    {
        this.defaultMenu = GameObject.Find("Default Menu");
        this.settingsMenu = GameObject.Find("Settings Menu");
        this.effectsSlider = GameObject.Find("Sound Effects").GetComponentInChildren<Slider>();
        this.startButton = GameObject.Find("Start Game");
    }
	// Use this for initialization
	void Start () {
        this.settingsMenu.SetActive(false);
        if (Application.platform == RuntimePlatform.Android)
        {
            playerMovement.isMobile = true;
        }

        else
        {
            playerMovement.isMobile = false;
        }

        EventSystem.current.SetSelectedGameObject(this.startButton);
	}

    void Update()
    {
        if (!EventSystem.current.currentSelectedGameObject)
        {
            EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
        }
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
}
