using UnityEngine;
using System.Collections;

public class MineStone : MonoBehaviour {
    Camera camera;
    public float stones;
    float upgradeCostPick;
    float upgradeCostInventory;
    public float pickStonePerHit;
    public float inventorySize;
    public float mineRate = 1F;
    private float timestamp = 0F;
    public float credits;
    
    public Stone rayHit;
    public bool addStones;
    public RaycastHit hit;
    public Color textColor;

    void Start () {
        camera = GetComponent<Camera>();
        stones = PlayerState.Instance.localPlayerData.inventory;
        upgradeCostPick = 10F;
        upgradeCostInventory = 30F;
        pickStonePerHit = 10F;
        inventorySize = 100;
        credits = PlayerState.Instance.localPlayerData.Material;
    }
    
    void Update () {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            Ray ray = camera.ScreenPointToRay(new Vector3(x, y, 0));
            if (Time.time >= timestamp && stones < inventorySize)
            {
                timestamp = Time.time + mineRate;
                
                if (Physics.Raycast(ray, out hit, 2))
                {
                    rayHit = hit.collider.GetComponentInParent<Stone>();
                }
                else
                {
                    hit = new RaycastHit();
                    rayHit = null;
                }
            }
            if(Physics.Raycast(ray, out hit, 2) && stones > 0)
            {
                if (hit.collider.gameObject.tag == "DropOff")
                {
                    stones--;
                    credits++;
                }
            }
        }
       
       

    }


   public void UpgradePickAxe()
    {
        if (credits >= upgradeCostPick)
        {
            credits -= (int)(Mathf.Floor(upgradeCostPick));
            pickStonePerHit += 1F;
            upgradeCostPick *= 1.1F;
        }
       
    }
    public void UpgradeInventory()
    {
         if ( credits >= upgradeCostInventory)
        {
            credits -= (int)(Mathf.Floor(upgradeCostInventory));
            inventorySize += 10F;
            upgradeCostInventory *= 1.2F;
        }
    }
  
}
