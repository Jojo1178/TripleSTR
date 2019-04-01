using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesController : MonoBehaviour
{
    public static EntitiesController INSTANCE;

    public GameObject player;

    public GameObject bank;
    public GameObject well;
    public GameObject door;
    public GameObject townHall;
    public GameObject house;

    [HideInInspector]
    public Building lastSelectedBuilding;

    public EntitiesController()
    {

    }

    private void Awake()
    {
        EntitiesController.INSTANCE = this;
    }

    public Bank getBank()
    {
        return bank.GetComponent<Bank>();
    }

    public Well getWell()
    {
        return well.GetComponent<Well>();
    }

    public Door getDoor()
    {
        return door.GetComponent<Door>();
    }

    public TownHall getTownHall()
    {
        return townHall.GetComponent<TownHall>();
    }

    public Player getPlayer()
    {
        return player.GetComponent<Player>();
    }

    public House getHouse()
    {
        return house.GetComponent<House>();
    }

    public void Build(BuildingSlot buildingSlotInfos)
    {
        GameObject bulidingToBuild = null;
        if (buildingSlotInfos.Prefab != null)
        {
            bulidingToBuild = Resources.Load<GameObject>("BuildingPrefabs/" + buildingSlotInfos.Prefab);
        }

        if (bulidingToBuild != null)
        {
            GameObject building = GameObject.Instantiate(bulidingToBuild);
            Vector3 buildingModificators = building.transform.position;
            building.transform.position = this.lastSelectedBuilding.transform.position + buildingModificators;
            GameObject.Destroy(this.lastSelectedBuilding.gameObject);
            OptionalBuilding ob = building.GetComponent<OptionalBuilding>();
            ob.InitBuilding(EntitiesController.INSTANCE.getPlayer());
        }
        else
        {
            Debug.LogWarning("Prefab not found for " + buildingSlotInfos.Name);
        }
    }
}
