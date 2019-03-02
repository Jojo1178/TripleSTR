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

    private void Awake()
    {
        UIManager.INSTANCE = this;
    }

    public void BuildingSelected(Building selectedBuilding)
    {
        //Affichage de l'UI commune a tous les batiments:
        panelBuildings.SetActive(true);
        EntitiesController.INSTANCE.lastSelectedBuilding = selectedBuilding;

        ////Affichage de l'UI propre a chaque batiment:
        //switch (selectedBuilding.getName())
        //{
        //    case "Bank":
        //        this.bankSelected();
        //        break;
        //    case "Door":
        //        this.doorSelected();
        //        break;
        //    case "Town Hall":
        //        this.townHallSelected();
        //        break;
        //    case "Well":
        //        this.wellSelected();
        //        break;
        //    case "House":
        //        this.houseSelected();
        //        break;
        //    case "Empty Slot":
        //        this.emptySlot();
        //        break;
        //    default:
        //        break;
        //}
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

    public void quitPanelBuildings()
    {
        panelWell.SetActive(false);
        panelDoor.SetActive(false);
        panelBank.SetActive(false);
        panelTownHall.SetActive(false);
        panelHouse.SetActive(false);
        panelEmptySlot.SetActive(false);

        panelBuildings.SetActive(false);
    }
}
