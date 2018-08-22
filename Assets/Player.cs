using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int rightArm = 0;
    public int leftArm = 1;

    public int moveDistance = 4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Move();
		
	}

    void Move() {

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            if (transform.position.x > -moveDistance) {
                transform.position += Vector3.left * moveDistance;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {

            if (transform.position.x < moveDistance) {
                transform.position += Vector3.right * moveDistance;
            }
        }


    }

    public void RotateArm(int leftOrRight) {

        if(leftOrRight == rightArm) {
            Transform arm = this.gameObject.transform.GetChild(rightArm);
            arm.Rotate(0.0f, 0.0f, -57.0f);
        }

        if(leftOrRight == leftArm) {
            Transform arm = this.gameObject.transform.GetChild(leftArm);
            arm.Rotate(0.0f, 0.0f, 57.0f);
       }

        StartCoroutine(ResetArm(leftOrRight));


    }

    IEnumerator ResetArm(int leftOrRight) {
        yield return new WaitForSeconds(0.2f);

        if (leftOrRight == rightArm) {
            Transform arm = this.gameObject.transform.GetChild(rightArm);
            arm.Rotate(0.0f, 0.0f, 57.0f);     
        }

        if (leftOrRight == leftArm) {
            Transform arm = this.gameObject.transform.GetChild(leftArm);
            arm.Rotate(0.0f, 0.0f, -57.0f);

        }

    }


   
}
