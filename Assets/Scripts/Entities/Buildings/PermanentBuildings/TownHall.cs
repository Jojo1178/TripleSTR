using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : PermanentBuilding, ISelectionableEntity
{
    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        this.setName("Town Hall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void PlayerReachBuildingEntrance()
    {
        base.PlayerReachBuildingEntrance();
        UIManager.INSTANCE.openTownHallPanel();
    }
}
