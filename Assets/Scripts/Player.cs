using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [HideInInspector] public int rightArm = 0;
    [HideInInspector] public int leftArm = 1;
    int head = 2;

    bool defeated = false;

    public int moveDistance = 4;

    public float rotationSpeed = 1f;

	void Update () {

        /*if (!defeated) {
            Move();
        }*/
		
	}

    public void Move(string direction) {

        if (defeated) {
            return;
        }

        if (direction.Equals("Left")) {

            if (transform.position.x > -moveDistance) {
                transform.position += Vector3.left * moveDistance;
            }
        }

        if (direction.Equals("Right")) {

            if (transform.position.x < moveDistance) {
                transform.position += Vector3.right * moveDistance;
            }
        }

        /* if (Input.GetKeyDown(KeyCode.LeftArrow)) {

             if (transform.position.x > -moveDistance) {
                 transform.position += Vector3.left * moveDistance;
             }
         }

         if (Input.GetKeyDown(KeyCode.RightArrow)) {

             if (transform.position.x < moveDistance) {
                 transform.position += Vector3.right * moveDistance;
             }
         }*/


    }


    public void Smash(int leftOrRight) {
        gameObject.GetComponent<AudioSource>().Play();

        if (leftOrRight == rightArm) {
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


    public void Defeated() {

        defeated = true;

        StartCoroutine(defeatedStance());

    }

    IEnumerator defeatedStance() {

        for (int i = 0; i < 3; i++) {

            gameObject.transform.GetChild(rightArm).Rotate(0.0f, 0.0f, -35.0f);
            gameObject.transform.GetChild(leftArm).Rotate(0.0f, 0.0f, 35.0f);
            gameObject.transform.GetChild(head).Rotate(0.0f, 0.0f, -20.0f);

            yield return new WaitForSeconds(0.5f);

        }

    }


   
}
