using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBank : MonoBehaviour
{
    public GameObject buttonItemPrefab;
    public GameObject panelBankInventory;
    public GameObject panelPlayerInventory;

    private Bank bank;
    private Player player;

    private GameObject[] bankInventoryButton;
    private GameObject[] playerInventoryButton;

    public Sprite spriteEmptySlot;
    
    // Start is called before the first frame update
    void Start()
    {
        bank = EntitiesController.INSTANCE.getBank();
        player = EntitiesController.INSTANCE.getPlayer();

        createBankInventory();
        createPlayerInventory();
    }

    // Update is called once per frame
    void Update()
    {
        updateBankInventory();
        updatePlayerInventory();
    }

    void createBankInventory()
    {
        //On récupere les donnees de l'objet Bank:
        int bankInventoryLineNumber = bank.getBankInventoryLineNumber();
        int bankInventoryColumnNumber = bank.getBankInventoryColumnNumber();

        bankInventoryButton = new GameObject[bankInventoryColumnNumber*bankInventoryLineNumber];

        for (int i = 0; i < bankInventoryColumnNumber; i++)
        {
            for (int j = 0; j < bankInventoryLineNumber; j++)
            {
                int id = (j * bankInventoryColumnNumber) + i;

                //On crée les boutons de l'inventaire:
                GameObject buttonItem = (GameObject)Instantiate(buttonItemPrefab);
                buttonItem.transform.SetParent(panelBankInventory.transform);
                buttonItem.name = "buttonItem" + (id);
                //buttonItem.transform.GetChild(0).GetComponent<Text>().text = "" + id;
                buttonItem.transform.localPosition = new Vector2(30 * (i+1), -30 * (j+1));
                buttonItem.GetComponent<Button>().onClick.AddListener(delegate{clickItemBankInventory(id);});

                //On stocke les boutons dans un tableau:
                bankInventoryButton[id] = buttonItem;
            }
        }
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
                buttonItem.GetComponent<Button>().onClick.AddListener(delegate {clickItemPlayerInventory(id);});
                //buttonItem.transform.GetChild(0).GetComponent<Text>().text = "" + id;
                buttonItem.transform.localPosition = new Vector2(30 * (i+1), -30 * (j+1));

                //On stocke les boutons dans un tableau:
                playerInventoryButton[id] = buttonItem;
            }
        }
    }

    private void updateBankInventory()
    {
        //On recupere le tableau d'objets de la banque:
        UsableObject[] bankInventory = bank.getBankInventory();

        //On parcours le tableau d'objets de la banque:
        for (int i = 0; i < bankInventory.Length; i++)
        {
            //On on a un objet:
            if (bankInventory[i] != null)
            {
                //On recupere ses infos:
                int id = bankInventory[i].getObjectId();
                Sprite objectSprite = bankInventory[i].getObjectSprite();

                //On met a jour le bouton correspondant dans l'UI:
                //bankInventoryButton[i].transform.GetChild(0).GetComponent<Text>().text = ""+id;
                bankInventoryButton[i].GetComponent<Image>().sprite = objectSprite;
            }
            else
            {
                //bankInventoryButton[i].transform.GetChild(0).GetComponent<Text>().text = "N";
                bankInventoryButton[i].GetComponent<Image>().sprite = spriteEmptySlot;
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
                //playerInventoryButton[i].transform.GetChild(0).GetComponent<Text>().text = ""+id;
                playerInventoryButton[i].GetComponent<Image>().sprite = objectSprite;
            }
            else
            {
                //bankInventoryButton[i].transform.GetChild(0).GetComponent<Text>().text = "N";
                playerInventoryButton[i].GetComponent<Image>().sprite = spriteEmptySlot;
            }
        }
    }

    void clickItemBankInventory(int id)
    {
        //Si on clique sur un objet de l'inventaire de la banque, on l'ajoute dans l'inventaire du joueur:
        UsableObject clickedObject = bank.getBankInventory()[id];
        bool objectAdded = player.addObjectToPlayerInventory(clickedObject);

        //Si l'object a bien pu être ajouté, on le retire de l'inventaire du joueur:
        if (objectAdded)
        {
            bank.removeObjectFromBankInventory(id);
        }
    }

    void clickItemPlayerInventory(int id)
    {
        //Si on clique sur un objet de l'inventaire du joueur, on l'ajoute dans l'inventaire de la banque:
        UsableObject clickedObject = player.getPlayerInventory()[id];
        bool objectAdded = bank.addObjectToBankInventory(clickedObject);

        //Si l'object a bien pu être ajouté, on le retire de l'inventaire de la banque:
        if (objectAdded)
        {
            player.removeObjectFromPlayerInventory(id);
        }
    }
}
