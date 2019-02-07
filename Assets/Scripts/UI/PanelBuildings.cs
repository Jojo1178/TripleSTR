using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBuildings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void quitPanelBuildings()
    {
        Debug.Log("Quit");
        UIManager.INSTANCE.quitPanelBuildings();
    }
}
