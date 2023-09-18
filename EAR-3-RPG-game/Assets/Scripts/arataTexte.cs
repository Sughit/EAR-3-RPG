using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arataTexte : MonoBehaviour
{
    bool isRange;
    public GameObject textCollider;
    public GameObject lockedText;
    public float timeToSetFalse;
    float currentTimeToSetFalse;

    void Start()
    {
        currentTimeToSetFalse=timeToSetFalse;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isRange=true;
        textCollider.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isRange=false;
        textCollider.SetActive(false);
        lockedText.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(isRange)
            {
                textCollider.SetActive(false);
                lockedText.SetActive(true);
                
            }
        }
        if(lockedText.activeSelf==true)
        {
            if(currentTimeToSetFalse<=0)
                {
                    lockedText.SetActive(false);
                    currentTimeToSetFalse=timeToSetFalse;
                }
                else
                {
                    currentTimeToSetFalse-=Time.deltaTime;
                }
        }
    }
}
