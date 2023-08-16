using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opacitateScript : MonoBehaviour
{
    public Image Background;
     public Color ImageColor;
     private bool up = false;
 
     void Start () {
         ImageColor = Background.color;
         StartCoroutine(ModifyOpacity());
     }
 
     IEnumerator ModifyOpacity() {
        ImageColor.a=1; //Full Opaque
        for(int i = 0; i < 100; i++){
                ImageColor.a -= 0.02f;
                Background.color=ImageColor;
                yield return new WaitForSeconds(0.01f); //Wait
        }
     }
}
