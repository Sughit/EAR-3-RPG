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
    public bool timer;
    public bool disableWhenE;
    public bool ePressed;

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
        ePressed=false;
        disableWhenE=false;
    }

    void Update()
    {
        if(lockedText.activeSelf==true)
        {
            ePressed=true;
        }
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(disableWhenE)
            {
                lockedText.SetActive(false);
                Debug.Log("ar trebui sa se inchida");
                textCollider.SetActive(true);
                disableWhenE=false;
                StartCoroutine(apasareE());
            }

            if(isRange && !ePressed && Input.GetKeyDown(KeyCode.E))
            {
                
                textCollider.SetActive(false);
                lockedText.SetActive(true);
                disableWhenE=true;
            }
        }
        if(lockedText.activeSelf==true)
        {
            if(timer)
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

    IEnumerator apasareE()
    {
        yield return new WaitForSeconds(0.1f);
        ePressed=false;
    }
}
