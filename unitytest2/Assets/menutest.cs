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
		if (geklikt == true) {
						if (GUI.Button (new Rect (1000, 30, 100, 70), "button")) {
								Debug.Log ("geklikt op button");
						}
				}
	}
}
