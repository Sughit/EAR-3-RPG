using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalDialog : MonoBehaviour
{
    public oliverMove dialog;
    public GameObject[] linesArray;
    bool canShowFirstLine=true;
    public int index;
    public GameObject meniuMort;

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
            Time.timeScale=0;
            meniuMort.SetActive(true);
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
}
