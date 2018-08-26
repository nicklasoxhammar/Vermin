using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gm;

    int points = 0;
    int lives = 3;

    float spawnTime = 1.5f;
    public float enemySpeed = 1.0f;

    public Text pointsText;
    public GameObject lifeImages;
    public GameObject gameOverScreen;
    public GameObject highScoreScreen;

    public List<SpawnPoint> spawnPoints;
    public Player player;

    private void Awake() {
        if (gm == null) {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        }

    }

    void Start () {

        StartCoroutine(SpawnEnemies());
    }

    public void EnemyAtSmashPoint(Enemy enemy) {

        if(Mathf.Approximately(player.transform.position.x, enemy.transform.position.x - player.moveDistance)) {
            points++;
            player.Smash(player.rightArm);
            StartCoroutine(DestroyEnemy(enemy));

        }else if (Mathf.Approximately(player.transform.position.x, enemy.transform.position.x + player.moveDistance)) {
            points++;
            player.Smash(player.leftArm);
            StartCoroutine(DestroyEnemy(enemy));

        }else {

            lives--;
            enemy.sprite.color = Color.red;
            enemy.gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(DestroyEnemy(enemy));
            lifeImages.transform.GetChild(lives).GetComponent<Image>().color = Color.black;

            if (lives == 0) {
                GameOver();
            }


        }

        pointsText.text = points.ToString();


    }

    IEnumerator DestroyEnemy(Enemy enemy) {

        if (spawnTime > 0.8f) {
            spawnTime -= 0.02f;
        }

        if (enemySpeed > 0.3f) {
            enemySpeed -= 0.01f;
        }

        yield return new WaitForSeconds(0.3f);
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
        StartCoroutine(SpawnEnemies());

    }

    void GameOver() {
        gameObject.GetComponent<AudioSource>().Play();
        StopAllCoroutines();
        player.Defeated();

        foreach(SpawnPoint s in spawnPoints) {
            s.stopSpawnedEnemy();
        }

        if (points > PlayerPrefs.GetInt("highscore", 0)) {
            NewHighScore();
        }
        else {
            gameOverScreen.SetActive(true);
        }


    }

    void NewHighScore() {
        PlayerPrefs.SetInt("highscore", points);
        highScoreScreen.SetActive(true);
        highScoreScreen.GetComponentInChildren<Text>().text = "New High Score: " + PlayerPrefs.GetInt("highscore", 0) + "!";
        
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
