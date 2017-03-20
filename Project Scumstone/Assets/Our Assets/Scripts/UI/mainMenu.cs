using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class mainMenu : MonoBehaviour {
    public float speed = .5f;
    public AudioSource slime, Start_Game, button_sound, settings_sound, title_theme;

    public static int currentLevel = 1;

    private GameObject defaultMenu, settingsMenu, levelSelect, startButton, scumLogo;
    private Slider effectsSlider;
    private int currentIndex = 1;
    private GameObject level1, tutorialPanel;

    void Awake()
    {
        this.scumLogo = GameObject.Find("Logo"); 
        this.defaultMenu = GameObject.Find("Default Menu");
        this.settingsMenu = GameObject.Find("Settings Menu");
        this.effectsSlider = GameObject.Find("Sound Effects").GetComponentInChildren<Slider>();
        this.startButton = GameObject.Find("Start Game");
        this.levelSelect = GameObject.Find("Level Select");
        this.level1 = GameObject.Find("Level 1");
        this.tutorialPanel = GameObject.Find("Tutorial Prompt");
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
        this.levelSelect.SetActive(false);

        currentLevel = PlayerPrefs.GetInt("levelCount");

        if (currentLevel == 0)
        {
            currentLevel = 1;
        }
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
        this.settings_sound.Play();
        this.levelSelect.SetActive(true);
        this.tutorialPanel.SetActive(false);
        this.defaultMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(this.level1);
    }

    public void exitLevelSelect()
    {
        this.settings_sound.Play();
        this.defaultMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(this.startButton);
        this.levelSelect.SetActive(false);
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
