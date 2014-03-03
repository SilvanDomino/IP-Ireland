using UnityEngine;
using System.Collections;

public class OnMouseDown : MonoBehaviour {
	Camera usedCam;
	Camera topcam;
	GameObject[] cameras;
	// Use this for initialization
	void Start () {
		
		cameras = GameObject.FindGameObjectsWithTag("cam");
		usedCam = GameObject.Find("Camera2").camera;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
						Debug.Log ("klik");
			foreach (GameObject cams in cameras){
				Camera theCam = cams.GetComponent<Camera>() as Camera;
				theCam.enabled = false;
			}  
						usedCam.enabled = true;
		}
	}


}
