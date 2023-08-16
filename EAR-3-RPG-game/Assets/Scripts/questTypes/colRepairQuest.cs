using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colRepairQuest : MonoBehaviour
{
    public static int numCollected;
    public Text collectedText;
    public dialogManagerNPC quest;
    public repairQuest questCom;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(quest.questAccepted)
            {
                numCollected++;
                collectedText.text = $"{numCollected} of wood collected";
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if(quest.questAccepted)
        {
            collectedText = GameObject.Find("Canvas/questWindow/questUINPC2(Clone)/colText").GetComponent<Text>();
            collectedText.text = $"{numCollected} of wood collected";
        }

        if(questCom.questCompleted)
        {
            collectedText.gameObject.SetActive(false);
        }
    }
}
