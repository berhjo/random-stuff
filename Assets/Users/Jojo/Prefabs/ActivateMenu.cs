using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenu : MonoBehaviour {

    public GameObject Player; 
    public bool Inbounds = false;
    public Camera MainCamera;
    public Camera UppgradeCamera; 


	// Use this for initialization
	void Start () {

        Player = GameObject.Find("FPSController");
        
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Inbounds && Input.GetKeyDown(KeyCode.E))
        {

            MainCamera.enabled = false;
            UppgradeCamera.enabled = true;
            Player.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
        }
        
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Inbounds = true; 
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Inbounds = false; 
        }
    }
}
