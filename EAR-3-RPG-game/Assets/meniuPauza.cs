using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class meniuPauza : MonoBehaviour
{
    public GameObject meniuPauzaObj;
    public GameObject imagine;
     bool meniuDeschis;
     public Image Background;
     public Color ImageColor;
     private bool up = false;
    
    void Start()
    {
        meniuDeschis=false;
        
        ImageColor = Background.color;
        
    }
    void Update()
    {
        if(Time.timeScale==1f)
        {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale=0f;
            meniuPauzaObj.SetActive(true);
            imagine.SetActive(true);
            meniuDeschis=true;
        }
        }
        else if(meniuDeschis)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                         StartCoroutine(ModifyOpacity());;
                Time.timeScale=1f;
                meniuDeschis=false;
            }
        }
        
    }

    public void resume()
    {
                 StartCoroutine(ModifyOpacity());
        Time.timeScale=1f;
        meniuDeschis=false;
    }

     public void restart()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator ModifyOpacity() {
        ImageColor.a=1; //Full Opaque
                meniuPauzaObj.SetActive(false);
        for(int i = 0; i < 50; i++){
                ImageColor.a -= 0.02f;
                Background.color=ImageColor;
                yield return new WaitForSeconds(0.01f); //Wait
        }

        ImageColor.a=1f;
        Background.color=ImageColor;
        imagine.SetActive(false);
     }

     public void MainMenu()
    {
        SceneManager.LoadScene("MeniuPricipal");
    }
}

     