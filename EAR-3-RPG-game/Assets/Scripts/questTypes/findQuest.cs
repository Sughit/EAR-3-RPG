using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class findQuest : MonoBehaviour
{
    public static bool axeCollected;
    public Text textCollected;
    public dialogManagerNPC quest;
    public giveNextLines newLinesToAlfred;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(quest.questAccepted)
            {
                axeCollected=true;
                textCollected.text = "Go and talk to Jack";
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if(quest.questAccepted)
        {
            textCollected = GameObject.Find("Canvas/questWindow/questUINPC3(Clone)/text").GetComponent<Text>();
        }
        if(axeCollected)
        {
            quest.questCompleted = true;
            newLinesToAlfred.GiveNextLines();
        }
    }
}
