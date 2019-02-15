using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingOption : MonoBehaviour
{
    //Panel and its UI components:
    public GameObject panelBuildingOption;
    public Image imageBuildingIcon;
    public Text textBuildingName;
    public Button buttonBuild;
    
    private bool built;
    private bool resourcesAvailable;
    private bool prerequisitesBuilt;

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
        prerequisitesBuilt = false;
        buttonBuild.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        updatePrerequisites();
        updateBackgroundColor();
    }

    // ==================
    // = UPDATE METHODS =
    // ==================

    private void updateBackgroundColor()
    {
        Image panelBackgroundColor = panelBuildingOption.GetComponent<Image>();

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
    
    private void updatePrerequisites()
    {
        if (prerequisite)
        {
            if (prerequisite.isBuilt())
            {
                prerequisitesBuilt = true;
                buttonBuild.interactable = true;
            }
        }
    }

    // ============
    // = ON CLICK =
    // ============

    public void clickBuild()
    {
        Debug.Log("BUILD " + buildingName);
    }

    // ===============
    // = UI CREATION =
    // ===============

    public void createUI()
    {
        textBuildingName.text = this.buildingName;
        imageBuildingIcon.sprite = this.buildingSprite;
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
}
