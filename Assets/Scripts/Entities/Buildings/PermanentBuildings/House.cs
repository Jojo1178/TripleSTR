using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : PermanentBuilding, ISelectionableEntity
{

    private int houseInventoryLineNumber = 1;
    private int houseInventoryColumnNumber = 6;

    private int houseInventorySize;
    private UsableObject[] houseInventory;

    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        this.setName("House");

        houseInventorySize = houseInventoryLineNumber * houseInventoryColumnNumber;
        houseInventory = new UsableObject[houseInventorySize];

        //FOR TEST PURPOSE:
        O_WaterBottle waterBottle = new O_WaterBottle(0);
        houseInventory[1] = waterBottle;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool addObjectToHouseInventory(UsableObject objectToAdd)
    {
        for (int i = 0; i < houseInventory.Length; i++)
        {
            if (houseInventory[i] == null)
            {
                houseInventory[i] = objectToAdd;
                return true;
            }
        }
        return false;
    }

    public void removeObjectFromHouseInventory(int inventoryId)
    {
        houseInventory[inventoryId] = null;
    }

    public UsableObject[] getHouseInventory()
    {
        return this.houseInventory;
    }

    public int getHouseInventoryLineNumber()
    {
        return houseInventoryLineNumber;
    }

    public int getHouseInventoryColumnNumber()
    {
        return houseInventoryColumnNumber;
    }
}
