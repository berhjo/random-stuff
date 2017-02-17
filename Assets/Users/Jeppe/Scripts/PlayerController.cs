using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5;
    public float jumpHeight = 5;

    void Start() {

        //Hide mousecursor in game
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {

        float translation = Input.GetAxis("Vertical") * moveSpeed;
        float strafe = Input.GetAxis("Horizontal") * moveSpeed;

        //Movement smoothing
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        //Show mousecursor
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
