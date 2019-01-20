using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : SpawnableEntity, ISelectionableEntity
{
    // Start is called before the first frame update
    void Start()
    {
        this.setName("UNIT");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void clicked(int mouseInput)
    {
        Debug.Log("UNIT SELECTED (" + mouseInput + ")");
        UIManager.INSTANCE.UnitSelected(this);
    }
}
