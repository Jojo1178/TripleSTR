using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_Concrete : UsableObject
{
    public O_Concrete(int id) : base(id)
    {
        objectName = "Concrete";
        objectSpriteName = "O_Concrete";
        base.instanciateObjectImage();
    }
}
