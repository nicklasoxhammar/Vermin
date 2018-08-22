using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int rightArm = 0;
    public int leftArm = 1;

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

    public void RotateArm(int leftOrRight) {

        if(leftOrRight == rightArm) {
            Transform arm = this.gameObject.transform.GetChild(rightArm);
            arm.Rotate(0f, 0f, -57f);
        }

        if(leftOrRight == leftArm) {
            Transform arm = this.gameObject.transform.GetChild(leftArm);
            arm.Rotate(0f, 0f, 57f);
       }

        StartCoroutine(ResetArm(leftOrRight));


    }

    IEnumerator ResetArm(int leftOrRight) {
        yield return new WaitForSeconds(0.4f);

        if (leftOrRight == rightArm) {
            Transform arm = this.gameObject.transform.GetChild(rightArm);
            arm.Rotate(0f, 0f, 57f);     
        }

        if (leftOrRight == leftArm) {
            Transform arm = this.gameObject.transform.GetChild(leftArm);
            arm.Rotate(0f, 0f, -57f);

        }

    }


   
}
