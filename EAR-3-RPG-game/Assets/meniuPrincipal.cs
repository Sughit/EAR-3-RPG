using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class meniuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
        public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale=1f;

    }

    public void ExitGame() 
    { 
        Application.Quit(); 
    }
}
