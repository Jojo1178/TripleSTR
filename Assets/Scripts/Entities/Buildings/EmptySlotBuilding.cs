using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySlotBuilding : Building
{
    public enum BuildingTypeEnum {WALL, TOWER, OPTIONAL}

    public BuildingTypeEnum buildingType;

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

    protected override void PlayerReachBuildingEntrance()
    {
        Debug.Log("EmptySlotBuilding : PlayerReachBuildingEntrance");

        base.PlayerReachBuildingEntrance();

        switch (buildingType)
        {
            case BuildingTypeEnum.WALL:
            {
                UIManager.INSTANCE.openWallPanel();
                break;
            }
            case BuildingTypeEnum.TOWER:
            {
                UIManager.INSTANCE.openTowerPanel();
                break;
            }
            case BuildingTypeEnum.OPTIONAL:
            {
                UIManager.INSTANCE.openEmptySlotPanel();
                break;
            }
        }
    }
}
