using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextIntro : MonoBehaviour {
	
	public GameObject textBox;
	string[] fraseInicial = new string[9];
	Text text;
	
	void Start () {
		text = textBox.GetComponent<Text>();
		fraseInicial [0] = "Great.\n";
		fraseInicial [1] = "You managed to escape from your cell yesterday.\n";
		fraseInicial [2] = "Don't forget that you must walk away today.\n\n";
		fraseInicial [3] = "Walk with WASD\n\n";
		fraseInicial [4] = "Now remember, they have a lot of buttons controlling their systems...\n\n";
		fraseInicial [5] = "Interact with things using E\n\n";
		fraseInicial [6] = "...and make good use of the mirror world.\n";
		fraseInicial [7] = "Only walking on these parallel realities we can escape.\n";
		fraseInicial [8] = "Now, wake up and take care to not be seen.";
		StartCoroutine ("write");
	}
	
	// Update is called once per frame
	void Update () {
		Color textColor = text.color;
		float ratio;
		if (Time.time > 45) { // fade away code
			ratio = (Time.time-45)/5;
			textColor.a = Mathf.Lerp(1,0, ratio);
			text.color = textColor;
		}
		if (Time.time > 53)
			Application.LoadLevel (3);
	}

	IEnumerator write(){ 
		for (int i = 0; i < fraseInicial.Length; i++) {
			for (int j = 0; j< fraseInicial[i].Length; j++){
				text.text = text.text + fraseInicial[i][j];
				yield return new WaitForSeconds (0.1f);
			}
			yield return new WaitForSeconds (1f);
		}
	}
}
