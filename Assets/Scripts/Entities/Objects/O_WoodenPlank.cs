using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_WoodenPlank : UsableObject
{
    public O_WoodenPlank (int id) : base (id)
    {
        objectName = "Wooden Plank";
        objectSpriteName = "O_WoodenPlank";
        base.instanciateObjectImage();
    }
}
