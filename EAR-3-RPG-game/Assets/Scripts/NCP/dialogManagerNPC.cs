using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogManagerNPC : MonoBehaviour
{
    public GameObject inRangeText;
    public bool isInRange;
    public GameObject[] linesArray;
    public GameObject[] lines2Array;
    public GameObject[] lines3Array;
    public GameObject[] linesEndArray;
    public questManager questMan;
    public GameObject quest;
    public string questLoc;
    public int index;
    public int index2;
    public int index3;
    public int indexEnd;
    public bool questAccepted;
    // public bool questAccepted2;
    // public bool questAccepted3;
    private bool canCycle;
    public bool questCompleted;
    // public bool questCompleted2;
    // public bool questCompleted3;
    public bool canFirstDialog = true;
    public bool canSecondDialog;
    public bool canThirdDialog;
    public GameObject mainQuest;

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
        if(questCompleted == true)
        {
            canFirstDialog = false;
        }
        //dezactiveaza liniile daca pleci
        if(!isInRange)
        {
            foreach(var linie in linesArray)
            {
                linie.SetActive(false);
            }
            foreach(var linie in lines2Array)
            {
                linie.SetActive(false);
            }
            foreach(var linie in lines3Array)
            {
                linie.SetActive(false);
            }
            foreach(var linie in linesEndArray)
            {
                linie.SetActive(false);
            }
        }
        //ciclu prin linii de dialog prin tasta E
        if(Input.GetKeyDown(KeyCode.E))
        {
            //liniile finala pentru NPC
            if(!canSecondDialog && !canThirdDialog)
            {
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
            }

            //liniile pentru acceptare quest
            if(canFirstDialog)
            {
                if(isInRange && questAccepted == false)
                {
                    if(index == linesArray.Length)
                    {
                        canCycle = false;
                        canFirstDialog = false;
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
            }//liniile pentru a accepta al doilea quest
            else if(canSecondDialog)
            {
                canCycle = true;
                if(isInRange)
                {
                    if(index2 == lines2Array.Length)
                    {
                        canCycle = false;
                    }else if(index2 == lines2Array.Length - 1)
                    {
                        canSecondDialog = false;
                    }
                    if(inRangeText.activeSelf && canCycle)
                    {
                        inRangeText.SetActive(false);
                        NextLine2();
                    }
                    else if(canCycle)
                    {
                        NextLine2();
                    }
                }
                else
                {
                    Debug.Log("Complete the second quest first");
                }
            }//liniile pentru a accepta al treilea quest
            else if(canThirdDialog)
            {
                canCycle = true;
                if(isInRange)
                {
                    if(index3 == lines3Array.Length)
                    {
                        canCycle = false;
                    }else if(index3 == lines3Array.Length - 1)
                    {
                        canThirdDialog = false;
                    }
                    if(inRangeText.activeSelf && canCycle)
                    {
                        inRangeText.SetActive(false);
                        NextLine3();
                    }
                    else if(canCycle)
                    {
                        NextLine3();
                    }
                }
                else
                {
                    Debug.Log("Complete the third quest first");
                }
            }
        }

        //nu stiu ce se intampla aici
        if(isInRange == false)
        {
            //pt primiile linii
            if(index == linesArray.Length)
            {
                linesArray[index - 1].SetActive(false);
                canCycle = false;
            }
            else
            {
                linesArray[index].SetActive(false);
            }
            //pt linii 2
            if(index2 == lines2Array.Length)
            {
                lines2Array[index2 - 1].SetActive(false);
                canCycle = false;
            }
            else
            {
                lines2Array[index2].SetActive(false);
            }
            //pt linii 3 
            if(index3 == lines3Array.Length)
            {
                lines3Array[index3 - 1].SetActive(false);
                canCycle = false;
            }
            else
            {
                lines3Array[index3].SetActive(false);
            }
            //pt linii finale
            if(indexEnd == linesEndArray.Length)
            {
                linesEndArray[indexEnd - 1].SetActive(false);
            }
            else
            {
                linesEndArray[indexEnd].SetActive(false);
            }
            index = 0;
            index2 = 0;
            index3 = 0;
            indexEnd = 0;
        }
    }

    void NextLine()
    {
        //adauga main quest
        if(index==7)
        {
            if(mainQuest!=null)
            {
                questMan.AddQuest(mainQuest);
            }
        }
        if(index == linesArray.Length - 1)
        {
            if(quest!=null)
            {
                questMan.AddQuest(quest);
                questAccepted = true;
            }
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

    void NextLine2()
    {
        //pt a adauga quest in acest stadiu scoate din comentariu

        // if(index2 == lines2Array.Length - 1)
        // {
        //     questMan.RemoveQuest(quest, questLoc);
        // }
        if(index2==1)
        {
            if(quest!=null)
            {
                questMan.RemoveQuest(quest, questLoc);
            }
        }
        if(index2 == lines2Array.Length)
        {
            lines2Array[index2 - 1].SetActive(false);
            index2 = 0;
        }
        if(index2 != lines2Array.Length)
        {
            if(index2 != 0)
            {
                lines2Array[index2 - 1].SetActive(false);
            }
            lines2Array[index2].SetActive(true);
            index2++;
        }
    }

    void NextLine3()
    {
        //pt a adauga quest in acest stadiu scoate din comentariu

        // if(index3 == lines3Array.Length - 1)
        // {
        //     questMan.AddQuest(quest);
        //     questAccepted = true;
        // }
        if(index3 == lines3Array.Length)
        {
            lines3Array[index3 - 1].SetActive(false);
            index3 = 0;
        }
        if(index3 != lines3Array.Length)
        {
            if(index3 != 0)
            {
                lines3Array[index3 - 1].SetActive(false);
            }
            lines3Array[index3].SetActive(true);
            index3++;
        }
    }

    void NextEndLine()
    {
        if(indexEnd == linesEndArray.Length - 1)
        {
            // //incepe a doua conversatie
            // canSecondDialog = true;
            if(quest!=null)
            {
                questMan.RemoveQuest(quest, questLoc);
            }
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
