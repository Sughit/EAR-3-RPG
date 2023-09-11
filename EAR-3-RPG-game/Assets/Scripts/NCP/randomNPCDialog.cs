using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomNPCDialog : MonoBehaviour
{
    public GameObject text;
    public GameObject colliderText;
    bool inRange;
    public float timeToDespawn;
    float currentTime;
    bool startTimer;

    void Start()
    {
        currentTime = timeToDespawn;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            colliderText.SetActive(true);
            inRange=true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            colliderText.SetActive(false);
            text.SetActive(false);
            inRange=false;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(inRange)
            {
                colliderText.SetActive(false);
                text.SetActive(true);
                startTimer=true;
            }
        }
        if(startTimer)
        {
            if(currentTime <= 0)
            {
                text.SetActive(false);
                currentTime = timeToDespawn;
            }
            else
            {
                currentTime-=Time.deltaTime;
            }
        }
    }
}
