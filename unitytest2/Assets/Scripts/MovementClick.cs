using UnityEngine;
using System.Collections;

public class MovementClick : MonoBehaviour {
	Camera usedCam;
	private bool isWorking;
	private bool isSelected;
	private Transform trans;
	private Vector3 destinationPosition;
	private float destinationDistance;
	public float moveSpeed;	
	bool geklikt = false;
	
	// Use this for initialization
	void Start () {
		isSelected = false;
		isWorking = false;
		trans = transform;
		destinationPosition = trans.position;
		usedCam = GameObject.Find("Camera2").camera;
	}

	void OnGUI(){
		if (enabled) {
			if (geklikt == true) 
			{
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
	// Update is called once per frame
	void Update () {
		if (isWorking == false)
		{
			gameObject.renderer.material.color = Color.blue;
		}
		else
		{
			gameObject.renderer.material.color = Color.black;
		}
		if (Input.GetMouseButtonDown (1))
		{
			isSelected = false;
			Debug.Log ("Annuleer");
		}
		
		destinationDistance = Vector3.Distance(destinationPosition, trans.position);
		if(destinationDistance < 0.1f)
		{		
			moveSpeed = 0;
			isWorking = false;
		}
		else if(destinationDistance > 0.1f)
		{			
			moveSpeed = 3;
			isWorking = true;
			isSelected = false;
		}
		
		if (isWorking == false)
		{
			if (Input.GetMouseButtonDown (0))
			{
				Plane playerPlane = new Plane(Vector3.up,trans.position);
				Ray ray = usedCam.ScreenPointToRay(Input.mousePosition);
				float hitdist = 0.0f;
				
				if(playerPlane.Raycast(ray, out hitdist))
				{
					Vector3 targetPoint = ray.GetPoint(hitdist);
					if((targetPoint.x > trans.position.x - trans.localScale.x && targetPoint.x < trans.position.x + trans.localScale.x) && (targetPoint.z > trans.position.z - trans.localScale.z && targetPoint.z < trans.position.z + trans.localScale.z) )
					{
						Debug.Log("Poppetje geselecteerd");
						isSelected = true;
						geklikt = true;
					}
					else if(isSelected == true)
					{
						destinationPosition = ray.GetPoint(hitdist);
						Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
						trans.rotation = targetRotation;
					}
				}
			}
		}

		trans.position = Vector3.MoveTowards(trans.position, destinationPosition, moveSpeed * Time.deltaTime);		
	}
	
}