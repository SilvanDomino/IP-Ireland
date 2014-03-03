 #pragma strict

var walkspeed: float = 5.0;

function Start() {



}

function Update() {

    rigidbody.freezeRotation = true;

    if (Input.GetKey("w")) transform.Translate(Vector3(0, 0, 1) * Time.deltaTime * walkspeed);
    if (Input.GetKey("s")) transform.Translate(Vector3(0, 0, - 1) * Time.deltaTime * walkspeed);
    if (Input.GetKey("a")) transform.Translate(Vector3(-1, 0, 0) * Time.deltaTime * walkspeed);
    if (Input.GetKey("d")) transform.Translate(Vector3(1, 0, 0) * Time.deltaTime * walkspeed);

}