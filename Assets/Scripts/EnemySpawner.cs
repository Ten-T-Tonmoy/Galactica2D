using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> enemyWaveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    WaveConfig currentWave;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
