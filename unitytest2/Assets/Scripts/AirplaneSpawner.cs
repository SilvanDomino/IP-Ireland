using UnityEngine;
using System.Collections;
using System;

public class AirplaneSpawner : MonoBehaviour {

    public ArrayList schedule = new ArrayList();
    public ClockScript clock;
    public GameObject airPlanePrefab;
    public int maxHoursNext = 3;

	IEnumerator Start () {
        airPlanePrefab = Resources.Load<GameObject>("Airplane");
        clock = GameObject.Find("GameController").GetComponent<ClockScript>();
        schedule.Add(CreateNewScheduleItem());
        schedule.Add(CreateNewScheduleItem());
        while (true)
        {
            int a = UnityEngine.Random.Range(0, 3);
            if (a < 2)
            {
                schedule.Add(CreateNewScheduleItem());
            }
            yield return new WaitForSeconds(3);
        }
	}

    PlaneScheduleObject CreateNewScheduleItem()
    {
        UnityEngine.Random.seed = (int)((UnityEngine.Random.value * 100) + 3 * 2);
        string type = "Boeing 747";
        DateTime time = clock.time + new TimeSpan(UnityEngine.Random.Range(1, maxHoursNext), UnityEngine.Random.Range(1, 60), 0);
        Vector3 pos = new Vector3(0, 10, 0);
        return new PlaneScheduleObject(type, time, pos);
    }

    void Update()
    {
        
        for (int i = 0; i < schedule.Count; i++)
        {
            //update every timer in the schedule
            PlaneScheduleObject a = (PlaneScheduleObject)schedule[i];
            a.span = a.arriving.Subtract(clock.time);

            //spawns the plane when it's time.
            if (clock.CompareThisMin(a.arriving))
            {
                SpawnPlane(i);
            }
        }
        

    }

    public void SpawnPlane(int index)
    {
        PlaneScheduleObject a = (PlaneScheduleObject)schedule[index];
        schedule.RemoveAt(index);

        GameObject airplane = (GameObject)Instantiate(airPlanePrefab, a.spawnPos, Quaternion.identity);

    }
    void OnGUI()
    {
        for (int i = 0; i < schedule.Count; i++)
        {
            PlaneScheduleObject a = (PlaneScheduleObject)schedule[i];
            GUI.Label(new Rect(20, 80 + i * 30, 200, 25),a.PrintScheduleObject() );
            GUI.Label(new Rect(120, 80 + i * 30, 200, 25), a.span.ToString());
        }

    }
}

public class PlaneScheduleObject
{
    public string planeType = "Bird";
    public DateTime arriving;
    public Vector3 spawnPos = Vector3.zero;
    public TimeSpan span = new TimeSpan(0, 0, 0);
    public PlaneScheduleObject(string type, DateTime arriving, Vector3 pos)
    {
        this.planeType = type;
        this.arriving = arriving;
        this.spawnPos = pos;
    }
    public string PrintScheduleObject()
    {
        string str = "";
        str += "" + planeType;
        return str;
    }

}