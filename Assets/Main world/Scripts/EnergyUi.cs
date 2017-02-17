using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUi : MonoBehaviour {

    //Variables for the character

    public bool Inbounds = false;
    public Slider Energy;
    public Text EnergyPercentage;
    public Text Inventory;
    public Text Material;
    public float InventoryMax;
    public float CurrentInventory = 0; 
    public int EnergyMax;
    public float EnergyDrain;
    public float EnergyGain; 
    public float CurrentEnergy;
    public float TemperatureMultipier = 1;
    public int SprintMultiplier;
    public Text ActivationButton;
    private float Credits; 
    
    

    // Use this for initialization
    void Start ()
    {
        //Sets up the starting values and Initializes the ui. 
        Energy.maxValue = EnergyMax;
        Energy.value = EnergyMax;
        EnergyPercentage.text = Energy.value + "%";
        CurrentEnergy = EnergyMax;
        
        
	}


    void OnTriggerEnter(Collider other) //Checks for collisions with other objects 
    {
        if (other.tag == "AirZone") //Checks for collisions with objects with the tag "AirZone"
        {
            Inbounds = true; //If the character is inside an Airzone the bool Inbounds is set to true
        }
        else if (other.tag == "TemperatureZone") //Checks for collisions with objects with the tag "Temperature"
        {
            TemperatureMultipier = 3; //Increases the oxygen drain to 3 per second
        }

        if (other.tag == "CanBeActivated")
        {
            ActivationButton.text = "Press 'E' To activate";
        }



    }
    void OnTriggerExit(Collider other) //Resets the variables 
    {
        if (other.tag == "AirZone") //Upon exiting an airzone, the bool inbounds i set to false
        {
            Inbounds = false; 
        }
        else if (other.tag == "TemperatureZone") //Resets the oxygen drain to 1
        {
            TemperatureMultipier = 1;
        }
        if (other.tag == "CanBeActivated")
        {
            ActivationButton.text = "";
        }
    }

	
	// Update is called once per frame
	void Update ()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "CanBeActivated" || hit.collider.gameObject.tag == "DropOff" )
            {
                ActivationButton.text = "Press 'E' To activate";
            }
        }
        else
        {
            ActivationButton.text = ""; 
        }


                if (!Inbounds) //If the character isn't inside a house
        {
            CurrentEnergy -= Time.deltaTime * (EnergyDrain*TemperatureMultipier); //Energy is drained depending on where the player is. 
        }
        else if (Inbounds && Energy.value <= EnergyMax)
        {
            CurrentEnergy += Time.deltaTime * EnergyGain; //If the player is inside a house the energy increases the energy gained 
        }

        if (CurrentEnergy > 100) //Prevents energy from going higher than 100 
        {
            CurrentEnergy = 100; 
        }

        CurrentInventory = GameObject.Find("MainCamera").GetComponent<MineStone>().stones; //Changes the inventoryText depending on how many rocks has been collected
        InventoryMax = GameObject.Find("MainCamera").GetComponent<MineStone>().inventorySize;
        Credits = GameObject.Find("MainCamera").GetComponent<MineStone>().credits;

        Inventory.text = CurrentInventory + "/" + InventoryMax; //Changes the inventory text
        Energy.value = CurrentEnergy;  //Updates the energy value on the slider 
        Material.text = Credits + "$";

        

        EnergyPercentage.text = Energy.value + "%"; //Updates the text by the energy slider 

    }
}
