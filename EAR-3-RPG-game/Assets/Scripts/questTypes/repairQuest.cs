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
    public dialogManagerNPC finish;
    public giveNextLines newLinesToOliver;

    private bool canRepair = true;

    private SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(canRepair && quest.questAccepted)
        {
            if(colRepairQuest.numCollected>0)
            {
                colliderText.SetActive(true);
            }
            isInRange = true;
        }
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
            if(numOfRepairs!=4)
            {
                repairText.text = $"{numOfRepairs} repaired";
            }
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(isInRange)
            {
                if(quest.questAccepted)
                {
                    if(colRepairQuest.numCollected > 0 && canRepair)
                    {
                        canRepair = false;
                        spriteRenderer.sprite = newSprite;
                        numOfRepairs++;
                        if(numOfRepairs != 4)
                        {
                            repairText.text = $"{numOfRepairs} repaired";
                        }
                        colRepairQuest.numCollected--;
                        colliderText.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("you don't have wood or you repaired this already");
                    }
                }
            }
        }

        if(numOfRepairs == numMax)
        {
            newLinesToOliver.GiveNextLines();
            finish.questCompleted = true;
            repairText.text = "Go and talk to Alfred";
        }
    }
}
