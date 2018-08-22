using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Move();
		
	}

    void Move() {

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            if (transform.position.x > -4) {
                transform.position += Vector3.left * 4;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {

            if (transform.position.x < 4) {
                transform.position += Vector3.right * 4;
            }
        }


    }

   
}
