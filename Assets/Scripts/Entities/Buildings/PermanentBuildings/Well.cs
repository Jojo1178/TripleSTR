using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : PermanentBuilding, ISelectionableEntity
{
    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        this.setName("Well");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
