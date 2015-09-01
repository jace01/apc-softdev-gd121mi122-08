using UnityEngine;
using System.Collections;

public class QuestioningController : MonoBehaviour {

	int arraypos = 0;
	float xpos;
	float ypos;

	public GameObject[] bubbles = new GameObject[3];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")) {		//activates upon touch
			if(arraypos < 3) {
				Shuffle ();

				//Note: pa-adjust na lang ang mga ranges according sa screen size ng Unity mo.
				Popup ();
			}
			else {
				Debug.Log ("End of questioning");
				//Application.LoadLevel(*insert main game screen*);
			}
		}
	}

	public void Shuffle () {
		xpos = Random.Range(-4,6);		//randomize positions within an area
		ypos = Random.Range(-1, 6);
		this.transform.position = new Vector3(xpos, ypos, -10);
	}

	public void Popup () {
		Instantiate (bubbles [arraypos], bubbles[arraypos].transform.position, this.transform.rotation);
		arraypos++;
	}
}
