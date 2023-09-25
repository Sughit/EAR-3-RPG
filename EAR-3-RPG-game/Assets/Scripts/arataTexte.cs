using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arataTexte : MonoBehaviour
{
    [HideInInspector]
    public bool isRange;
    
    public GameObject textCollider;
    public GameObject lockedText;
    public float timeToSetFalse;
    float currentTimeToSetFalse;
    public bool timer;
    public bool disableWhenE;
    //[HideInInspector]
    public bool ePressed;
    [HideInInspector]
    public bool oliver;
    public GameObject sonor;

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
                textCollider.SetActive(true);
                disableWhenE=false;
                StartCoroutine(apasareE());
            }
            if(isRange && !ePressed && Input.GetKeyDown(KeyCode.E))
            {
                                        Instantiate(sonor, transform.position, Quaternion.identity);
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
        oliver=true;
    }
}
