using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class meniuPrincipal : MonoBehaviour
{
        public GameObject principalMeniu;
        public GameObject meniuSetari; 
        public GameObject meniuTutorial;
        public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale=1f;
        colRepairQuest.numCollected=0;
        collectQuest.numCollected=0;
        repairQuest.numOfRepairs=0;

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
}
