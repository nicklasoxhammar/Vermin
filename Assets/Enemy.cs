using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameManager gameManager;

	// Use this for initialization
	void Start () {

        InvokeRepeating("GoUp", 0.0f, 1.5f);
		
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.position.y == -1) {
            CancelInvoke();
            GameManager.gm.EnemyAtSmashPoint(this);
        
        }
		
	}

    void GoUp() {

        if(transform.position.y < -1) {
            transform.position += Vector3.up;
        }
        
    }

   


}
