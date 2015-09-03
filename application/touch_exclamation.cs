using UnityEngine;
using System.Collections;

public class touch_exclamation : MonoBehaviour {

	public static int currTouch = 0;
	private Ray ray;
	RuntimePlatform platform = Application.platform;
	public GameObject exc;
	
	// Update is called once per frame
	void Update () {
		if(platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer){
			if(Input.touchCount > 0) {
				if(Input.GetTouch(0).phase == TouchPhase.Began){
					checkTouch(Input.GetTouch(0).position);
				}
			}
		}else if(platform == RuntimePlatform.WindowsEditor){
			if(Input.GetMouseButtonDown(0)) {
				checkTouch(Input.mousePosition);
			}
		}
	}
	
	void checkTouch(Vector3 posi){
		Vector3 wr = Camera.main.ScreenToWorldPoint(posi);
		Vector2 touchPos = new Vector2(wr.x, wr.y);
		var hit1 = Physics2D.OverlapPoint (touchPos);
		Debug.Log (hit1);
		
		if(hit1 == this.gameObject.GetComponent<Collider2D>()){
			Debug.Log(hit1.transform.gameObject.name);
			exc.SendMessage("Option", "exclamation");
		}
	}
}
