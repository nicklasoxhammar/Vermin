using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

    private Transform cam;             //reference to the main cameras transform.

    private Transform currentBackground;
    private Transform otherBackground;

    [SerializeField] Transform[] backgrounds;
    [SerializeField] float rotationSpeed = 50f;

    private float backgroundWidth;


    // Use this for initialization
    void Start() {

        cam = Camera.main.transform;

        currentBackground = backgrounds[0];
        otherBackground = backgrounds[1];

        backgroundWidth = currentBackground.gameObject.GetComponent<Renderer>().bounds.size.x;

    }

    // Update is called once per frame
    void Update() {

        transform.position = new Vector3(transform.position.x - 1 * Time.deltaTime * rotationSpeed, transform.position.y, transform.position.y);//(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
        //transform.Rotate(Vector3.left * Time.deltaTime * rotationSpeed, Space.World);


        //Change the "currentBackground" depending on camera position
        if (cam.position.x > currentBackground.position.x + backgroundWidth || cam.position.x < currentBackground.position.x - backgroundWidth) {

            Transform previous = currentBackground;

            currentBackground = otherBackground;
            otherBackground = previous;
        }

        //if current background is to the left of camera then move the other background left
        if (currentBackground.position.x < cam.position.x) {
            otherBackground.position = new Vector3(currentBackground.position.x + backgroundWidth, otherBackground.position.y, otherBackground.position.z);
        }

        //if current background is to the right of camera then move the other background right
        if (currentBackground.position.x > cam.position.x) {
            otherBackground.position = new Vector3(currentBackground.position.x - backgroundWidth, otherBackground.position.y, otherBackground.position.z);
        }

    }

 
}
