using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveNextLines : MonoBehaviour
{
    public dialogManagerNPC whatNPC;
    public bool giveSecondLines;
    public bool giveThirdLines;

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
    }
}
