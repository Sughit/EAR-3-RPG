using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveNextLines : MonoBehaviour
{
    public dialogManagerNPC whatNPC;
    public dialogManagerNPC Anna;
    public dialogManagerNPC Oliver;
    public dialogManagerNPC Jack;
    public bool giveSecondLines;
    public bool giveThirdLines;
    public bool forAlfred;

    public void GiveNextLines()
    {
        if(giveSecondLines)
        {
            whatNPC.canSecondDialog=true;
        }
        if(giveThirdLines)
        {
            whatNPC.canThirdDialog=true;
        }
        if(forAlfred)
        {
            if(Anna.questCompleted && Oliver.questCompleted && Jack.questCompleted)
            {
                whatNPC.canThirdDialog=true;
            }
        }
    }
}
