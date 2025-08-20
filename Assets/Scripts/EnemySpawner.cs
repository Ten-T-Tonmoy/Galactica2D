using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> enemyWaveConfigs; // config+path inside of config
    [SerializeField] float timeBetweenWaves = 2f;
    // for multiple wave
    [SerializeField] bool isInfiniteWaveLooping;
    WaveConfig currentWave;

    void Start()
    {
        //coRoutine
        // async await bt yield type 
        //Ienumerator func
        //yield return new waitForSeconds(2f); yield is the pauser
        //yield return new waitUntil(()=>);

        StartCoroutine(SpawnEnemies());

    }

    public WaveConfig GetCurentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (WaveConfig wave in enemyWaveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyNumber(); i++)
                {
                    //instantiate makes copy of prefab/obj at runtime
                    // (prefab,position,rotation,parentTransform)
                    // just pass parent transForm auto happens
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingPointOfPath().position,
                                Quaternion.Euler(0, 0, 180), transform);
                    //transform is always unique.. in this case its of this gameObj
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isInfiniteWaveLooping);


    }
}
