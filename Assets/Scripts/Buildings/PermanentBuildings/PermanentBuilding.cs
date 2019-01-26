using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentBuilding : Building
{
    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        Debug.LogError("---> PERMANENT BUILDING");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
