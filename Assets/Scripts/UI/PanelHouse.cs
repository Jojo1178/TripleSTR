using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHouse : MonoBehaviour
{
    private Player player;
    private House house;

    public GameObject buttonItemPrefab;
    public GameObject panelPlayerInventory;
    public GameObject panelHouseInventory;
    public Sprite spriteEmptySlot;

    private GameObject[] playerInventoryButton;
    private GameObject[] houseInventoryButton;


    // Start is called before the first frame update
    void Start()
    {
        player = EntitiesController.INSTANCE.getPlayer();
        house = EntitiesController.INSTANCE.getHouse();

        createPlayerInventory();
        createHouseInventory();
    }

    // Update is called once per frame
    void Update()
    {
        updatePlayerInventory();
        updateHouseInventory();
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
                buttonItem.GetComponent<Button>().onClick.AddListener(delegate { clickItemPlayerInventory(id); });

                //On stocke les boutons dans un tableau:
                playerInventoryButton[id] = buttonItem;
            }
        }
    }

    void createHouseInventory()
    {
        //On recupere les donnees de l'objet House:
        int houseInventoryLineNumber = house.getHouseInventoryLineNumber();
        int houseInventoryColumnNumber = house.getHouseInventoryColumnNumber();

        houseInventoryButton = new GameObject[houseInventoryColumnNumber * houseInventoryLineNumber];

        for (int i = 0; i < houseInventoryColumnNumber; i++)
        {
            for (int j = 0; j < houseInventoryLineNumber; j++)
            {
                int id = (j * houseInventoryColumnNumber) + i;

                //On crée les boutons de l'inventaire:
                GameObject buttonItem = (GameObject)Instantiate(buttonItemPrefab);
                buttonItem.transform.SetParent(panelHouseInventory.transform);
                buttonItem.name = "buttonItem" + (id);
                buttonItem.transform.localPosition = new Vector2(30 * (i + 1), -30 * (j + 1));
                buttonItem.GetComponent<Button>().onClick.AddListener(delegate { clickItemHouseInventory(id); });

                //On stocke les boutons dans un tableau:
                houseInventoryButton[id] = buttonItem;
            }
        }
    }

    private void updatePlayerInventory()
    {
        //On recupere le tableau d'objets du joueur:
        UsableObject[] playerInventory = player.getPlayerInventory();

        //On parcours le tableau d'objets du joueur:
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

    private void updateHouseInventory()
    {
        //On recupere le tableau d'objets de la maison:
        UsableObject[] houseInventory = house.getHouseInventory();

        //On parcours le tableau d'objets de la maison:
        for (int i = 0; i < houseInventory.Length; i++)
        {
            //On on a un objet:
            if (houseInventory[i] != null)
            {
                //On recupere ses infos:
                int id = houseInventory[i].getObjectId();
                Sprite objectSprite = houseInventory[i].getObjectSprite();

                //On met a jour le bouton correspondant dans l'UI:
                houseInventoryButton[i].GetComponent<Image>().sprite = objectSprite;
            }
            else
            {
                houseInventoryButton[i].GetComponent<Image>().sprite = spriteEmptySlot;
            }
        }
    }

    void clickItemHouseInventory(int id)
    {
        //Si on clique sur un objet de l'inventaire de l'habitation, on l'ajoute dans l'inventaire du joueur:
        UsableObject clickedObject = house.getHouseInventory()[id];
        bool objectAdded = player.addObjectToPlayerInventory(clickedObject);

        //Si l'object a bien pu être ajouté, on le retire de l'inventaire de l'habitation:
        if (objectAdded)
        {
            house.removeObjectFromHouseInventory(id);
        }
    }

    void clickItemPlayerInventory(int id)
    {
        //Si on clique sur un objet de l'inventaire du joueur, on l'ajoute dans l'inventaire de l'habitation:
        UsableObject clickedObject = player.getPlayerInventory()[id];
        bool objectAdded = house.addObjectToHouseInventory(clickedObject);

        //Si l'object a bien pu être ajouté, on le retire de l'inventaire du joueur:
        if (objectAdded)
        {
            player.removeObjectFromPlayerInventory(id);
        }
    }
}
