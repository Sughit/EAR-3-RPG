using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class efectScris : MonoBehaviour {

	float delay = 0.045f;
	[TextArea]
	public string fullText;
	private string currentText = "";

	// Use this for initialization

	void OnEnable()
	{
		StartCoroutine(ShowText());
	}

	IEnumerator ShowText(){
		for(int i = 0; i <= fullText.Length; i++){
			currentText = fullText.Substring(0,i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);
			
		}
	}
	
}
