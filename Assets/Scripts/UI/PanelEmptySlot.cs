using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class PanelEmptySlot : MonoBehaviour
{
    public GameObject content;
    public GameObject panelBuildingDetailsPrefab;
    public GameObject panelResourcesNeedeedPrefab;


    public Sprite imageGrandFosse;
    public Sprite imageTourDeGuet;

    // Start is called before the first frame update
    void Start()
    {
        createBuildingOptions();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void createBuildingOptions()
    {
        // ----- >>> TODO Create buildings from XML file.

        //Create the UI:
        GameObject panelBuildingDetails = (GameObject)Instantiate(panelBuildingDetailsPrefab);
        panelBuildingDetails.transform.SetParent(content.transform);
        BuildingOption buildingOption = panelBuildingDetails.GetComponent<BuildingOption>();

        int numberOfResourcesNeedeed = 2;
        for (int i = 0; i < numberOfResourcesNeedeed; i++)
        {
            GameObject panelResourcesNeededGo = panelResourcesNeededGo = (GameObject)Instantiate(panelResourcesNeedeedPrefab);
            panelResourcesNeededGo.transform.SetParent(panelBuildingDetails.transform);
            panelResourcesNeededGo.transform.localPosition = new Vector2(200 + (i * 80), -20);
            buildingOption.addPanelResourcesNeeded(panelResourcesNeededGo.GetComponent<PanelResourceNeeded>());
        }

        //Get the BuildingOption script and set Gameplay values:
        buildingOption.setBuildingName("Grand Fossé");
        buildingOption.setBuildingSprite(imageGrandFosse);
        buildingOption.addResource(new O_WoodenPlank(0), 4);
        buildingOption.addResource(new O_MetalScrap(0), 3);

        //Populate the UI:
        buildingOption.populateUI();
    }
}
