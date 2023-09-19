using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goInvisible : MonoBehaviour
{
    public GameObject npc;
    public dialogManagerNPC npcScript;
    public bool secondDialog;
    public bool thirdDialog;
    bool isRange;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            isRange=true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            isRange=false;
        }
    }

    void Update()
    {
        if(isRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
        {
            if(secondDialog)
        {
            if(npcScript.canSecondDialog)
            {
                npc.SetActive(false);
            }
        }

        if(thirdDialog)
        {
            if(npcScript.canThirdDialog)
            {
                npc.SetActive(false);
            }
        }
        }
        }
    }
}
