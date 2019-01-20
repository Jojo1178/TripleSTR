using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableEntity : MonoBehaviour
{
    protected string entityName;
    
    public string getName()
    {
        return this.entityName;
    }

    public void setName(string entityName)
    {
        this.entityName = entityName;
    }
}
