using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class PanelTower : MonoBehaviour
{
    public GameObject content;
    public GameObject panelBuildingDetailsPrefab;
    public GameObject panelResourcesNeedeedPrefab;

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
        //On parcours tous les BuildingSlot du fichier XML et on crée les Panels à ajouter dans l'UI:
        foreach (BuildingSlot bs in ApplicationController.INSTANCE.DataBaseManager.BuildingSlots.Building)
        {
            if (bs.BuildingType.Equals("TOWER"))
            {
                this.BuildBuildingOption(bs);
            }
        }
    }

    private void BuildBuildingOption(BuildingSlot bs)
    {
        //Create the UI:
        GameObject panelBuildingDetails = (GameObject)Instantiate(panelBuildingDetailsPrefab);
        panelBuildingDetails.transform.SetParent(content.transform);
        BuildingOption buildingOption = panelBuildingDetails.GetComponent<BuildingOption>();

        //Get the BuildingOption script and set Gameplay values:
        buildingOption.buildingSlotInfos = bs;
        buildingOption.setBuildingName(bs.Name);
        buildingOption.setBuildingSprite(Resources.Load<Sprite>(bs.Image));


        int numberOfResourcesNeedeed = bs.Resources.Resource.Count;
        for (int i = 0; i < numberOfResourcesNeedeed; i++)
        {
            GameObject panelResourcesNeededGo = panelResourcesNeededGo = (GameObject)Instantiate(panelResourcesNeedeedPrefab);
            panelResourcesNeededGo.transform.SetParent(panelBuildingDetails.transform);
            panelResourcesNeededGo.transform.localPosition = new Vector2(200 + (i * 80), -20);
            buildingOption.addPanelResourcesNeeded(panelResourcesNeededGo.GetComponent<PanelResourceNeeded>());
            BuildingResource br = bs.Resources.Resource[i];
            buildingOption.addResource((UsableObject)Activator.CreateInstance(Type.GetType(br.Text), 4), Convert.ToInt32(br.Quantity));
        }

        //Populate the UI:
        buildingOption.populateUI();
    }
}
