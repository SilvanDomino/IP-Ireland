using UnityEngine;
using System.Collections;
using System;
public class ClockScript : MonoBehaviour {
    DateTime time = new DateTime(1);
    void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 100, 70), "Time: " + time.ToLongTimeString());
    }
    void Update()
    {
        int t = (int)( Time.deltaTime * 1000);
        time += new TimeSpan(0, 0,0, 0, t);
    }
}
