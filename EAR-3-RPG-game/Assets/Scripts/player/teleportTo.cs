using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleportTo : MonoBehaviour
{
    public GameObject colliderText;
    //public meniuPauza tranzitie;;
    public Image tranzitieGO;
    public Color ImageColor;
    [SerializeField]
    private bool isInRange;

    public float x,y,z;

    public GameObject player;

    void Start()
    {
        ImageColor = tranzitieGO.color;
    }

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
                        tranzitieGO.gameObject.SetActive(true);
                StartCoroutine(ModifyOpacity());
            }
        }
    }

    IEnumerator ModifyOpacity() {

        tranzitieGO.gameObject.SetActive(true);
                player.transform.position = new Vector3(x,y,z);
        yield return new WaitForSeconds(1f);
        for(int i = 0; i < 50; i++){
                ImageColor.a -= 0.02f;
                tranzitieGO.color=ImageColor;
                yield return new WaitForSeconds(0.01f);
            }
                    ImageColor.a=1;
            tranzitieGO.gameObject.SetActive(false);
                tranzitieGO.color=ImageColor;
    }
}
