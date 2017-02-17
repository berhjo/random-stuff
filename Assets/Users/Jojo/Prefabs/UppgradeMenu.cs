using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UppgradeMenu : MonoBehaviour {

    public Camera MainCamera;
    public Camera UppgradeCamera; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (UppgradeCamera.enabled == true)
        {
            Cursor.visible = true; 
        }


		
	}
}
