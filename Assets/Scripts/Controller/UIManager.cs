using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager INSTANCE;

    //Panels:
    public GameObject panelTemporaire;
    public GameObject panelUnits;
    public GameObject panelBuildings;
    public GameObject panelCommun;

    //Panels components:

    // #panelCommun:
    public Text panelCommunTextName;

    private void Awake()
    {
        UIManager.INSTANCE = this;
    }

    public void BuildingSelected(Building selectedBuilding)
    {
        //Affichage des panels concernés:
        panelTemporaire.SetActive(true);
        panelCommun.SetActive(true);
        panelBuildings.SetActive(true);
        panelUnits.SetActive(false);

        //Recuperation des informations à afficher dans l'UI:
        string buildingName = selectedBuilding.getName();

        //Remplissage des champs de l'UI:
        panelCommunTextName.text = buildingName;
    }

    public void UnitSelected(Unit selectedUnit)
    {
        //Affichage des panels concernés:
        panelTemporaire.SetActive(true);
        panelCommun.SetActive(true);
        panelBuildings.SetActive(false);
        panelUnits.SetActive(true);

        //Recuperation des informations à afficher dans l'UI:
        string unitName = selectedUnit.getName();

        //Remplissage des champs de l'UI:
        panelCommunTextName.text = unitName;
    }

    public void MapSelected(Map selectedMap)
    {
        panelTemporaire.SetActive(false);
    }
}
