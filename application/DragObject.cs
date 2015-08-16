using UnityEngine;
using System.Collections;

public class DragObject : MonoBehaviour {

	public GameObject tools;
	PositionSetting positionSet;

	bool dragging = false;

	Vector3 offset;
	Vector3 v3target;
	Vector3 touchWorldPos;
	Vector3 dragObjectOriginal;
	Vector3 startingPos;

	RaycastHit hit;

	// Use this for initialization
	void Start () {
		startingPos = dragObjectOriginal;

	}
	
	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR

		if(Input.GetMouseButtonDown(0)){

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if(Physics.Raycast (ray, out hit)){

				tools = hit.collider.gameObject;
				if(tools == GameObject.FindGameObjectWithTag("tools")){
					positionSet = tools.GetComponent<PositionSetting>();

					dragObjectOriginal = tools.transform.position;

					touchWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
					offset = touchWorldPos - dragObjectOriginal;

					//print ("-------------------------------");
					//print ("mouse position " + Input.mousePosition);
					//print ("mouse world position " + touchWorldPos);
					//print ("camera position " + Camera.main.transform.position);
					//print ("GameObject position " + tools.transform.position);

					dragging = true;
				}
			}
		}

		if(Input.GetMouseButton(0)){
			if(dragging && tools == GameObject.FindGameObjectWithTag("tools")){
				touchWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
				v3target = touchWorldPos - offset;
				//print ("v3 target " + v3target);
				tools.transform.position = new Vector3(v3target.x, v3target.y, dragObjectOriginal.z);
			}
		}

		if(Input.GetMouseButtonUp(0)){
			dragging = false;
			if(tools == GameObject.FindGameObjectWithTag("tools")){
			tools.transform.position = startingPos;
			}
		}

		#endif

		foreach (Touch touch in Input.touches){

			switch(touch.phase) {
			case TouchPhase.Began:
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				
				if(Physics.Raycast (ray, out hit)){
					
					tools = hit.collider.gameObject;

					if(tools == GameObject.FindGameObjectWithTag("tools")){
						positionSet = tools.GetComponent<PositionSetting>();
						
						dragObjectOriginal = tools.transform.position;
						
						touchWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
						offset = touchWorldPos - dragObjectOriginal;
						
						//print ("-------------------------------");
						//print ("mouse position " + Input.mousePosition);
						//print ("mouse world position " + touchWorldPos);
						//print ("camera position " + Camera.main.transform.position);
						//print ("GameObject position " + tools.transform.position);
						
						dragging = true;
					}
				}
				break;

			case TouchPhase.Moved:
				if(dragging && tools == GameObject.FindGameObjectWithTag("tools")){
					touchWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));
					v3target = touchWorldPos - offset;
					//print ("v3 target " + v3target);
					tools.transform.position = new Vector3(v3target.x, v3target.y, dragObjectOriginal.z);
				}
				break;

			case TouchPhase.Ended:
				dragging = false;
				if(tools == GameObject.FindGameObjectWithTag("tools")){
					tools.transform.position = startingPos;
				}
				break;
			}
		}
	}
	
}
