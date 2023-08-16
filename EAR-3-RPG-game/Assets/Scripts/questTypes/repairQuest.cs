using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class repairQuest : MonoBehaviour
{
    public static int numOfRepairs;
    public int numMax;
    public GameObject colliderText;
    public Text repairText;
    private bool isInRange;
    public dialogManagerNPC quest;
    public bool questCompleted;

    void OnTriggerEnter2D(Collider2D other)
    {
        colliderText.SetActive(true);
        isInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        colliderText.SetActive(false);
        isInRange = false;
    }

    void Update()
    {
        if(quest.questAccepted)
        {
            repairText = GameObject.Find("Canvas/questWindow/questUINPC2(Clone)/text").GetComponent<Text>();
            repairText.text = $"{numOfRepairs} repaired";
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(isInRange)
            {
                if(quest.questAccepted)
                {
                    if(colRepairQuest.numCollected > 0)
                    {
                        numOfRepairs++;
                        repairText.text = $"{numOfRepairs} repaired";
                        colRepairQuest.numCollected--;
                        colliderText.SetActive(false);
                    }
                }
            }
        }

        if(numOfRepairs == numMax)
        {
            questCompleted = true;
            repairText.text = "Quest Completed";
        }
    }
}
