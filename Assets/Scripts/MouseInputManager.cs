using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInputManager : MonoBehaviour
{
    //Panels:
    public GameObject panelTemporaire;
    public GameObject panelUnits;
    public GameObject panelBuildings;
    public GameObject panelCommun;

    //Panels components:

    // #panelCommun:
    public Text panelCommunTextName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            int mouseInput = -1;

            //On vérifie si il y a eu un clic de la souris:
            if (Input.GetMouseButtonDown(0))
            {
                mouseInput = 0;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                mouseInput = 1;
            }
            else if (Input.GetMouseButtonDown(3))
            {
                mouseInput = 0;
            }

            //Si il y a bien eu un clic de la souris:
            if (mouseInput != -1)
            {
                //On récupère le GameObject qui a été sélectionné:
                GameObject selectedGameObject = hit.transform.gameObject;
                string selectedGameObjectName = selectedGameObject.name;

                //On vérifie quel GameObject a été sélectionné:
                switch (selectedGameObject.name)
                {
                    case "Building":
                        Debug.Log("BUILDING SELECTED ("+mouseInput+")");
                        Building buildingScript = selectedGameObject.GetComponent<Building>();
                        buildingScript.clicked(mouseInput);
                        buildingSelected(buildingScript);
                        break;

                    case "Unit":
                        Debug.Log("UNIT SELECTED (" + mouseInput + ")");
                        Unit unitScript = selectedGameObject.GetComponent<Unit>();
                        unitScript.clicked(mouseInput);
                        unitSelected(unitScript);
                        break;

                    case "Map":
                        Debug.Log("MAP SELECTED (" + mouseInput + ")");
                        Map mapScript = selectedGameObject.GetComponent<Map>();
                        mapScript.clicked(mouseInput);
                        mapSelected(mapScript);
                        break;

                    default:
                        Debug.Log("SELECTION UNKNOWN (" + mouseInput + ")");
                        break;
                }
            }
        }
    }

    //TODO Toute cette partie de mise à jour de l'interface n'a rien a faire dans cette classe de gestion des inouts souris. A DEPLACER.

    private void buildingSelected(Building selectedBuilding)
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

    private void unitSelected(Unit selectedUnit)
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

    private void mapSelected(Map selectedMap)
    {
        panelTemporaire.SetActive(false);
    }
}
