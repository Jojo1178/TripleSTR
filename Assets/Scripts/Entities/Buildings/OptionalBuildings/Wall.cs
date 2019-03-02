using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : OptionalBuilding, ISelectionableEntity
{
    private new void Start()
    {
        base.Start();
        Debug.Log("---> WALL");
        this.setName("Wall");
        this.StartConstruction();
    }
}
