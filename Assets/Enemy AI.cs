using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    public GameObject[] waypoints;
    int nextwaypoint = 1;
    float distancepoint;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        distancepoint = Vector2.Distance(transform.position, waypoints[nextwaypoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, waypoints[nextwaypoint].transform.position, speed * Time.deltaTime);

        if(distancepoint < 0.08f)
        {
            TakeTurn();
        }
    }

    void TakeTurn()
    {
        Vector3 currentlocation = transform.eulerAngles;
        currentlocation.z += waypoints[nextwaypoint].transform.eulerAngles.z;
        transform.eulerAngles = currentlocation;
        choosewaypoint();
    }

    void choosewaypoint()
    {
        nextwaypoint++;
        if(nextwaypoint == waypoints.Length)
        {
            nextwaypoint = 0;
        }
    }
}
