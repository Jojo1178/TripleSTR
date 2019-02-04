using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : PermanentBuilding, ISelectionableEntity
{
    private int bankInventoryLineNumber = 10;
    private int bankInventoryColumnNumber = 20;
    
    private int bankInventorySize;
    private UsableObject[] bankInventory;

    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        Debug.Log("---> BANK");

        this.setName("Bank");

        bankInventorySize = bankInventoryLineNumber * bankInventoryColumnNumber;
        bankInventory = new UsableObject[bankInventorySize];

        //FOR TEST PURPOSE:
        O_WaterBottle waterBottle = new O_WaterBottle(0, "Water Bottle", "O_WaterBottle");
        bankInventory[0] = waterBottle;

        O_WaterBottle waterBottle2 = new O_WaterBottle(2, "Water Bottle", "O_WaterBottle");
        bankInventory[1] = waterBottle2;

        O_WaterBottle waterBottle10 = new O_WaterBottle(10, "Water Bottle", "O_WaterBottle");
        bankInventory[3] = waterBottle10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public UsableObject[] getBankInventory()
    {
        return this.bankInventory;
    }

    public int getBankInventoryLineNumber()
    {
        return bankInventoryLineNumber;
    }

    public int getBankInventoryColumnNumber()
    {
        return bankInventoryColumnNumber;
    }
}
