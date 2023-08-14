using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogManagerNPC : MonoBehaviour
{
    public GameObject inRangeText;
    public bool isInRange;
    public GameObject[] linesArray;
    public questManager questMan;
    public GameObject quest;
    public int index;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inRangeText.SetActive(true);
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inRangeText.SetActive(false);
            isInRange = false;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(isInRange)
            {
                if(inRangeText.activeSelf)
                {
                    inRangeText.SetActive(false);
                    NextLine();
                }
                else
                {
                    NextLine();
                }
            }
        }
        if(isInRange == false)
        {
            if(index == linesArray.Length)
            {
                linesArray[index - 1].SetActive(false);
            }
            else
            {
                linesArray[index].SetActive(false);
            }
            index = 0;
        }
    }

    void NextLine()
    {
        if(index == linesArray.Length)
        {
            linesArray[index - 1].SetActive(false);
            if(quest.activeSelf == false)
            {
                questMan.AddQuest(quest);
            }
            else
            {
                Debug.Log("Quest already selected");
            }
            index = 0;
        }
        if(index != linesArray.Length)
        {
            if(index != 0)
            {
                linesArray[index - 1].SetActive(false);
            }
            linesArray[index].SetActive(true);
            index++;
            // if(index < linesArray.Length)
            // {
            //     index++;
            // }
            // else
            // {
            //     index = 0;
            // }
        }
    }
}
