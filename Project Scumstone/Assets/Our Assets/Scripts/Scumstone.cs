using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scumstone : MonoBehaviour
{
    public AudioSource slime;
    public float speed = .5f;

    private Image screenFade;
    private bool isFading = true;

    void Awake()
    {
        this.screenFade = this.GetComponent<Image>();
    }

    // Use this for initialization
    void Start()
    {
        slime.Play();
        //StartCoroutine(LateCall());
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isFading)
        {
            fadeTransition(this.speed);

            if (this.screenFade.color.a <= 0)
            {
                SceneManager.LoadScene("mainMenu");
            }
        }
    }
    //IEnumerator LateCall()
    //{
    //    yield return new WaitForSeconds(3);
    //    SceneManager.LoadScene("mainMenu");
    //}

    private void fadeTransition(float speed)
    {
        this.screenFade.color = new Color(this.screenFade.color.r, this.screenFade.color.g, this.screenFade.color.b, this.screenFade.color.a - (speed * Time.deltaTime));
    }
}