using UnityEngine;
using System.Collections;

public class PositionSetting : MonoBehaviour {

	Transform cachedTransform;
	Vector3 startingPos;
	public Rect windowRect = new Rect(150, 200, 200, 50);
	public GameObject thermo;
	public GameObject analyze;
	public GameObject exclamation;
	public GameObject back;
	public GameObject abnormality;
	public GameObject yes;
	public GameObject no;
	public GameObject clipboard;
	bool load = true;

	// Use this for initialization
	void Start () {
		cachedTransform = transform;

		startingPos = cachedTransform.position;

		thermo.SetActive (false);
		analyze.SetActive (false);
		exclamation.SetActive (false);
		back.SetActive (false);
		abnormality.SetActive (false);
		yes.SetActive (false);
		no.SetActive (false);
		clipboard.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (/*Input.GetTouch(0).phase == TouchPhase.Ended*/Input.GetMouseButtonUp(0) && load == false) {
			StartCoroutine ("loading");
		}
	}

	void OnTriggerEnter(Collider doink){
		if (doink.tag == "patient" && load == true){
			load = false;
		}
	}

	IEnumerator loading(){
		load = true;
		yield return new WaitForSeconds (0.5f);
		analyze.SetActive (true);
		yield return new WaitForSeconds (2);
		analyze.SetActive (false);
		thermo.SetActive(true);
		exclamation.SetActive (true);
		back.SetActive (true);
	}

	void OnTriggerExit(Collider doink){
		if (doink.tag == "patient") {
			load = true;
		}
	}

	void Option(string pew){
		if (pew == "exclamation") {
			thermo.SetActive(true);
			exclamation.SetActive (true);
			back.SetActive (true);
			abnormality.SetActive (true);
			yes.SetActive (true);
			no.SetActive (true);
		} else if (pew == "back") {
			thermo.SetActive(false);
			exclamation.SetActive (false);
			back.SetActive (false);
		}
	}

	void Yes(){
		abnormality.SetActive (false);
		yes.SetActive (false);
		no.SetActive (false);
		Debug.Log ("Saved to Notes.");
		StartCoroutine ("YesOption");
	}

	IEnumerator YesOption(){
		clipboard.SetActive (true);
		yield return new WaitForSeconds (2);
		clipboard.SetActive (false);
		thermo.SetActive(false);
		exclamation.SetActive (false);
		back.SetActive (false);
	}

	void No(){
		abnormality.SetActive (false);
		yes.SetActive (false);
		no.SetActive (false);
		thermo.SetActive(false);
		exclamation.SetActive (false);
		back.SetActive (false);
	}
}

