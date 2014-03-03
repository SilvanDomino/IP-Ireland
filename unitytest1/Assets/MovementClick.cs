using UnityEngine;
using System.Collections;

public class MovementClick : MonoBehaviour {
	Camera usedCam;
	private Transform tr;
	private Vector3 destinationPosition;
	private float destinationDistance;
	public float moveSpeed;	

	// Use this for initialization
	void Start () {
		tr = transform;
		destinationPosition = tr.position;
		usedCam = GameObject.Find("Camera2").camera;
	}
	
	// Update is called once per frame
	void Update () {
		destinationDistance = Vector3.Distance(destinationPosition, tr.position);
		if(destinationDistance < 0.5f)
		{		
			moveSpeed = 0;
		}
		else if(destinationDistance > 0.5f)
		{			
			moveSpeed = 3;
		}

		if (Input.GetMouseButtonDown (0)) 
		{
			Plane playerPlane = new Plane(Vector3.up, transform.position);
			Ray ray = usedCam.ScreenPointToRay(Input.mousePosition);
			float hitdist = 0.0f;

			if (playerPlane.Raycast(ray, out hitdist))
			{
				Vector3 targetPoint = ray.GetPoint(hitdist);
				destinationPosition = ray.GetPoint(hitdist);
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				transform.rotation = targetRotation;
			}
		}
			tr.position = Vector3.MoveTowards(tr.position, destinationPosition, moveSpeed * Time.deltaTime);
		
	}
	
}