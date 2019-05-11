using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefensiveTower : OptionalBuilding, ISelectionableEntity
{
    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        this.setName("Defensive Tower");
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void PlayerReachBuildingEntrance()
    {
        Debug.LogError("Defensive Tower : PlayerReachBuildingEntrance");
        base.PlayerReachBuildingEntrance();
        UIManager.INSTANCE.openTowerPanel();
    }
}
