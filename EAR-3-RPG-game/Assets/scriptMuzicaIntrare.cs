using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMuzicaIntrare : MonoBehaviour
{
    AudioSource audio;
    public GameObject Canvas;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        audio.UnPause();
        Canvas.GetComponent<AudioSource>().Pause();
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        Canvas.GetComponent<AudioSource>().UnPause();
        audio.Pause();
    }
}
