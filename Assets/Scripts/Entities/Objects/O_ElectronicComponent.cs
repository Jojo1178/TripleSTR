using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_ElectronicComponent : UsableObject
{
    public O_ElectronicComponent(int id) : base(id)
    {
        objectName = "Electronic Component";
        objectSpriteName = "O_ElectronicComponent";
        base.instanciateObjectImage();
    }
}