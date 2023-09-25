using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class meniuPrincipal : MonoBehaviour
{
        public GameObject principalMeniu;
        public GameObject meniuSetari; 
        public GameObject meniuTutorial;
        public GameObject meniuCredits;
        public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale=1f;
        colRepairQuest.numCollected=0;
        collectQuest.numCollected=0;
        repairQuest.numOfRepairs=0;
        Cursor.visible=false;

    }

    public void ExitGame() 
    { 
        Application.Quit(); 
    }

    public void MeniuSetari()
    {
        principalMeniu.SetActive(false);
        meniuSetari.SetActive(true);
    }
    public void BackMeniuSetari()
    {
        meniuSetari.SetActive(false);
        principalMeniu.SetActive(true);
    }
    public void MeniuTutorial()
    {
        principalMeniu.SetActive(false);
        meniuTutorial.SetActive(true);
    }
    public void BackMeniuTutorial()
    {
        meniuTutorial.SetActive(false);
        principalMeniu.SetActive(true);
    }
    public void MeniuCredits()
    {
        principalMeniu.SetActive(false);
        meniuCredits.SetActive(true);
    }
    public void BackMeniuCredits()
    {
        meniuCredits.SetActive(false);
        principalMeniu.SetActive(true);
    }

    public void TwitterA()
    {
        Application.OpenURL("https://twitter.com/SughitGames");
    }
    public void TwitterE()
    {
        Application.OpenURL("https://twitter.com/LasP_X");
    }
    public void SoundImage()
    {
        Application.OpenURL("https://soundimage.org/");
    }
    public void Email()
    {
        Application.OpenURL("mailto:ear3.ro@gmail.com");
    }
}
