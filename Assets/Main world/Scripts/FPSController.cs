using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {

    public GameObject camera;

    public float moveSpeed = 2;
    public float lookSensitivity = 2;
    public float jumpHeight = 2;

    Vector3 move;
    CharacterController player;

    float moveLR;
    float moveFB;

    float rotX;
    float rotY;
    float getGravity;

    // Use this for initialization
    void Start() {

        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {

        moveLR = Input.GetAxis("Horizontal") * moveSpeed;
        moveFB = Input.GetAxis("Vertical") * moveSpeed;

        rotX = Input.GetAxis("Mouse X") * lookSensitivity;
        rotY = Input.GetAxis("Mouse Y") * lookSensitivity;

        //rotY = Mathf.Clamp(-rotY, -60f, 60f);

        move = new Vector3(moveLR, getGravity, moveFB);
        transform.Rotate(0, rotX, 0);
        camera.transform.Rotate(-rotY, 0, 0);
        //camera.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        move = transform.rotation * move;
        player.Move(move * Time.deltaTime);

        if (Input.GetButton("Jump")) {

            getGravity += jumpHeight;
        }
    }


    void FixedUpdate() {

        if (player.isGrounded == false) {
            getGravity += Physics.gravity.y * Time.deltaTime;
        }
        else {
            getGravity = 0;
        }
    }
}
