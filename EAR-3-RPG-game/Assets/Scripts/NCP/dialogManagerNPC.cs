using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogManagerNPC : MonoBehaviour
{
    public GameObject inRangeText;
    public bool isInRange;
    public GameObject[] linesArray;
    public GameObject[] linesEndArray;
    public questManager questMan;
    public GameObject quest;
    public int index;
    public bool questAccepted;

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
            if(isInRange && collectQuest.questCompleted)
            {
                if(inRangeText.activeSelf)
                {
                    inRangeText.SetActive(false);
                    NextEndLine();
                }
                else
                {
                    NextEndLine();
                }
            }

            if(isInRange && questAccepted == false)
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
            else
            {
                Debug.Log("Complete the quest first");
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

            if(index == linesEndArray.Length)
            {
                linesEndArray[index - 1].SetActive(false);
            }
            else
            {
                linesEndArray[index].SetActive(false);
            }
            index = 0;
        }
    }

    void NextLine()
    {
        if(index == linesArray.Length)
        {
            linesArray[index - 1].SetActive(false);
            questMan.AddQuest(quest);
            questAccepted = true;
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
        }
    }

    void NextEndLine()
    {
        if(index == linesEndArray.Length)
        {
            linesEndArray[index - 1].SetActive(false);
            questMan.RemoveQuest(quest);
            index = 0;
        }
        if(index != linesEndArray.Length)
        {
            if(index != 0)
            {
                linesEndArray[index - 1].SetActive(false);
            }
            linesEndArray[index].SetActive(true);
            index++;
        }
    }
}
