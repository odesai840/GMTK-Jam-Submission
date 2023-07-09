using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    [SerializeField] private Transform spawnParent;
    [SerializeField] private float spawnCooldown = 6f;
    public CameraFollow CameraFollow;
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public CharacterScript character;
    public GhostScript GhostScript;
    public HunterMovement HunterScript;

    private bool isSpawning = false;

    private void Update(){
        if(!isSpawning){
            isSpawning = true;
            StartCoroutine(SpawnRoutine());
            GetComponent<Transform>().position = new Vector3(Random.Range(CameraFollow.xlowerlimit, CameraFollow.xupperlimit), Random.Range(CameraFollow.ylowerlimit, CameraFollow.yupperlimit), 0);
        }
    }

    private IEnumerator SpawnRoutine(){
        Spawn();
        yield return new WaitForSeconds(spawnCooldown);
        isSpawning = false;
    }

    private void Spawn(){
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawn = Random.Range(0, spawnPoints.Length);
        //Debug.Log("spawning");
        int randlevel = Random.Range(7, 100);

        GhostScript.GetComponent<GhostScript>().level = randlevel;

        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawn].position, transform.rotation, spawnParent);
        
    }
}
