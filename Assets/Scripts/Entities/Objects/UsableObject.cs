using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UsableObject
{
    private int objectId;
    protected string objectName;
    protected string objectSpriteName;

    private Sprite objectSprite;

    public UsableObject(int id)
    {
        this.objectId = id;
    }

    protected void instanciateObjectImage()
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
