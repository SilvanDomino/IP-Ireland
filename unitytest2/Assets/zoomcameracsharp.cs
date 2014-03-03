using UnityEngine;
using System.Collections;

public class zoomcameracsharp : MonoBehaviour {
	Camera cam;
	// Use this for initialization
	void Start () {
		cam = GameObject.Find("Camera1").camera;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel") <0)
			
		{
			
			if (cam.fieldOfView<=100)
				
				cam.fieldOfView +=2;
			
			if (cam.orthographicSize<=20)
				
				cam.orthographicSize +=0.5f;
			
		}
		
		
		//----------------Code for Zooming In-----------------------
		
		if (Input.GetAxis("Mouse ScrollWheel") > 0)
			
		{
			
			if (cam.fieldOfView>2)
				
				cam.fieldOfView -=2;
			
			if (cam.orthographicSize>=1)
				
				cam.orthographicSize -=0.5f;
			
		}
	}
}
