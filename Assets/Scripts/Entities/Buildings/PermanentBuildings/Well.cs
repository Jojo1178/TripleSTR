using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : PermanentBuilding, ISelectionableEntity
{
    private int waterMaximumQuantity;
    private int waterCurrentQuantity;

    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        this.setName("Well");

        waterMaximumQuantity = 10;
        waterCurrentQuantity = waterMaximumQuantity;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getWaterMaximumQuantity()
    {
        return this.waterMaximumQuantity;
    }

    public int getWaterCurrentQuantity()
    {
        return this.waterCurrentQuantity;
    }

    public O_WaterBottle getWaterFromWell()
    {
        if (waterCurrentQuantity > 0)
        {
            O_WaterBottle waterBottle = new O_WaterBottle(0, "Water Bottle", "O_WaterBottle");
            waterCurrentQuantity--;

            return waterBottle;
        }
        else
        {
            return null;
        }
    }
}
