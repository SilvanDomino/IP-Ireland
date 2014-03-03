using UnityEngine;
using System.Collections;

public class menutest : MonoBehaviour {

	bool geklikt = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("klikje");
			geklikt = true;
		}
	}

	void OnGUI(){
		if (enabled) {
						if (geklikt == true) {
								if (GUI.Button (new Rect (Screen.width - 200, 10, 200, 50), "Daily inspection")) {
										Debug.Log ("geklikt op daily inspection");
										enabled = false;
										geklikt = false;
								}
				if (GUI.Button (new Rect (Screen.width - 200, 60, 200, 50), "Positioning onto ramp")) {
										Debug.Log ("geklikt op positioning onto ramp");
										enabled = false;
										geklikt = false;
								}
				if (GUI.Button (new Rect (Screen.width - 200, 110, 200, 50), "Refuelling")) {
										Debug.Log ("geklikt op refuelling");
										enabled = false;
										geklikt = false;
								}
				if (GUI.Button (new Rect (Screen.width - 200, 160, 200, 50), "Positioning into hangar")) {
										Debug.Log ("geklikt op positioning into hangar");
										enabled = false;
										geklikt = false;
								}
						}
				}
		enabled = true;
}
}
