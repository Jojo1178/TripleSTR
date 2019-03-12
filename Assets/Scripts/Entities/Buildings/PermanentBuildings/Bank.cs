using System;
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
        O_Concrete concrete = new O_Concrete(0);
        this.addObjectToBankInventory(concrete);
        O_CopperTube coppertube = new O_CopperTube(0);
        this.addObjectToBankInventory(coppertube);
        O_ElectronicComponent electronicComponent = new O_ElectronicComponent(0);
        this.addObjectToBankInventory(electronicComponent);
        O_MetalScrap metalScrap = new O_MetalScrap(0);
        this.addObjectToBankInventory(metalScrap);
        O_Screws screws = new O_Screws(0);
        this.addObjectToBankInventory(screws);
        O_SteelPlate steelPlate = new O_SteelPlate(0);
        this.addObjectToBankInventory(steelPlate);
        O_WaterBottle waterBottle = new O_WaterBottle(0);
        this.addObjectToBankInventory(waterBottle);
        O_WoodenPlank woodenPlank = new O_WoodenPlank(0);
        this.addObjectToBankInventory(woodenPlank);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool addObjectToBankInventory(UsableObject objectToAdd)
    {
        for (int i = 0; i < bankInventory.Length; i++)
        {
            if (bankInventory[i] == null)
            {
                bankInventory[i] = objectToAdd;
                return true;
            }
        }
        return false;
    }

    public bool areResourcesAvailable(List<Tuple<UsableObject, int>> resourceList)
    {
        foreach (Tuple<UsableObject, int> resourceTuple in resourceList)
        {
            UsableObject usableObject = resourceTuple.Item1;
            int quantityNeeded = resourceTuple.Item2;

            int quantityFound = 0;
            for (int i = 0; i < bankInventory.Length; i++)
            {
                if (bankInventory[i] != null)
                {
                    if (bankInventory[i].GetType().Equals(usableObject.GetType()))
                    {
                        quantityFound++;
                    }
                }
            }
            if (quantityFound < quantityNeeded)
            {
                return false;
            }
        }
        return true;
    }

    public int getNumberOfObjectInBankInventory(UsableObject usableObject)
    {
        int numberInBank = 0;

        for (int i = 0; i < bankInventory.Length; i++)
        {
            if (bankInventory[i] != null)
            {
                if (bankInventory[i].GetType().Equals(usableObject.GetType()))
                {
                    numberInBank++;
                }
            }
        }

        return numberInBank;
    }

    public void removeObjectFromBankInventory(int inventoryId)
    {
        bankInventory[inventoryId] = null;
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

    protected override void PlayerReachBuildingEntrance()
    {
        base.PlayerReachBuildingEntrance();
        UIManager.INSTANCE.openBankPanel();
    }
}
