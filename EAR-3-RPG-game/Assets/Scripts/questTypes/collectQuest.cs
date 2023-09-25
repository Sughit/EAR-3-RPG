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
    public GameObject sonor;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(quest.questAccepted)
            {
                
                numCollected++;
                textCollected.text = $"Collected {numCollected} out of {numMax}";
                Instantiate(sonor, transform.position, Quaternion.identity);
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
            textCollected.text = "Go and talk to Anna";
            quest.questCompleted = true;
        }
    }
}
