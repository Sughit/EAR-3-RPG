using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheieScript : MonoBehaviour
{
    public static bool isKey;
    public dialogManagerNPC Alfred;
    public GameObject cheie;
    public GameObject textCollider;
    bool isRange;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            isRange=true;
            textCollider.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            isRange=false;
            textCollider.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(isRange)
            {
                if(Alfred.canThirdDialog)
                {
                    textCollider.SetActive(false);
                    isKey=true;
                    cheie.SetActive(false);
                }
                else
                {
                    textCollider.SetActive(false);
                    Debug.Log("Avanseaza mai mult in poveste");
                }
            }
        }
    }
}
