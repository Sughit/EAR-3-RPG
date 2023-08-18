using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class meniuPrincipal : MonoBehaviour
{
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
}
