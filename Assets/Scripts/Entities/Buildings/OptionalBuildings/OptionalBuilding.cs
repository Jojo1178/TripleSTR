using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionalBuilding : Building
{
    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        Debug.Log("---> OPTIONAL BUILDING");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
