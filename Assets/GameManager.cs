using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gm;

    int points = 0;
    int lives = 3;

    float spawnTime = 2.0f;
    public float enemySpeed = 1.5f;

    public List<SpawnPoint> spawnPoints;
    public Player player;

    private void Awake() {
        if (gm == null) {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        }

    }

    void Start () {

        StartCoroutine("SpawnEnemies");

    }

    public void EnemyAtSmashPoint(Enemy enemy) {

        if(player.transform.position.x == enemy.transform.position.x - player.moveDistance) {
            points++;
            player.RotateArm(player.rightArm);
            StartCoroutine(DestroyEnemy(enemy));

        }else if (player.transform.position.x == enemy.transform.position.x + player.moveDistance) {
            points++;
            player.RotateArm(player.leftArm);
            StartCoroutine(DestroyEnemy(enemy));

        }else {
        
            lives--;
            enemy.sprite.color = Color.red;
            StartCoroutine(DestroyEnemy(enemy));

        }


    }

    IEnumerator DestroyEnemy(Enemy enemy) {

        if (spawnTime > 0.1f) {
            spawnTime -= 0.01f;
        }

        if (enemySpeed > 0.5f) {
            enemySpeed -= 0.005f;
        }

        yield return new WaitForSeconds(0.3f);

        enemy.DestroyMarkers();
        Destroy(enemy.gameObject);
    }

   

    IEnumerator SpawnEnemies() {

        bool enemySpawned = false;

        int i = 0;

        while (!enemySpawned) {
            i++;
            enemySpawned = spawnPoints[Random.Range(0, spawnPoints.Count)].SpawnEnemy();

            if (i == 4) {
                break;
            }
    }

        yield return new WaitForSeconds(spawnTime);
        StartCoroutine("SpawnEnemies");



    }
}
