using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UsableObject
{
    private int objectId;
    private string objectName;
    private Sprite objectSprite;

    public UsableObject(int id, string objectName, string objectSpriteName)
    {
        this.objectId = id;
        this.objectName = objectName;

        instanciateObjectImage(objectSpriteName);
    }

    private void instanciateObjectImage(string objectSpriteName)
    {
        this.objectSprite = Resources.Load<Sprite>("Objects/"+ objectSpriteName);
        if (this.objectSprite == null)
        {
            this.objectSprite = Resources.Load<Sprite>("Objects/ImageNotFound");
        }
    }

    public string getObjectName()
    {
        return this.objectName;
    }

    public int getObjectId()
    {
        return this.objectId;
    }

    public Sprite getObjectSprite()
    {
        return this.objectSprite;
    }
}
