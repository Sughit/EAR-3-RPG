using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cabanaScript : MonoBehaviour
{
    public float X;
    public float Y;
    public GameObject player;
    public bool isRange;
    public GameObject textCollider;
    public Image tranzitieGO;
    public Color ImageColor;

    void Start()
    {
        ImageColor = tranzitieGO.color;
    }

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
                if(cheieScript.isKey)
                {
                    tranzitieGO.gameObject.SetActive(true);
                    StartCoroutine(ModifyOpacity());
                    textCollider.SetActive(false);
                    
                }
            }
        }
    }

    IEnumerator ModifyOpacity() {
        tranzitieGO.gameObject.SetActive(true);
        player.transform.position = new Vector3(X,Y,0);
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
