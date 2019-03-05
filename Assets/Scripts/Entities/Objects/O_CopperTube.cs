using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_CopperTube : UsableObject
{
    public O_CopperTube(int id) : base(id)
    {
        objectName = "Copper Tube";
        objectSpriteName = "O_CopperTube";
        base.instanciateObjectImage();
    }
}