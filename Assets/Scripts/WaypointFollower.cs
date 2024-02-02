using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWayPoint = 0;

    [SerializeField] private float speed = 2f;

    void Update()
    {
        Transform waypointTransform = waypoints[currentWayPoint].transform;
        if (Vector2.Distance(waypointTransform.position, transform.position) < 0.1f)
        {
            currentWayPoint++;
            if (currentWayPoint >= waypoints.Length)
            {
                currentWayPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypointTransform.position, Time.deltaTime * speed);
    }
}
