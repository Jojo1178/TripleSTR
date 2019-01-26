using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : PermanentBuilding, ISelectionableEntity
{
    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        this.setName("Door");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
