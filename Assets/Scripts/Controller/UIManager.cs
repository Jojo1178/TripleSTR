using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager INSTANCE;

    //Panels:
    public GameObject panelBuildings;

    public GameObject panelWell;
    public GameObject panelDoor;
    public GameObject panelBank;
    public GameObject panelTownHall;
    public GameObject panelEmptySlot;
    public GameObject panelHouse;
    public GameObject panelWall;
    public GameObject panelWallCorner;
    public GameObject panelTower;

    private void Awake()
    {
        UIManager.INSTANCE = this;
    }

    public void BuildingSelected(Building selectedBuilding)
    {
        //Affichage de l'UI commune a tous les batiments:
        panelBuildings.SetActive(true);
        EntitiesController.INSTANCE.lastSelectedBuilding = selectedBuilding;
    }

    public void UnitSelected(Unit selectedUnit)
    {
        Debug.Log("Unit " + selectedUnit + " selected.");
    }

    public void MapSelected(Map selectedMap)
    {
        Debug.Log("Map " + selectedMap + " selected.");
    }

    public void openWellPanel()
    {
        panelWell.SetActive(true);
    }

    public void openBankPanel()
    {
        panelBank.SetActive(true);
    }

    public void openTownHallPanel()
    {
        panelTownHall.SetActive(true);
    }

    public void openDoorPanel()
    {
        panelDoor.SetActive(true);
    }

    public void openHousePanel()
    {
        panelHouse.SetActive(true);
    }

    public void openEmptySlotPanel()
    {
        panelEmptySlot.SetActive(true);
    }

    public void openWallPanel()
    {
        panelWall.SetActive(true);
    }

    public void openWallCornerPanel()
    {
        panelWallCorner.SetActive(true);
    }

    public void openTowerPanel()
    {
        panelTower.SetActive(true);
    }

    public void quitPanelBuildings()
    {
        panelWell.SetActive(false);
        panelDoor.SetActive(false);
        panelBank.SetActive(false);
        panelTownHall.SetActive(false);
        panelHouse.SetActive(false);
        panelEmptySlot.SetActive(false);
        panelWall.SetActive(false);
        panelWallCorner.SetActive(false);
        panelTower.SetActive(false);

        panelBuildings.SetActive(false);
    }
}
