#pragma strict

function Start () {

}

function Update () {
//------------------Code for Zooming Out------------

   if (Input.GetAxis("Mouse ScrollWheel") <0)

       {

   if (Camera.current.fieldOfView<=100)

   Camera.current.fieldOfView +=2;

   if (Camera.current.orthographicSize<=20)

                                   Camera.current.orthographicSize +=0.5;

       }


//----------------Code for Zooming In-----------------------

    if (Input.GetAxis("Mouse ScrollWheel") > 0)

       {

    if (Camera.current.fieldOfView>2)

    Camera.current.fieldOfView -=2;

    if (Camera.current.orthographicSize>=1)

                                Camera.current.orthographicSize -=0.5;

       }


//-------Code to switch camera between Perspective and Orthographic--------


}