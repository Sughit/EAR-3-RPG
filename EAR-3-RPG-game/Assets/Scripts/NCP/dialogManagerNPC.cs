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
    public string questLoc;
    public int index;
    public int indexEnd;
    public bool questAccepted;
    private bool canCycle;
    public bool questCompleted;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inRangeText.SetActive(true);
            isInRange = true;
            canCycle = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            inRangeText.SetActive(false);
            isInRange = false;
            canCycle = false;
        }
    }

    void Update()
    {
        if(!isInRange)
        {
            foreach(var linie in linesArray)
            {
                linie.SetActive(false);
            }
            foreach(var linie in linesEndArray)
            {
                linie.SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            //liniile finala pentru NPC
            if(isInRange && questCompleted)
            {
                if(indexEnd == linesEndArray.Length)
                {
                    canCycle = false;
                }
                if(inRangeText.activeSelf && canCycle)
                {
                    inRangeText.SetActive(false);
                    NextEndLine();
                }
                else if(canCycle)
                {
                    NextEndLine();
                }
            }

            //liniile pentru acceptare quest
            if(isInRange && questAccepted == false)
            {
                if(index == linesArray.Length)
                {
                    canCycle = false;
                }
                if(inRangeText.activeSelf && canCycle)
                {
                    inRangeText.SetActive(false);
                    NextLine();
                }
                else if(canCycle)
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
                canCycle = false;
            }
            else
            {
                linesArray[index].SetActive(false);
            }

            if(indexEnd == linesEndArray.Length)
            {
                linesEndArray[indexEnd - 1].SetActive(false);
            }
            else
            {
                linesEndArray[indexEnd].SetActive(false);
            }
            index = 0;
            indexEnd = 0;
        }
    }

    void NextLine()
    {
        if(index == linesArray.Length - 1)
        {
            questMan.AddQuest(quest);
            questAccepted = true;
        }
        if(index == linesArray.Length)
        {
            linesArray[index - 1].SetActive(false);
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
        if(indexEnd == linesEndArray.Length - 1)
        {
            questMan.RemoveQuest(quest, questLoc);
        }
        if(indexEnd == linesEndArray.Length)
        {
            linesEndArray[indexEnd - 1].SetActive(false);
            indexEnd = 0;
        }
        if(indexEnd != linesEndArray.Length)
        {
            if(indexEnd != 0)
            {
                linesEndArray[indexEnd - 1].SetActive(false);
            }
            linesEndArray[indexEnd].SetActive(true);
            indexEnd++;
        }
    }
}
