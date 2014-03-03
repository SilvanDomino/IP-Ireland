using UnityEngine;
using System.Collections;

public class MovementClick : MonoBehaviour {
	Camera usedCam;
	private bool isSelected;
	private Transform trans;
	private Vector3 destinationPosition;
	private float destinationDistance;
	public float moveSpeed;	
	
	// Use this for initialization
	void Start () {
		isSelected = false;
		trans = transform;
		destinationPosition = trans.position;
		usedCam = GameObject.Find("Camera2").camera;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1))
		{
			isSelected = false;
			Debug.Log ("Annuleer");
		}
		
		destinationDistance = Vector3.Distance(destinationPosition, trans.position);
		if(destinationDistance < 0.1f)
		{		
			moveSpeed = 0;
		}
		else if(destinationDistance > 0.5f)
		{			
			moveSpeed = 3;
		}
		
		
		if (Input.GetMouseButtonDown (0))
		{
			Plane playerPlane = new Plane(Vector3.up,trans.position);
			Ray ray = usedCam.ScreenPointToRay(Input.mousePosition);
			float hitdist = 0.0f;
			
			if(playerPlane.Raycast(ray, out hitdist))
			{
				Vector3 targetPoint = ray.GetPoint(hitdist);
				if((targetPoint.x > trans.position.x - trans.localScale.x && targetPoint.x < trans.position.x) && (targetPoint.z > trans.position.z - trans.localScale.z && targetPoint.z < trans.position.z) )
				{
					Debug.Log("Poppetje geselecteerd");
					isSelected = true;
				}
				else if(isSelected == true)
				{
					destinationPosition = ray.GetPoint(hitdist);
					Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
					trans.rotation = targetRotation;
				}
			}
		}
		trans.position = Vector3.MoveTowards(trans.position, destinationPosition, moveSpeed * Time.deltaTime);		
	}
	
}