using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new WaveConfig", menuName = "WaveConfig")]
//scriptable so it wont get attached!
//shortcut to creaing .assets
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    // creating empty just gives out transform!
    // has position,localScale,rotation
    [SerializeField] Transform pathPrefabs;
    [SerializeField] float movespeed = 5f;
    [SerializeField] float timeGapOfSpawning = 1f;
    // to add randomness of spawn
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;


    public int GetEnemyNumber()
    {
        return enemyPrefabs.Count; //length of array?
    }

    public GameObject GetEnemyPrefabs(int index)
    {
        return enemyPrefabs[index];
    }

    public Transform GetStartingPointOfPath()
    {
        return pathPrefabs.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        // iterate over childs of a object
        foreach (Transform child in pathPrefabs)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetMovingSpeed()
    {
        return movespeed;
    }


    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(
            timeGapOfSpawning - spawnTimeVariance,
            timeGapOfSpawning + spawnTimeVariance
            );
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
