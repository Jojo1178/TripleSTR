using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : SpawnableEntity, ISelectionableEntity
{
    // Start is called before the first frame update
    void Start()
    {
        this.setName("BUILDING");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void clicked(int mouseInput)
    {
        Debug.Log("BUILDING SELECTED (" + mouseInput + ")");
        UIManager.INSTANCE.BuildingSelected(this);
    }
}
