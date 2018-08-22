using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    bool enemySpawned = false;
   
    public GameObject enemy;


    public bool SpawnEnemy() {

        if (this.transform.childCount == 0) {
            GameObject spawnedEnemy = Instantiate(enemy, transform.position, transform.rotation);
            spawnedEnemy.transform.parent = transform;
            return true;
        }

        return false;
        
    }
}
