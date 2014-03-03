using UnityEngine;
using System.Collections;

public class clickMovement : MonoBehaviour
{
	public float _Distance;
	public float _Speed = 10f;
	
	//Declare out side of update so we can retain it between frames
	private Vector3 _NewPosition;
	
	void Start ()
	{
		// set _NewPosition to the character position so we don't start moving torwards (0,0,0)
		_NewPosition = transform.position;
	}
	
	void Update ()
	{
		
		if (Input.GetMouseButtonDown (0)) {
			
			//Don't raycast every frame but only when you need it 
			Ray ray = Camera.mainCamera.ScreenPointToRay (Input.mousePosition);
			Debug.DrawRay (ray.origin, ray.direction * 9999999, Color.red);
			
			RaycastHit hit;
			// put in if statement just in case we don't hit anything
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == "passable") {    
					//move into check so we don't change position unless it meets your rules
					_NewPosition = hit.point;
					
				} 
			}
		}
		
		
		// you don't need the this.gameObject. this is assumed and gameObject is a shortcut just like transform 
		// so you can use the transform shortcut
		transform.LookAt (_NewPosition);
		transform.position = Vector3.MoveTowards (transform.position, _NewPosition, _Speed * Time.deltaTime);        
		
	}
}
