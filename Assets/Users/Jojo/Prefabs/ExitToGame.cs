using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToGame : MonoBehaviour {

    public Camera MainCamera;
    public Camera UppgradeCamera;
    public GameObject Player;


	// Use this for initialization
	void Start () {

        
        Player = GameObject.Find("FPSController");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ButtonClicked()
    {
        UppgradeCamera.enabled = false;
        MainCamera.enabled = true;
        Player.gameObject.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Fail"); 


    }
}
