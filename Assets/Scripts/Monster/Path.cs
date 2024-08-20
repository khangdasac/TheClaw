using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public bool isDrawPath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawPath();
    }

    public void DrawPath()
    {
        if (!isDrawPath)
            return;

        int length = waypoints.Count;
        for (int i = 0; i < length; i++)
        {
            if(i != length - 1)
            {
                Debug.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position, Color.red);
            }
            else
            {
                Debug.DrawLine(waypoints[i].transform.position, waypoints[0].transform.position, Color.red);
            }
        }
    }
}
