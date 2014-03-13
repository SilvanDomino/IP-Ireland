using UnityEngine;
using System.Collections;
using System;
public class ClockScript : MonoBehaviour {
    public DateTime time = new DateTime(2014, 2, 8, 12,0,0,0);
    public int timeSpeed = 10;
    void Start()
    {
        print("Clockscript location: " + gameObject.name);
    }
    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 100, 70), "Time: " + time.ToLongTimeString());
    }
    void Update()
    {
        int t = (int)( Time.deltaTime * 1000);
        t *= timeSpeed;
        time += new TimeSpan(0, 0,0, 0, t);
    }
    public bool CompareThisMin(DateTime b)
    {
        return CompareMin(this.time, b);
    }
    public bool CompareMin(DateTime a, DateTime b)
    {
        if (a.Hour == b.Hour && a.Minute == b.Minute)
        {
            return true;
        }
        return false;
    }
}
