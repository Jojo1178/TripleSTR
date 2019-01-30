using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySlotBuilding : Building
{
    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        this.setName("Empty Slot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
