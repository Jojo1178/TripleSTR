using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_MetalScrap : UsableObject
{
    public O_MetalScrap(int id) : base(id)
    {
        objectName = "Metal Scrap";
        objectSpriteName = "O_MetalScrap";
        base.instanciateObjectImage();
    }
}
