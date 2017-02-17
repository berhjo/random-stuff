using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickSway : MonoBehaviour {
    float mouseX;
    float mouseY;
    Quaternion rotationSpeed;
    public float speed;

	void Start () {
		
	}
	
	void Update () {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        rotationSpeed = Quaternion.Euler(-mouseY, -80.888f - mouseX, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotationSpeed, speed * Time.deltaTime);
	}
}
