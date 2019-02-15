using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelEmptySlot : MonoBehaviour
{
    public GameObject content;
    public GameObject panelBuildingDetailsPrefab;

    public Sprite imageGrandFosse;
    public Sprite imageTourDeGuet;

    // Start is called before the first frame update
    void Start()
    {
        //Load the Prefab:
        GameObject panelBuildingDetails = (GameObject)Instantiate(panelBuildingDetailsPrefab);
        panelBuildingDetails.transform.SetParent(content.transform);

        //Get the BuildingOption script and set its values:
        BuildingOption buildingOption = panelBuildingDetails.GetComponent<BuildingOption>();
        buildingOption.setBuildingName("Grand Fossé");
        buildingOption.setBuildingSprite(imageGrandFosse);
        buildingOption.createUI();

        //Load the Prefab:
        GameObject tdg = (GameObject)Instantiate(panelBuildingDetailsPrefab);
        tdg.transform.SetParent(content.transform);

        //Get the BuildingOption script and set its values:
        BuildingOption bo = tdg.GetComponent<BuildingOption>();
        bo.setBuildingName("Tour de Guet");
        bo.setBuildingSprite(imageTourDeGuet);
        bo.createUI();
    }

    // Update is called once per frame
    void Update()
    {
          
    }
}
