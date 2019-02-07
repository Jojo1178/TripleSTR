using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelWell : MonoBehaviour
{
    public Image imageWellWater;

    public GameObject buttonItemPrefab;
    public GameObject panelPlayerInventory;
    public Sprite spriteEmptySlot;

    private Well well;
    private Player player;
    private GameObject[] playerInventoryButton;

    // Start is called before the first frame update
    void Start()
    {
        well = EntitiesController.INSTANCE.getWell();
        player = EntitiesController.INSTANCE.getPlayer();
        
        createPlayerInventory();
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayerInventory();
        updateWellRepresentation();
    }

    void createPlayerInventory()
    {
        //On recupere les donnees de l'objet Player:
        int playerInventoryLineNumber = player.getPlayerInventoryLineNumber();
        int playerInventoryColumnNumber = player.getPlayerInventoryColumnNumber();

        playerInventoryButton = new GameObject[playerInventoryColumnNumber * playerInventoryLineNumber];

        for (int i = 0; i < playerInventoryColumnNumber; i++)
        {
            for (int j = 0; j < playerInventoryLineNumber; j++)
            {
                int id = (j * playerInventoryColumnNumber) + i;

                //On crée les boutons de l'inventaire:
                GameObject buttonItem = (GameObject)Instantiate(buttonItemPrefab);
                buttonItem.transform.SetParent(panelPlayerInventory.transform);
                buttonItem.name = "buttonItem" + (id);
                buttonItem.transform.localPosition = new Vector2(30 * (i + 1), -30 * (j + 1));

                //On stocke les boutons dans un tableau:
                playerInventoryButton[id] = buttonItem;
            }
        }
    }

    private void updatePlayerInventory()
    {
        //On recupere le tableau d'objets du joueur:
        UsableObject[] playerInventory = player.getPlayerInventory();

        //On parcours le tableau d'objets de la banque:
        for (int i = 0; i < playerInventory.Length; i++)
        {
            //On on a un objet:
            if (playerInventory[i] != null)
            {
                //On recupere ses infos:
                int id = playerInventory[i].getObjectId();
                Sprite objectSprite = playerInventory[i].getObjectSprite();

                //On met a jour le bouton correspondant dans l'UI:
                playerInventoryButton[i].GetComponent<Image>().sprite = objectSprite;
            }
            else
            {
                playerInventoryButton[i].GetComponent<Image>().sprite = spriteEmptySlot;
            }
        }
    }

    private void updateWellRepresentation()
    {
        int waterMaximumCapacity = well.getWaterMaximumQuantity();
        int waterCurrentCapacity = well.getWaterCurrentQuantity();
        int capacityPourcentage = waterCurrentCapacity * 100 / waterMaximumCapacity;

        //Height = 190 for 100% capacity.
        int height = capacityPourcentage * 190 / 100;

        imageWellWater.rectTransform.sizeDelta = new Vector2(200, height);
    }

    public void clickOnGetWater(int id)
    {
        O_WaterBottle waterBottle = well.getWaterFromWell();
        if (waterBottle != null)
        {
            bool objectAdded = player.addObjectToPlayerInventory(waterBottle);
            if (!objectAdded)
            {
                Debug.Log("Plus de place dans l'inventaire.");
            }
        }
        else
        {
            Debug.Log("Plus d'eau dans le puit.");
        }
    }
}
