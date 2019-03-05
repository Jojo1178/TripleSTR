using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_SteelPlate : UsableObject
{
    public O_SteelPlate(int id) : base(id)
    {
        objectName = "Steel Plate";
        objectSpriteName = "O_SteelPlate";
        base.instanciateObjectImage();
    }
}