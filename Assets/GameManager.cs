using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gm;

    int points = 0;

    public List<GameObject> spawnPoints;
    public List<GameObject> smashPoints;
    public Player player;

    private void Awake() {
        if (gm == null) {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnemyAtSmashPoint(Enemy enemy) {

        if(player.transform.position.x == enemy.transform.position.x - 4) {

            player.RotateArm(player.rightArm);
            Smash(enemy);
        }

        if (player.transform.position.x == enemy.transform.position.x + 4) {
            player.RotateArm(player.leftArm);

            Smash(enemy);

        }

    }

    void Smash(Enemy enemy) {
        points++;
        Destroy(enemy.gameObject);
       
    }
}
