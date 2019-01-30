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

    private void Awake()
    {
        UIManager.INSTANCE = this;
    }

    public void BuildingSelected(Building selectedBuilding)
    {
        //Affichage de l'UI commune a tous les batiments:
        panelBuildings.SetActive(true);

        //Affichage de l'UI propre a chaque batiment:
        switch (selectedBuilding.getName())
        {
            case "Bank":
                this.bankSelected();
                break;
            case "Door":
                this.doorSelected();
                break;
            case "Town Hall":
                this.townHallSelected();
                break;
            case "Well":
                this.wellSelected();
                break;
            case "Empty Slot":
                this.emptySlot();
                break;
            default:
                break;
        }
    }

    public void UnitSelected(Unit selectedUnit)
    {
        Debug.Log("Unit " + selectedUnit + " selected.");
    }

    public void MapSelected(Map selectedMap)
    {
        Debug.Log("Map " + selectedMap + " selected.");
    }

    private void wellSelected()
    {
        panelWell.SetActive(true);
    }

    private void bankSelected()
    {
        panelBank.SetActive(true);
    }

    private void townHallSelected()
    {
        panelTownHall.SetActive(true);
    }

    private void doorSelected()
    {
        panelDoor.SetActive(true);
    }

    private void emptySlot()
    {
        panelEmptySlot.SetActive(true);
    }

    public void quitPanelBuildings()
    {
        panelWell.SetActive(false);
        panelDoor.SetActive(false);
        panelBank.SetActive(false);
        panelTownHall.SetActive(false);
        panelEmptySlot.SetActive(false);

        panelBuildings.SetActive(false);
    }
}
