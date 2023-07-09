using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    [SerializeField] private Transform spawnParent;
    
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawn = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawn].position, transform.rotation, spawnParent);
        }
    }

    // private IEnumerator SpawnRoutine()
}
