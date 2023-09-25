using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalDialog : MonoBehaviour
{
    public oliverMove dialog;
    public GameObject[] linesArray;
    bool canShowFirstLine=true;
    public int index;
    public GameObject meniuMort;
    public Image Background;
     public Color ImageColor;
    public GameObject imagine;

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
            imagine.SetActive(true);
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
                            
     }
}
