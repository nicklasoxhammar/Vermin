using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [HideInInspector] public int rightArm = 0;
    [HideInInspector] public int leftArm = 1;
    [HideInInspector] public int rightLeg = 3;
    [HideInInspector] public int leftLeg = 4;
    int head = 2;

    bool defeated = false;

    public int moveDistance = 4;

    public float rotationSpeed = 1f;

	void Update () {

        if (!defeated) {
            Move();
        }
    }

    public void Move() {

        if (CrossPlatformInputManager.GetButtonDown("Left")) {

            if (transform.position.x > -moveDistance) {
                transform.position += Vector3.left * moveDistance;
                RotateLeg(leftLeg);
            }

        }

        if (CrossPlatformInputManager.GetButtonDown("Right")) {

            if (transform.position.x < moveDistance) {
                transform.position += Vector3.right * moveDistance;
                RotateLeg(rightLeg);
            }

        }

    }


    public void Smash(int leftOrRight) {
        gameObject.GetComponent<AudioSource>().Play();

        if (leftOrRight == rightArm) {
            gameObject.transform.GetChild(rightArm).Rotate(0.0f, 0.0f, -57.0f);
        }

        if(leftOrRight == leftArm) {
            gameObject.transform.GetChild(leftArm).Rotate(0.0f, 0.0f, 57.0f);
       }

        StartCoroutine(ResetArm(leftOrRight));


    }

    IEnumerator ResetArm(int leftOrRight) {
        yield return new WaitForSeconds(0.2f);

        if (leftOrRight == rightArm) {
            gameObject.transform.GetChild(rightArm).rotation = Quaternion.identity;        
        }

        if (leftOrRight == leftArm) {
            gameObject.transform.GetChild(leftArm).rotation = Quaternion.identity;
        }

    }

    void RotateLeg(int leftOrRight) {

        if (leftOrRight == leftLeg) {
            gameObject.transform.GetChild(leftLeg).Rotate(0.0f, 0.0f, -20.0f);
            gameObject.transform.GetChild(rightLeg).rotation = Quaternion.identity;
        }


        if (leftOrRight == rightLeg) {
            gameObject.transform.GetChild(rightLeg).Rotate(0.0f, 0.0f, 20.0f);
            gameObject.transform.GetChild(leftLeg).rotation = Quaternion.identity;
        }



    }


    public void Defeated() {

        defeated = true;

        StartCoroutine(defeatedStance());

    }

    IEnumerator defeatedStance() {

        gameObject.transform.GetChild(rightLeg).rotation = Quaternion.identity;
        gameObject.transform.GetChild(leftLeg).rotation = Quaternion.identity;

        for (int i = 0; i < 3; i++) {

            gameObject.transform.GetChild(rightArm).Rotate(0.0f, 0.0f, -35.0f);
            gameObject.transform.GetChild(leftArm).Rotate(0.0f, 0.0f, 35.0f);
            gameObject.transform.GetChild(head).Rotate(0.0f, 0.0f, -20.0f);

            yield return new WaitForSeconds(0.5f);

        }

    }


   
}
