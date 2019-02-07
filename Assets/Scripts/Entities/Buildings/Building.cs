using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Building : SpawnableEntity, ISelectionableEntity
{
    public NavMeshObstacle navMeshObstacle;

    private Texture2D cursorTexture;

    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        Debug.Log("---> BULDING");
        
        this.cursorTexture = Resources.Load<Texture2D>("Cursors/cursor_goInside");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void clicked(int mouseInput, RaycastHit hit)
    {
        Debug.Log("BUILDING SELECTED (" + mouseInput + ")");
        UIManager.INSTANCE.BuildingSelected(this);
    }

    void OnMouseOver()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void setCursorTexture(Texture2D cursorTexture)
    {
        this.cursorTexture = cursorTexture;
    }
}
