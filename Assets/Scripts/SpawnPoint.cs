using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
   
    public GameObject enemy;
    GameObject spawnedEnemy;


    public bool SpawnEnemy() {

        if (this.transform.childCount == 0) {
            spawnedEnemy = Instantiate(enemy, transform.position, transform.rotation);
            spawnedEnemy.transform.parent = transform;
            return true;
        }

        return false;
        
    }

    public void StopSpawnedEnemy() {
        Destroy(spawnedEnemy);
    }
}
