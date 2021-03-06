﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingOption : MonoBehaviour
{
    //Panel and its UI components:
    public BuildingSlot buildingSlotInfos;
    public Image imageBuildingIcon;
    public Text textBuildingName;
    public Button buttonBuild;
    private List<PanelResourceNeeded> panelResourcesNeededList = new List<PanelResourceNeeded>();

    //Gameplay:
    private bool built;
    private bool resourcesAvailable;
    private List<Tuple<UsableObject, int>> resourceList = new List<Tuple<UsableObject, int>>();
    private Bank bank;

    //Values in UI components:
    private BuildingOption prerequisite;
    private string buildingName;
    private Sprite buildingSprite;

    private Color colorBuildingBuilt = new Color(200, 120, 0, 75);
    private Color colorResourcesAvailable = new Color(0, 175, 40, 75);
    private Color colorConstructionImpossible = new Color(200, 0, 0, 75);

    public BuildingOption()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        built = false;
        resourcesAvailable = false;
        buttonBuild.interactable = false;
        bank = EntitiesController.INSTANCE.getBank();
    }

    // Update is called once per frame
    void Update()
    {
        updatePrerequisites();
        updateQuantityAvailable();
        //updateBackgroundColor();
    }

    // ==================
    // = UPDATE METHODS =
    // ==================

    private void updateBackgroundColor()
    {
        Image panelBackgroundColor = this.GetComponent<Image>();

        if (built)
        {
            panelBackgroundColor.color = colorBuildingBuilt;
        }
        else
        {
            if (resourcesAvailable)
            {
                panelBackgroundColor.color = colorResourcesAvailable;
            }
            else
            {
                panelBackgroundColor.color = colorConstructionImpossible;
            }
        }
    }
    
    //Check if all resources of the BuildingOption are available in Bank inventory:
    private void updatePrerequisites()
    {
        resourcesAvailable = bank.areResourcesAvailable(resourceList);

        if (resourcesAvailable)
        {
            buttonBuild.interactable = true;
        } 
    }
    
    private void updateQuantityAvailable()
    {
        for (int i = 0; i < panelResourcesNeededList.Count; i++)
        {
            Tuple<UsableObject, int> resource = resourceList[i];
            PanelResourceNeeded panelResourcesNeedeed = panelResourcesNeededList[i];

            UsableObject objectToCheck = resource.Item1;
            
            int bankQuantity = bank.getNumberOfObjectInBankInventory(objectToCheck);
            panelResourcesNeedeed.textResourceQuantity.text = bankQuantity+" / " + resource.Item2.ToString();
        }    
    }

    // ============
    // = ON CLICK =
    // ============

    public void clickBuild()
    {
        //TOOD: replace by prefabs
        Debug.Log("BUILD " + buildingName);
        EntitiesController.INSTANCE.Build(this.buildingSlotInfos);
        UIManager.INSTANCE.quitPanelBuildings();
    }

    // ===============
    // = UI CREATION =
    // ===============

    public void populateUI()
    {
        textBuildingName.text = this.buildingName;
        imageBuildingIcon.sprite = this.buildingSprite;

        for (int i = 0; i < panelResourcesNeededList.Count; i++)
        {
            Tuple<UsableObject, int> resource = resourceList[i];
            PanelResourceNeeded panelResourcesNeedeed = panelResourcesNeededList[i];

            panelResourcesNeedeed.imageResourceNeedeed.sprite = resource.Item1.getObjectSprite();
            panelResourcesNeedeed.textResourceQuantity.text = "/ " + resource.Item2.ToString();
        }
    }

    // ===================
    // = GET/SET METHODS =
    // ===================

    public void setPrerequisite(BuildingOption prerequisite)
    {
        this.prerequisite = prerequisite;
    }

    public void setBuildingName(string buildingName)
    {
        this.buildingName = buildingName;
    }

    public void setBuildingSprite(Sprite buildingSprite)
    {
        this.buildingSprite = buildingSprite;
    }

    public bool isBuilt()
    {
        return this.built;
    }

    public void addResource(UsableObject resource, int quantity)
    {
        this.resourceList.Add(new Tuple<UsableObject, int>(resource, quantity));
    }

    public void addPanelResourcesNeeded(PanelResourceNeeded panelResourcesNeeded)
    {
        this.panelResourcesNeededList.Add(panelResourcesNeeded);
    }
}
