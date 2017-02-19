using UnityEngine;
using System.Collections;

public class AudioFade : MonoBehaviour
{

    // Use this for initialization
    public static class AudioFadeOut
    {

        public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
        {
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            audioSource.Stop();
            audioSource.volume = startVolume;
        }

    }

    public static class AudioFadeIn
    {

        public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
        {
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume += startVolume * Time.deltaTime / FadeTime;

                yield return null;
            }

            audioSource.Play();
            audioSource.volume = startVolume;
        }

    }

    public AudioSource _AudioSource1;
    public AudioSource _AudioSource2;

    void Start()
    {
        _AudioSource1.volume = 0.5f;
        _AudioSource2.volume = 0.0f;
        _AudioSource1.Play();
        _AudioSource1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (_AudioSource1.volume > 0.0f)
            {

                IEnumerator fadeout_audio1 = AudioFadeOut.FadeOut(_AudioSource1, 0.2f);
                IEnumerator fadein_audio1 = AudioFadeIn.FadeIn(_AudioSource2, 0.2f);
                StartCoroutine(fadeout_audio1);
                StartCoroutine(fadein_audio1);
                StopCoroutine(fadeout_audio1);
                StopCoroutine(fadein_audio1);

            }

            else if (_AudioSource2.volume > 0.0f)
            {
                IEnumerator fadeout_audio2 = AudioFadeOut.FadeOut(_AudioSource2, 0.2f);
                IEnumerator fadein_audio2 = AudioFadeIn.FadeIn(_AudioSource1, 0.2f);
                StartCoroutine(fadeout_audio2);
                StartCoroutine(fadein_audio2);
                StopCoroutine(fadeout_audio2);
                StopCoroutine(fadein_audio2);

            }

        }
    }
}