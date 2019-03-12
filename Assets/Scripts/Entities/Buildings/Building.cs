using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Building : SpawnableEntity, ISelectionableEntity
{
    public NavMeshObstacle navMeshObstacle;
    public Transform[] entryPoints;

    private Texture2D cursorTexture;

    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        Debug.Log("---> BULDING");
        
        this.cursorTexture = Resources.Load<Texture2D>("Cursors/cursor_goInside");
    }

    public virtual void clicked(int mouseInput, RaycastHit hit)
    {
        Debug.Log("BUILDING SELECTED (" + mouseInput + ")" + this.GetType());
        this.movePlayerToBuildingEntrance();
    }

    protected virtual void movePlayerToBuildingEntrance()
    {
        ApplicationController.INSTANCE.MainPlayer.MoveAndDo(this.getClosestEntryPoint(ApplicationController.INSTANCE.MainPlayer.transform.position), (player) =>
        {
            this.PlayerReachBuildingEntrance();
        });
    }

    protected virtual void PlayerReachBuildingEntrance()
    {
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

    protected Vector3 getClosestEntryPoint(Vector3 point)
    {
        float minDistance = float.MaxValue;
        float distance;
        Vector3 closest = point;
        foreach (Transform t in this.entryPoints)
        {
            distance = Vector3.Distance(point, t.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = t.position;
            }
        }
        return closest;
    }
}
