using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBankInventory : MonoBehaviour
{
    public GameObject buttonItemPrefab;
    public GameObject panelBankInventory;
    public GameObject panelPlayerInventory;

    private GameObject[] bankInventoryButton;
    private GameObject[] playerInventoryButton;

    public Sprite spriteEmptySlot;

    //TODO déplacer le GamePlay dans le script Bank:
    int bankInventoryLineNumber = 10;
    int bankInventoryColumnNumber = 20;

    //TODO déplacer le GamePlay dans le script Player:
    int playerInventoryLineNumber = 1;
    int playerInventoryColumnNumber = 6;

    // Start is called before the first frame update
    void Start()
    {
        createPlayerInventory();
        createBankInventory();
    }

    // Update is called once per frame
    void Update()
    {
        updateBankInventory();
    }

    void createBankInventory()
    {
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
                buttonItem.GetComponent<Button>().onClick.AddListener(clickItemBankInventory);

                //On stocke les boutons dans un tableau:
                bankInventoryButton[id] = buttonItem;
            }
        }
    }

    void createPlayerInventory()
    {
        for (int i = 1; i <= playerInventoryColumnNumber; i++)
        {
            for (int j = 1; j <= playerInventoryLineNumber; j++)
            {
                GameObject buttonItem = (GameObject)Instantiate(buttonItemPrefab);
                buttonItem.transform.SetParent(panelPlayerInventory.transform);
                buttonItem.GetComponent<Button>().onClick.AddListener(clickItemPlayerInventory);
                
                buttonItem.transform.GetChild(0).GetComponent<Text>().text = "" + (i-1);
                buttonItem.transform.localPosition = new Vector2(30 * i, -30 * j);
            }
        }
    }

    void clickItemBankInventory()
    {
        Debug.Log("ITEM BANK INVENTORY");
    }

    void clickItemPlayerInventory()
    {
        Debug.Log("ITEM PLAYER INVENTORY");
    }

    private void updateBankInventory()
    {
        //On recupere le tableau d'objets de la banque:
        Bank bank = EntitiesController.INSTANCE.getBank();
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
}
