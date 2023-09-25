using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finalDialog : MonoBehaviour
{
    public oliverMove dialog;
    public GameObject[] linesArray;
    bool canShowFirstLine=true;
    public int index;
    public GameObject meniuMort;
    public GameObject meniuMort2;
    public GameObject meniuMort3;
    public GameObject meniuMort4;
    public Image Background;
     public Color ImageColor;
    public GameObject imagine;
    public  static bool end=false;

    void Update()
    {
        if(dialog.startDialog)
        {
            if(canShowFirstLine)
            {
                linesArray[0].SetActive(true);
                index=1;
                canShowFirstLine=false;
            }
            else if(Input.GetKeyDown(KeyCode.E))
            {
                NextLine();
            }
        }
    }

    void NextLine()
    {
        if(index == linesArray.Length-1)
        {
            linesArray[index - 1].SetActive(false);
                        end=true;
            StartCoroutine(ModifyOpacity());
            StartCoroutine(ModifyOpacityInapoi());
        }
        if(index != linesArray.Length)
        {
            if(index != 0)
            {
                linesArray[index - 1].SetActive(false);
            }
            linesArray[index].SetActive(true);
            index++;
        }
    }

    public IEnumerator ModifyOpacity() {
        imagine.SetActive(true);
        ImageColor.a=0; //Full Opaque
        for(int i = 0; i < 50; i++){
                ImageColor.a += 0.02f;
                Background.color=ImageColor;
                yield return new WaitForSeconds(0.01f); //Wait
        }
        ImageColor.a=1f;
        Background.color=ImageColor;
     }



     public IEnumerator ModifyOpacityInapoi() {
        yield return new WaitForSeconds(3f);
                meniuMort.SetActive(true);
        ImageColor.a=1; //Full Opaque
        for(int i = 0; i < 100; i++){
                ImageColor.a -= 0.01f;
                Background.color=ImageColor;
                yield return new WaitForSeconds(0.01f); //Wait
        }
        ImageColor.a=0f;
        Background.color=ImageColor;
        yield return new WaitForSeconds(2f);
            StartCoroutine(ModifyOpacity2());
     }
     public IEnumerator ModifyOpacity2() {
        imagine.SetActive(true);
        ImageColor.a=0; //Full Opaque
        for(int i = 0; i < 100; i++){
                ImageColor.a += 0.01f;
                Background.color=ImageColor;
                yield return new WaitForSeconds(0.01f); //Wait
        }
        ImageColor.a=1f;
        Background.color=ImageColor;
        yield return new WaitForSeconds(2f);
        StartCoroutine(ModifyOpacityInapoi2());
     }
     public IEnumerator ModifyOpacityInapoi2() {
        meniuMort.SetActive(false);
            meniuMort2.SetActive(true);
        ImageColor.a=1; //Full Opaque
        for(int i = 0; i < 100; i++){
                ImageColor.a -= 0.01f;
                Background.color=ImageColor;
                yield return new WaitForSeconds(0.01f); //Wait
         }
        ImageColor.a=0f;
        Background.color=ImageColor;
        yield return new WaitForSeconds(2f);
        StartCoroutine(ModifyOpacity3());
    }
     public IEnumerator ModifyOpacity3() {
        imagine.SetActive(true);
        ImageColor.a=0; //Full Opaque
        for(int i = 0; i < 100; i++){
                ImageColor.a += 0.01f;
                Background.color=ImageColor;
                yield return new WaitForSeconds(0.01f); //Wait
        }
        ImageColor.a=1f;
        Background.color=ImageColor;
        yield return new WaitForSeconds(2f);
        StartCoroutine(ModifyOpacityInapoi3());
     }

     public IEnumerator ModifyOpacityInapoi3() {
        meniuMort2.SetActive(false);
            meniuMort3.SetActive(true);
        ImageColor.a=1; //Full Opaque
        for(int i = 0; i < 100; i++){
                ImageColor.a -= 0.01f;
                Background.color=ImageColor;
                yield return new WaitForSeconds(0.01f); //Wait
         }
        ImageColor.a=0f;
        Background.color=ImageColor;
        yield return new WaitForSeconds(4f);
        StartCoroutine(ModifyOpacity4());
    }
    public IEnumerator ModifyOpacity4() {
        imagine.SetActive(true);
        ImageColor.a=0; //Full Opaque
        for(int i = 0; i < 100; i++){
                ImageColor.a += 0.01f;
                Background.color=ImageColor;
                yield return new WaitForSeconds(0.01f); //Wait
        }
        ImageColor.a=1f;
        Background.color=ImageColor;
        yield return new WaitForSeconds(2f);
        StartCoroutine(ModifyOpacityInapoi4());
     }
     public IEnumerator ModifyOpacityInapoi4() {
        meniuMort3.SetActive(false);
            meniuMort4.SetActive(true);
        ImageColor.a=1; //Full Opaque
        for(int i = 0; i < 100; i++){
                ImageColor.a -= 0.01f;
                Background.color=ImageColor;
                yield return new WaitForSeconds(0.01f); //Wait
         }
        ImageColor.a=0f;
        Background.color=ImageColor;
        yield return new WaitForSeconds(4f);
        StartCoroutine(ModifyOpacity5());
        }   
        public IEnumerator ModifyOpacity5() {
        imagine.SetActive(true);
        ImageColor.a=0; //Full Opaque
        for(int i = 0; i < 100; i++){
                ImageColor.a += 0.01f;
                Background.color=ImageColor;
                yield return new WaitForSeconds(0.01f); //Wait
        }
        ImageColor.a=1f;
        Background.color=ImageColor;
        yield return new WaitForSeconds(2f);
        Cursor.visible = true;
         SceneManager.LoadScene("MeniuPricipal");

     }
}   
