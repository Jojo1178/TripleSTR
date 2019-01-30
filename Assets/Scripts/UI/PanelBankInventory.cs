using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBankInventory : MonoBehaviour
{
    public GameObject buttonItemPrefab;
    public GameObject panelBankInventory;

    //TODO déplacer le GamePlay dans le script Bank:
    int bankInventoryLineNumber = 10;
    int bankInventoryColumnNumber = 20;

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError("KULUKUKUK LUKUKU STASH STASH");
        createInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createInventory()
    {
        for (int i = 1; i <= bankInventoryColumnNumber; i++)
        {
            for (int j = 1; j <= bankInventoryLineNumber; j++)
            {
                GameObject buttonItem = (GameObject)Instantiate(buttonItemPrefab);
                buttonItem.transform.SetParent(panelBankInventory.transform);
                buttonItem.GetComponent<Button>().onClick.AddListener(FooOnClick);

                buttonItem.transform.GetChild(0).GetComponent<Text>().text = "" + i;
                buttonItem.transform.localPosition = new Vector2(30 * i, -30 * j);
            }
        }
    }
    void FooOnClick()
    {
        Debug.Log("Ta-Da!");
    }
}
