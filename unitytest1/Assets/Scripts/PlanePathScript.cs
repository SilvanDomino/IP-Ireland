using UnityEngine;
using System.Collections;

public class PlanePathScript : MonoBehaviour {

    public float snapShotTDelta = 0.3f;
    public float speed = 15;
    //public float height = 10;
    ArrayList list = new ArrayList();
    LineRenderer lineRenderer;
    Camera currentCameraBecauseYolo;
    bool isMovingAutoForward    = true;
    bool planeLanded            = false;
    bool isLanding              = false;
    bool isLanded               = false;
    float landTimer = 10;
    public float landTimerMax = 10;
	void Start () {
        gameObject.tag = "Airplane";
        landTimer = landTimerMax;
        currentCameraBecauseYolo = GameObject.Find("Camera1").camera;
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.SetColors(Color.red, Color.blue);
        lineRenderer.SetWidth(2, 1f);
        lineRenderer.material = Resources.Load<Material>("Smoke1");
    }

    void Update()
    {
        if (isMovingAutoForward && !isLanding && !isLanded )
        {
            rigidbody.velocity = transform.forward*speed * 0.5f;
        }
        if (isLanding)
        {
            landTimer -= Time.deltaTime;
            if (landTimer < 0)
            {
                Land();
            }
        }
        DrawPath();
    }

    void Land()
    {
        iTween.Stop(gameObject);
        rigidbody.velocity = new Vector3(0, 0, 0);
        isLanding = false;
        isMovingAutoForward = false;
        print("land");
    }
    IEnumerator OnMouseDown()
    {
        list.Clear();
        while (Input.GetMouseButton(0))
        {
            Vector3 pos = Vector3.zero;
            RaycastHit hit;
            Ray ray = currentCameraBecauseYolo.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                pos = hit.point;
                pos.y = 10;
            }
            list.Add(pos);
            yield return new WaitForSeconds(snapShotTDelta);
        }
        Vector3[] path = (Vector3[])list.ToArray(typeof(Vector3));
        iTween.MoveTo(gameObject, 
            iTween.Hash(
                "path", path, 
                "speed", speed, 
                "orienttopath", true, 
                "easetype", iTween.EaseType.linear, 
                "oncomplete", "ITweenMovementComplete"
            )
        );
        isMovingAutoForward = false;
    }

    void ITweenMovementComplete()
    {
        if (!isLanding || !isLanded)
        {
            isMovingAutoForward = true;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "LandingSpace")
        {
            isLanding = true;
            print("Trigger Entered: Start Landing");
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "LandingSpace")
        {
            print("Trigger Exit: Stop Landing");
            landTimer = landTimerMax;
        }
    }
    void DrawPath()
    {
        lineRenderer.SetVertexCount(list.Count);
        for (int i = 0; i < list.Count; i++)
        {
            lineRenderer.SetPosition(i, (Vector3)list[i]);
        }
    }
    
}
