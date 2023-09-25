using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deliveryFinish : MonoBehaviour
{
    public GameObject colliderText;
    public dialogManagerNPC quest;
    private bool isInRange;
    private bool canInteract = true;
    public bool deliveryCompleted;
    public GameObject sonor;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && quest.questAccepted && canInteract)
        {
            colliderText.SetActive(true);
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            colliderText.SetActive(false);
            isInRange = false;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            deliveryCompleted = true;
            canInteract =false;
            colliderText.SetActive(false);
            Instantiate(sonor, transform.position, Quaternion.identity);
        }
    }
}
