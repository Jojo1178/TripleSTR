using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableEntity : MonoBehaviour
{
    protected string entityName;

    // Start is called before the first frame update
    protected void Start()
    {
        Debug.Log("---> SPAWNABLE ENTITY");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string getName()
    {
        return this.entityName;
    }

    public void setName(string entityName)
    {
        this.entityName = entityName;
    }
}
