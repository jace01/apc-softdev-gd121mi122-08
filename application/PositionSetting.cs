using UnityEngine;
using System.Collections;

public class PositionSetting : MonoBehaviour {

	Transform cachedTransform;
	Vector3 startingPos;
	public Rect windowRect = new Rect(150, 200, 200, 50);
	public GameObject thermo;
	public bool doWindow0 = false;

	// Use this for initialization
	void Start () {
		cachedTransform = transform;

		startingPos = cachedTransform.position;

		thermo.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider doink){
		if (doink.tag == "patient" && Input.GetTouch(0).phase == TouchPhase.Ended) {
			StartCoroutine("loading");
		}
	}

	IEnumerator loading(){
		yield return new WaitForSeconds (2);
		thermo.SetActive(true);
		yield return new WaitForSeconds (2);
		doWindow0 = true;
	}
	void OnGUI() {
		if(doWindow0)
			windowRect = GUI.Window(100, windowRect, DoMyWindow, "Is this an abnormality?");
	}

	void DoMyWindow(int windowID) {
		if (GUI.Button (new Rect (60, 40, 70, 40), "Yes")) {
			print ("Saved to Notes");
			thermo.SetActive (false);
			doWindow0 = false;
		}
		if (GUI.Button (new Rect (170, 40, 70, 40), "No")) {
			print ("Back");
			thermo.SetActive (false);
			doWindow0 = false;
		}
	}
}

