using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opacitateScript : MonoBehaviour
{
    public Image Background;
     public Color ImageColor;
 
     void Awake () {
        Background.gameObject.SetActive(true);
         ImageColor = Background.color;
         StartCoroutine(ModifyOpacity());
     }
 
     IEnumerator ModifyOpacity() {
        ImageColor.a=1; 
        for(int i = 0; i < 50; i++){
                ImageColor.a -= 0.02f;
                Background.color=ImageColor;
                yield return new WaitForSeconds(0.01f); 
                
        }
        Background.gameObject.SetActive(false);
                Background.color=ImageColor;
     }
}
