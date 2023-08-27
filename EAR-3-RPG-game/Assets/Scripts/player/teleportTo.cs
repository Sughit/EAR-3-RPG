using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportTo : MonoBehaviour
{
    public GameObject colliderText;
    //public meniuPauza tranzitie;
    public Animator tranzitie;
    public GameObject tranzitieGO;
    [SerializeField]
    private bool isInRange;

    public float x,y,z;

    public GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
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
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(isInRange)
            {
                tranzitieGO.SetActive(true);
                //StartCoroutine(tranzitie.ModifyOpacity());
                StartCoroutine(Teleportare());
            }
        }
    }

    IEnumerator Teleportare()
    {
        tranzitie.SetBool("tranzitie", true);
        
        player.transform.position = new Vector3(x,y,z);
        yield return new WaitForSeconds(0.5f);
        tranzitie.SetBool("tranzitie", false);
        tranzitieGO.SetActive(false);
    }
}
