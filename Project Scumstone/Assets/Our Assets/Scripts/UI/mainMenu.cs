using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class mainMenu : MonoBehaviour {
    public Sprite[] backgrounds;
    public AudioSource Start_Game;
    public AudioSource button_sound;
    public AudioSource settings_sound; 
    private GameObject defaultMenu, settingsMenu;
    private Slider effectsSlider;
    private Image img;
    private int currentIndex = 1;
    void Awake()
    {
        this.defaultMenu = GameObject.Find("Default Menu");
        this.settingsMenu = GameObject.Find("Settings Menu");
        this.effectsSlider = GameObject.Find("Sound Effects").GetComponentInChildren<Slider>();
        this.img = this.defaultMenu.GetComponent<Image>();
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
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!this.settingsMenu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                button_sound.Play(); 
                this.currentIndex--;
                if (this.currentIndex == -1)
                {
                    this.currentIndex = this.backgrounds.Length - 1;
                }
                updateSprite();
            }

            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                button_sound.Play(); 
                this.currentIndex++;
                if (this.currentIndex == 3)
                {
                    this.currentIndex = 0;
                }
                updateSprite();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {

                if (this.currentIndex == 1)
                {
                    Start_Game.Play(); 
                    SceneManager.LoadScene("Level 1");
                }

                else if (this.currentIndex == 2)
                {
                    settings_sound.Play(); 
                    this.openSettings();
                }

                else if (this.currentIndex == 0)
                {
                    Start_Game.Play(); 
                    Application.Quit();
                }
            }
        }
	}

    private void updateSprite()
    {
        this.img.sprite = this.backgrounds[this.currentIndex];
    }

    public void openSettings()
    {
        this.settingsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(this.effectsSlider.gameObject);
        this.defaultMenu.SetActive(false);
    }

    public void exitSettings()
    {
        this.defaultMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        this.settingsMenu.SetActive(false);
    }
}
