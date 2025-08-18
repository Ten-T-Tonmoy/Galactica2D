using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{

    EnemySpawner enemeySpawner;
    WaveConfig currentWaveConfig;
    List<Transform> waypoints;
    int waypointIdx = 0;

    private void Awake()
    {
        enemeySpawner = FindFirstObjectByType<EnemySpawner>();
    }
    void Start()
    {
        //ps the naming
        currentWaveConfig = enemeySpawner.GetCurentWave();
        waypoints = currentWaveConfig.GetWaypoints();
        transform.position = waypoints[waypointIdx].position;

    }

    // Update is called once per frame
    void Update()
    {
        FollowAlongPath();


    }

    void FollowAlongPath()
    {
        if (waypointIdx < waypoints.Count)
        {
            // 
            Vector3 targetPosition = waypoints[waypointIdx].position;
            float delta = currentWaveConfig.GetMovingSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            //had to make vector3 just to compare with transform pos
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                //dont tf make float == comparisons it sucks
                waypointIdx++;
            }

        }
        else
        {
            Destroy(gameObject);
            // GetComponent<SpriteRenderer>() litreally yep
            // gameObject.name access the name?
            //entireity
        }
    }
}
