using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oliverApare : MonoBehaviour
{
    public arataTexte letterRead;
    public GameObject Oliver;
    public GameObject player;

    void Update()
    {
        if(letterRead.oliver)
        {
            Oliver.SetActive(true);
            player.GetComponent<movement>().speed=0;
            player.GetComponent<movement>().canMove=false;
            letterRead.textCollider.SetActive(false);
            letterRead.isRange=false;
        }
    }
}
