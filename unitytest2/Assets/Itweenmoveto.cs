/*using UnityEngine;
using System.Collections;

public class Itweenmoveto : MonoBehaviour {
	Hashtable ht = new Hashtable();
	GameObject gebouw;
	
	void Awake(){
		ht.Add("x",5);
		ht.Add("time",4);
		ht.Add("delay",1);
		ht.Add("onupdate","Update");
		ht.Add("looptype",iTween.LoopType.pingPong);
	}
	// Use this for initialization
	void Start () {
		Awake ();
		gebouw = GameObject.Find( "gebouw1" );
		iTween.MoveTo(gebouw,ht);

	}
	
	// Update is called once per frame
	void Update () {

	}
}*/
