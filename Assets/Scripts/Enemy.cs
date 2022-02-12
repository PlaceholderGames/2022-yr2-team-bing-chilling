
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 8f;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        target = WaypointsFollow.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= WaypointsFollow.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = WaypointsFollow.points[wavepointIndex];
    }


}
