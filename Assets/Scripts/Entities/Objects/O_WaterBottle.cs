using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_WaterBottle : UsableObject
{
    public O_WaterBottle(int id) : base(id)
    {
        objectName = "Water Bottle";
        objectSpriteName = "O_WaterBottle";
        base.instanciateObjectImage();
    }
}
