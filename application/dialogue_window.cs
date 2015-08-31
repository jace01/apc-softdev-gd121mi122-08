using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class dialogue_window : MonoBehaviour {

	public string dialogueStatus;
	public List<string> dialogueList = new List<string>();

	private string dialogueToDisplay;
	private int letter;
	public bool started;
	public float letterDelay;
	public int dialoguePage;
	public Text textToDisplay;

	// Use this for initialization
	void Start () {
		started = false;
		dialogueStatus = "scrolling";
		dialoguePage = 0;
		letterDelay = 5.0F;
	}
	
	// Update is called once per frame
	void Update () {
		DialogueDisplay ();
	}

	void DialogueDisplay () {
		if (Input.touchCount >= 1 && Input.GetTouch (0).phase == TouchPhase.Began) {
			if (dialogueStatus == "scrolling") {
				dialogueStatus = "skip";
			}
			else if (dialogueStatus == "skip") {
				dialogueStatus = "nextLine";
			}
		}

		if (dialogueStatus == "scrolling" && started == false) {
			started = true;
			for (letter = 0; letter < dialogueList[dialoguePage].Length; letter++) {
				StartCoroutine("scroll");
			}
			dialogueStatus = "skip";
		}
		else if (dialogueStatus == "skip") {
			letter = dialogueList[dialoguePage].Length;
			dialogueToDisplay = dialogueList[dialoguePage];
		}
		else if (dialogueStatus == "nextLine") {
			letter = 0;
			dialoguePage += 1;
			dialogueToDisplay = null;
			dialogueStatus = "scrolling";
			started = false;
		}
	}

	IEnumerator scroll () {
		dialogueToDisplay = dialogueToDisplay + dialogueList[dialoguePage][letter];
		yield return new WaitForSeconds(letterDelay);
		TextToDisplay ();
	}

	void TextToDisplay () {
		textToDisplay.text = dialogueToDisplay;
	}
}
