using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : PermanentBuilding, ISelectionableEntity
{
    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        Debug.LogError("---> BANK");

        this.setName("Bank");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
