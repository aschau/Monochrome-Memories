using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scumstone : MonoBehaviour
{
    public AudioSource slime;
    // Use this for initialization
    void Start()
    {
        slime.Play();
        StartCoroutine(LateCall());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("mainMenu");
    }
}