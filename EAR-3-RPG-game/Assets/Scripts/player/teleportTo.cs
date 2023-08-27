using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportTo : MonoBehaviour
{
    public GameObject colliderText;
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
                player.transform.position = new Vector3(x,y,z);
            }
        }
    }
}
