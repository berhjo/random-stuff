using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    Vector2 mouseLook;
    Vector2 smoothLook;

    public float lookSens = 5.0f;
    public float lookSmooth = 5.0f;

    GameObject character;

    //Start
    void Start() {

        character = this.transform.parent.gameObject;
    }

    //Update
    void Update() {

        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(lookSens * lookSmooth, lookSens * lookSmooth));

        //So smoothing
        smoothLook.x = Mathf.Lerp(smoothLook.x, md.x, 1f / lookSmooth);
        smoothLook.y = Mathf.Lerp(smoothLook.y, md.y, 1f / lookSmooth);
        mouseLook += smoothLook;

        //Lock X rot
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
