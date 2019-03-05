using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_Screws : UsableObject
{
    public O_Screws(int id) : base(id)
    {
        objectName = "Screws";
        objectSpriteName = "O_Screws";
        base.instanciateObjectImage();
    }
}