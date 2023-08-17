using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectQuest : MonoBehaviour
{
    public static int numCollected = 0;
    public static int numMax = 3;
    public Text textCollected;
    public dialogManagerNPC quest;
    public dialogManagerNPC finish;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(quest.questAccepted)
            {
                
                numCollected++;
                textCollected.text = $"Collected {numCollected} out of {numMax}";
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if(quest.questAccepted)
        {
            textCollected = GameObject.Find("Canvas/questWindow/questUINPC1(Clone)/text").GetComponent<Text>();
        }
        if(numCollected == numMax)
        {
            textCollected.text = "Quest Completed";
            finish.questCompleted = true;
        }
    }
}
