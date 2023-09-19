using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class mixajManele : MonoBehaviour
{
    public AudioMixer muzica;

    public Slider sliderMuzica;
    public Slider sliderSFX;
    

    void Start()
    {
        if(PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolumeMuzica();
            SetMusicVolumeSFX();
        }
    }
    public void SetMusicVolumeMuzica()
    {
        float volumeMuzica = sliderMuzica.value;
        muzica.SetFloat("muzica", volumeMuzica);
        PlayerPrefs.SetFloat("musicVolume", volumeMuzica);
    }
    public void SetMusicVolumeSFX()
    {
        float volumeSFX = sliderSFX.value;
        muzica.SetFloat("SFX", volumeSFX);
        PlayerPrefs.SetFloat("SFXVolume", volumeSFX);
    }
    private void LoadVolume()
    {
        sliderMuzica.value = PlayerPrefs.GetFloat("musicVolume");
        sliderSFX.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolumeMuzica();
        SetMusicVolumeSFX(); 
    }
}
