using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deliveryQuest : MonoBehaviour
{
    public dialogManagerNPC quest;
    public Text deliveryText;
    public deliveryFinish finish;

    void Update()
    {
        if(quest.questAccepted)
        {
            deliveryText = GameObject.Find("Canvas/questWindow/questUINPC0(Clone)/text").GetComponent<Text>();
        }

        if(finish.deliveryCompleted)
        {
            quest.questCompleted = true;
            deliveryText.text = "Go and talk to the suspicious man";
        }
    }
}
